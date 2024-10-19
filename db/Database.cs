using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.WindowsAPICodePack.Shell;
using System.Data;
namespace TSTag3000.db{

    public static class Database {
        public static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000";
        public static SQLiteConnection connection;
        public static void Init() {
            /*Initialize SQLite database, and if it doesn't exist, create it*/
            if(!Directory.Exists(AppDataPath)) {
                Directory.CreateDirectory(AppDataPath);
            }
            if(!Directory.Exists(AppDataPath + "\\thumbnails")) {
                Directory.CreateDirectory(AppDataPath + "\\thumbnails");
            }
            if(!File.Exists(AppDataPath + "\\TSTag3000.db")) {
                SQLiteConnection.CreateFile(AppDataPath + "\\TSTag3000.db");

                connection = new SQLiteConnection("Data Source=" + AppDataPath + "\\TSTag3000.db;Version=3;");

                try {
                    //create tables from "createdb.sql"
                    connection.Open();
                    //run the sql script
                    SQLiteCommand command = new SQLiteCommand(File.ReadAllText("createdb2.sql"), connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch(Exception ex) {
                    connection.Close();
                    System.Media.SystemSounds.Exclamation.Play();
                    var result = MessageBox.Show("Error creating database. Abort?\n" + ex.Message, "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if(result != DialogResult.Ignore) {
                        Application.Exit();
                    }
                }

                try {
                    //add data from addtestdata
                    connection.Open();
                    //run the sql script
                    SQLiteCommand command = new SQLiteCommand(File.ReadAllText("addtestdata.sql").Replace("INSERT IGNORE", "INSERT OR IGNORE"), connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch(Exception ex) {
                    connection.Close();
                    System.Media.SystemSounds.Exclamation.Play();
                    var result2 = MessageBox.Show("Error adding test data. Abort?\n" + ex.Message, "ERROR", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if(result2 != DialogResult.Ignore) {
                        Application.Exit();

                    }
                }

                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Database created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else connection = new SQLiteConnection("Data Source=" + AppDataPath + "\\TSTag3000.db;Version=3;");

        }
        public static void SaveShutdown() {
            connection.Close();
        }

        public static List<Tag> GetTags(string filter) {
            List<Tag> tags = new List<Tag>();
            connection.Open();
            SQLiteCommand command;
            if(filter.Length > 2) {
                command = new SQLiteCommand("SELECT * FROM tag WHERE type = '" + filter + "'", connection);
            }
            else command = new SQLiteCommand("SELECT * FROM tag", connection);
            var reader = command.ExecuteReader();
            while(reader.Read()) {
                Tag tag = new Tag();
                tag.ID = (int)(long)reader["id"];
                tag.name = (string)reader["name"];
                tag.type = (string)reader["type"];
                tags.Add(tag);
            }
            connection.Close();
            return tags;
        }
        public static int AddTag(Tag tag) {
            SQLiteCommand command = new SQLiteCommand("INSERT INTO tag (name, type) VALUES ('" + tag.name + "', '" + tag.type + "')", connection);
            command.ExecuteNonQuery();
            int id = (int)connection.LastInsertRowId;
			//return the id of the tag
			return id;
		}

		public static FileMetadata getFile(string path) {
            return null;
        }
        public static bool AddTagToFile(string filePath, string tagName, string tagCategory, int? fileID_=null) {
			SQLiteCommand command;
			SQLiteDataReader reader;
			int fileID = -1;
			int tagID = -1;
            if(fileID_ != null) {
                fileID = (int)fileID_;
            }
            else {
                command = new SQLiteCommand("SELECT id FROM FileMetadata WHERE path = '" + filePath + "'", connection);
                reader = command.ExecuteReader();
                if(reader.Read()) {
                    fileID = (int)(long)reader["id"];
                }
                else {
                    return false;
                }
            }
			command = new SQLiteCommand("SELECT id FROM tag WHERE name = '" + tagName + "'", connection);
			reader = command.ExecuteReader();
			if(reader.Read()) {
				tagID = (int)(long)reader["id"];
			}
			else {
                tagID = AddTag(new Tag() { name = tagName, type = tagCategory });
			}
            if(tagID == -1 || fileID == -1) {
				return false;
			}

			//insert row into FileMetadata_has_tag
			command = new SQLiteCommand("INSERT OR IGNORE INTO FileMetadata_has_tag (FileMetadata_id, tag_id) VALUES (" + fileID + ", " + tagID + ")", connection);
			command.ExecuteNonQuery();
			return true;
		}

		public static int GetNumberOfFiles() {
            //get number of rows in table FileMetadata
            connection.Open();
            int count = 1234567890;
            try {
                SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM FileMetadata", connection);
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception ex) {

            }
            connection.Close();
            return count;
        }

		public static bool AddTagToFiles(string tag, string tagCategory, List<string> paths, int albumID) {
			var connection = Database.connection;
			if(connection.State != ConnectionState.Open) {
				try {
					connection.Open();
				}
				catch(Exception e) {
					MessageBox.Show(e.ToString());
					return false;
				}
			}
			else {
				MessageBox.Show("Connection already open");
				return false;
			}

			//check if tag already exists in database, if not add it.
			var command_checkTag = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE name = @name", connection);
			command_checkTag.Parameters.AddWithValue("@name", tag);
			var reader = command_checkTag.ExecuteReader();
			int tagID = -1;
			if(reader.Read()) {
				tagID = (int)(long)reader["id"];
			}
			else {
				var command_addTag = new System.Data.SQLite.SQLiteCommand("INSERT INTO tag (name, type) VALUES (@name, @type)", connection);
				command_addTag.Parameters.AddWithValue("@name", tag);
				command_addTag.Parameters.AddWithValue("@type", tagCategory);
				command_addTag.ExecuteNonQuery();
				var command_tagId = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE name = @name", connection);
				command_tagId.Parameters.AddWithValue("@name", tag);
				var reader1 = command_tagId.ExecuteReader();
				if(reader1.Read()) {
					tagID = (int)(long)reader1["id"];
				}
			}
			if(tagID == -1) {
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Error adding tag to Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			int fileID = -1;
			foreach(string path in paths) {
				var command_checkFile = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
				command_checkFile.Parameters.AddWithValue("@path", path);
				var reader2 = command_checkFile.ExecuteReader();
				//if the file doesnt exist then add it to DB
				if(!reader2.Read()) {
					FileMetadata fileMetadata = new FileMetadata();
					fileMetadata.path = path;
					fileMetadata.creationDate = File.GetCreationTime(path);
					fileMetadata.dateIndexed = DateTime.Now;
					fileMetadata.size = new FileInfo(path).Length;


					var command_addFile = new System.Data.SQLite.SQLiteCommand("INSERT INTO FileMetadata (path, creationDate, dateIndexed, size, album_ID, category_ID) VALUES (@path, @creationDate, @dateIndexed, @size, @album_ID, @category_ID)", connection);
					command_addFile.Parameters.AddWithValue("@path", fileMetadata.path);
					command_addFile.Parameters.AddWithValue("@creationDate", fileMetadata.creationDate);
					command_addFile.Parameters.AddWithValue("@dateIndexed", fileMetadata.dateIndexed);
					command_addFile.Parameters.AddWithValue("@size", fileMetadata.size);
					command_addFile.Parameters.AddWithValue("@album_ID", albumID + 1);
					command_addFile.Parameters.AddWithValue("@category_ID", 99_999);

					try {
						command_addFile.ExecuteNonQuery();
					}
					catch(Exception e) {
						MessageBox.Show(e.ToString());
					}

					//get the ID of the newly added file
					var command_fileId = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
					command_fileId.Parameters.AddWithValue("@path", path);

					var reader4 = command_fileId.ExecuteReader();
					if(reader4.Read()) {
						fileID = (int)(long)reader4["id"];
					}

					//MessageBox.Show("3.1.5");
				}
				else {
					fileID = (int)(long)reader2["id"];
				}

				if(fileID == -1) {
					System.Media.SystemSounds.Exclamation.Play();
					MessageBox.Show("Error adding file to Database\n" + path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}

				//check if this tag already exists
				var command_checkFileTag = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata_has_tag WHERE FileMetadata_ID = @FileMetadata_ID AND tag_ID = @tag_ID", connection);
				command_checkFileTag.Parameters.AddWithValue("@FileMetadata_ID", fileID);
				command_checkFileTag.Parameters.AddWithValue("@tag_ID", tagID);
				var reader5 = command_checkFileTag.ExecuteReader();
				if(!reader5.Read()) {
					try {
						//MessageBox.Show("3.2");
						var command_addFileTag = new System.Data.SQLite.SQLiteCommand("INSERT OR IGNORE INTO FileMetadata_has_tag (FileMetadata_ID, tag_ID) VALUES (@FileMetadata_ID, @tag_ID)", connection);
						command_addFileTag.Parameters.AddWithValue("@FileMetadata_ID", fileID);
						command_addFileTag.Parameters.AddWithValue("@tag_ID", tagID);
						command_addFileTag.ExecuteNonQuery();
					}
					catch(Exception ex) {
						MessageBox.Show($"error adding tag {tagID} to file {fileID}:\n{ex.ToString()}");
					}
				}
				else {
					MessageBox.Show("Tag already exists in file", "Info");
				}
			}
			//MessageBox.Show("4");
			connection.Close();
			MessageBox.Show($"Tag {tag} {tagID} added to file {fileID}", "Info");
			return true;
		}
	}
}
