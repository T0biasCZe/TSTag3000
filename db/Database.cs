using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
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
    }
}
