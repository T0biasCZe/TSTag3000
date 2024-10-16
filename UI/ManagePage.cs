using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSTag3000.db;
using TSTag3000.scripts;
using TSTag3000.UI.controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;
using Tag = TSTag3000.db.Tag;

namespace TSTag3000
{
    public partial class ManagePage : UserControl {
		public ManagePage() {
			InitializeComponent();
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = false;

		}

		private void ManagePage_Resize(object sender, EventArgs e) {
			panel_left.Height = this.Height - toolStrip1.Height;

			int halfPanelHeight = panel_left.Height / 2;

			listBox_albums.Height = halfPanelHeight - 40;
			button_addAlbum.Top = listBox_albums.Height + listBox_albums.Top + 8;
			button1.Top = listBox_albums.Height + listBox_albums.Top + 8;

			listBox_categories.Height = halfPanelHeight - 40;
			listBox_categories.Top = listBox_albums.Top + halfPanelHeight;
			button2.Top = listBox_categories.Top + listBox_categories.Height + 8;
			button_addCategory.Top = listBox_categories.Top + listBox_categories.Height + 8;


			explorerBrowser1.Width = this.Width - 392;
			explorerBrowser1.Height = this.Height - toolStrip1.Height - 48;
			listBox_tags.Left = this.Width - 184;
			listBox_tags.Height = this.Height - toolStrip1.Height - 138 - 4;
			comboBox_addTag.Left = this.Width - 184;
			comboBox_tagCategory.Left = this.Width - 184;
			button_addtag.Left = this.Width - 184 + comboBox_tagCategory.Width + 5;
			label_albumname.Left = this.Width - 184;
			panel_info.Left = this.Width - 224;
			textBox_explorerPath.Width = this.Width - 392 - 64;

			toolStrip1.Width = this.Width + 10;

			Settings.managePageSize = Form1.form.Size;

			Settings.managePageMaximized = Form1.form.WindowState == FormWindowState.Maximized;


			try {
				using(Graphics g = this.CreateGraphics()) {
					Rectangle rect = new Rectangle(0, 88, this.Width, this.Height - 88);
					g.FillRectangle(new SolidBrush(Color.White), rect);
				}
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void ManagePage_Load(object sender, EventArgs e) {
			loadAlbumList();
			loadCategoriesList();
			loadComboBox();

			ManagePage_Resize(null, null);
		}
		private void loadAlbumList() {
			/*load table "album" from database and add to listBox_albums*/
			listBox_albums.Items.Clear();

			var connection = Database.connection;
			connection.Open();
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM album", connection);
			var reader = command.ExecuteReader();
			List<string> albums = new List<string>();
			while(reader.Read()) {
				albums.Add(reader["name"].ToString());
			}
			listBox_albums.Items.AddRange(albums.ToArray());
			connection.Close();
		}
		private void loadCategoriesList() {
			/*load table "category" from database and add to listBox_categories*/
			listBox_categories.Items.Clear();

			var connection = Database.connection;
			connection.Open();
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM category", connection);
			var reader = command.ExecuteReader();
			List<string> categories = new List<string>();
			while(reader.Read()) {
				categories.Add(reader["name"].ToString());
			}
			listBox_categories.Items.AddRange(categories.ToArray());
			connection.Close();
		}

		private void button1_Click(object sender, EventArgs e) {
			loadAlbumList();
		}

		private void loadComboBox() {
			List<Tag> tags = Database.GetTags("");
			label2.Text = "Tags: " + tags.Count;
			comboBox_addTag.Items.Clear();
			//tag colour mapping:
			//meta tag - blue
			//copyright tag - green
			//character tag - aqua
			//artist tag - red
			//general tag - yellow
			//other tag - black



			foreach(var tag in db.Tag.SortTags(tags)) {
				Color colour = db.Tag.GetColour(tag.type);
				comboBox_addTag.Items.Add(new ComboBoxItem(tag.name, tag.ID, colour));
			}
		}

		private void explorerBrowser1_Load(object sender, EventArgs e) {
			try {
				string path = "";
				if(Settings.lastDirectory != null) {
					path = Settings.lastDirectory;
				}
				else if(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))){
					path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
				}
				else {
					path = Environment.ExpandEnvironmentVariables("C:\\");
				}
				ShellObject Shell = ShellObject.FromParsingName(path);
				explorerBrowser1.Navigate(Shell);
				textBox_explorerPath.Text = path;
			}
			catch {
				MessageBox.Show("Error loading explorerBrowser1", "Error");
			}
		}

		private void toolStripButton_batchGenerateThumbnail_Click(object sender, EventArgs e) {
			var result = MessageBox.Show("This will generate thumbnails for all files in the database. This may take a long time. Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo);
			if(result == DialogResult.No) return;
			/*for every file in database in the table "FileMetadata" generate thumbnail*/
			var connection = Database.connection;
			connection.Open();
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata", connection);
			var reader = command.ExecuteReader();
			panel_info.Visible = true;
			int i = 0;
			while(reader.Read()) {
				i++;
				label1.Text = $"Creating thumbnail {i}...";
				string filePath = reader["path"].ToString();
				Bitmap thumb = ffmpeg.GetThumbnail(filePath);

				//compress the image to jpeg with quality 50, and save it to the database as BLOB into the "thumbnail" column
				System.IO.MemoryStream stream = new System.IO.MemoryStream();
				var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
				var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20L) } };
				thumb.Save(stream, encoder, encParams);
				thumb.Save(Database.AppDataPath + "\\thumbnails\\" + reader["path"].ToString().GetHashCode().ToString() + ".jpg", encoder, encParams);
				command = new System.Data.SQLite.SQLiteCommand("UPDATE FileMetadata SET thumbnail = @thumbnail WHERE path = @path", connection);
				command.Parameters.AddWithValue("@thumbnail", stream.ToArray());
				command.Parameters.AddWithValue("@path", reader["path"].ToString());
				command.ExecuteNonQuery();
				stream.Close();
			}
			connection.Close();
			if(i == 0) {
				MessageBox.Show("No files in the database to process", "Info");
			}
			else {
				MessageBox.Show("Thumbnails generated for " + i + " files", "Info");
			}
			panel_info.Visible = false;
		}

		private void toolStripButton_generateThumbnail_Click(object sender, EventArgs e) {
			var items = explorerBrowser1.SelectedItems.ToArray();
			//find this file in the database
			var connection = Database.connection;
			connection.Open();
			panel_info.Visible = true;
			foreach(var item in items) {
				var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
				command.Parameters.AddWithValue("@path", item.ParsingName);
				var reader = command.ExecuteReader();
				if(reader.Read()) {
					int fileInItems = listBox_tags.Items.IndexOf(item.ParsingName);
					label1.Text = $"Creating thumbnail {fileInItems + 1}/{listBox_tags.Items.Count}...";

					string filePath = item.ParsingName;
					Bitmap thumb = ffmpeg.GetThumbnail(filePath);


					//compress the image to jpeg with quality 50, and save it to the database as BLOB into the "thumbnail" column
					System.IO.MemoryStream stream = new System.IO.MemoryStream();
					var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
					var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20L) } };
					thumb.Save(stream, encoder, encParams);
					thumb.Save(Database.AppDataPath + "\\thumbnails\\" + item.ParsingName.GetHashCode().ToString() + ".jpg", encoder, encParams);
					command = new System.Data.SQLite.SQLiteCommand("UPDATE FileMetadata SET thumbnail = @thumbnail WHERE path = @path", connection);
					command.Parameters.AddWithValue("@thumbnail", stream.ToArray());
					command.Parameters.AddWithValue("@path", item.ParsingName);
					command.ExecuteNonQuery();
					stream.Close();
				}
				else {
					//file is not in the database
					label1.Text = "Skipping file " + item.Name;
					Thread.Sleep(400);
				}
			}
			connection.Close();
			panel_info.Visible = false;
		}

		private void toolStripButton_addToAlbum_Click(object sender, EventArgs e) {

		}

		private void toolStripButton_ffmpegTag_Click(object sender, EventArgs e) {
			//for every file in the database in the table "FileMetadata" generate tags using ffmpeg

			int numberOfFiles = Database.GetNumberOfFiles();
			var connection = Database.connection;
			connection.Open();
			
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata", connection);
			var reader = command.ExecuteReader();
			panel_info.Visible = true;
			int i = 0;
			while(reader.Read()) {
				i++;
				label1.Text = $"FFTagging {i}/{numberOfFiles}...";
				string filePath = reader["path"].ToString();
				bool hasAudio = ffmpeg.CheckSound(filePath);
				bool isAnimated = ffmpeg.CheckAnimated(filePath);

				//add tag "animated" if the file is animated, and "sound" if the file has audio
				if(isAnimated) {
					Database.AddTagToFile(filePath, "animated", "meta", (int)(long)reader["id"]);
				}
				if(hasAudio) {
					Database.AddTagToFile(filePath, "sound", "meta", (int)(long)reader["id"]);
				}
			}
			connection.Close();
			panel_info.Visible = false;
		}

		private void explorerBrowser1_SelectionChanged(object sender, EventArgs e) {
			var selectedItems = explorerBrowser1.SelectedItems;
			listBox_tags.Items.Clear();
			label_albumname.Text = "Album: N/A\nCategory: N/A";
			if(selectedItems.Count() == 0) {
				listBox_tags.Items.Add("No files selected");
				return;
			}
			else if(selectedItems.Count() == 1) {
				var selectedItem = selectedItems[0];
				//check in database if there is entry in FileMetadata table, if there is put it in FileMetadata object, else create new object
				var connection = Database.connection;
				connection.Open();
				var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
				command.Parameters.AddWithValue("@path", selectedItem.ParsingName);
				var reader_file = command.ExecuteReader();
				FileMetadata fileMetadata = new FileMetadata();
				int i = 0;
				int j = 0;
				if(reader_file.Read()) {
					try {
						fileMetadata.ID = (int)(long)reader_file["id"];
						fileMetadata.path = (string)reader_file["path"];
						//load thumbnail from blob (jpeg)
						//byte[] thumbnail = (byte[])reader["thumbnail"];
						//System.IO.MemoryStream stream = new System.IO.MemoryStream(thumbnail);
						//fileMetadata.thumbnail = new Bitmap(stream);
						//stream.Close();
						//load tags from database, from table "tag" and connecting table "FileMetadata_has_tag"
						command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata_has_tag WHERE FileMetadata_ID = @FileMetadata_ID", connection);
						command.Parameters.AddWithValue("@FileMetadata_ID", fileMetadata.ID);
						var reader_tags = command.ExecuteReader();
						while(reader_tags.Read()) {
							i++;
							command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE id = @id", connection);
							command.Parameters.AddWithValue("@id", (int)(long)reader_tags["tag_ID"]);
							var reader2 = command.ExecuteReader();
							if(reader2.Read()) {
								j++;
								Tag tag = new Tag();
								tag.ID = (int)(long)reader2["id"];
								tag.name = (string)reader2["name"];
								tag.type = (string)reader2["type"];
								fileMetadata.tags.Add(tag);
							}
						}
						label2.Text = "Tags: " + i + " " + j;
						//set the album and category
						command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM album WHERE id = @id", connection);
						command.Parameters.AddWithValue("@id", (int)(long)reader_file["album_ID"]);
						var reader_albums = command.ExecuteReader();
						if(reader_albums.Read()) {
							Album album = new();
							album.ID = (int)(long)reader_albums["id"];
							album.name = (string)reader_albums["name"];
							fileMetadata.album = album;
						}
						command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM category WHERE id = @id", connection);
						command.Parameters.AddWithValue("@id", (int)(long)reader_file["category_ID"]);
						reader_albums = command.ExecuteReader();
						if(reader_albums.Read()) {
							Category category = new();
							category.ID = (int)(long)reader_albums["id"];
							category.name = (string)reader_albums["name"];
							fileMetadata.category = category;
						}
						string albumName = "UNSET";
						string categoryName = "UNSET";
						if(fileMetadata.album != null) {
							albumName = fileMetadata.album.name;
						}
						if(fileMetadata.category != null) {
							categoryName = fileMetadata.category.name;
						}
						label_albumname.Text = $"Album: {albumName}\nCategory: {categoryName}\n FileID: {fileMetadata.ID}";
					}
					catch(Exception ex) {
						MessageBox.Show(ex.ToString());
					}
				}
				else {

				}
				connection.Close();
				//MessageBox.Show("Tags: " + i + " " + j);
				foreach(var tag in db.Tag.SortTags(fileMetadata.tags)) {
					Color colour = db.Tag.GetColour(tag.type);
					//listBox_tags.Items.Add(tag.name);
					listBox_tags.Items.Add(new ListBoxColourItem(colour, tag.name));
				}

			}
			else {
				listBox_tags.Items.Add("Tag view N/A in batch edit");
				label_albumname.Text = "Album: N/A\nCategory: N/A";
			}

		}


		private void comboBox_addTag_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				string tag = comboBox_addTag.Text;
				string tagCategory = comboBox_tagCategory.Text;
				if(comboBox_addTag.Text.Length > 0 && tagCategory.Length > 0) {
					AddTagToSelectedFiles(tag, tagCategory);
					//loadComboBox();
				}
				else {
					MessageBox.Show("invalid tag or tag category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		bool running = false;
		public void AddTagToSelectedFiles(string tag, string tagCategory) {
			if(running) {
				MessageBox.Show("Already running");
				return;
			}
			running = true;
			var connection = Database.connection;
			if(connection.State != ConnectionState.Open) {
				try {
					connection.Open();
				}
				catch(Exception e) {
					MessageBox.Show(e.ToString());
					return;
				}
			}
			else {
				MessageBox.Show("Connection already open");
				return;
			}

			//check if tag already exists in database, if not add it.
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE name = @name", connection);
			command.Parameters.AddWithValue("@name", tag);
			var reader = command.ExecuteReader();
			int tagID = -1;
			if(reader.Read()) {
				tagID = (int)(long)reader["id"];
			}
			else {
				var command0 = new System.Data.SQLite.SQLiteCommand("INSERT INTO tag (name, type) VALUES (@name, @type)", connection);
				command0.Parameters.AddWithValue("@name", tag);
				command0.Parameters.AddWithValue("@type", tagCategory);
				command0.ExecuteNonQuery();
				var command1 = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE name = @name", connection);
				command1.Parameters.AddWithValue("@name", tag);
				var reader1 = command1.ExecuteReader();
				if(reader1.Read()) {
					tagID = (int)(long)reader1["id"];
				}
			}
			if(tagID == -1) {
				System.Media.SystemSounds.Exclamation.Play();
				MessageBox.Show("Error adding tag to Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int fileID = -1;
			foreach(ShellObject? item in explorerBrowser1.SelectedItems) {
				var command2 = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
				command2.Parameters.AddWithValue("@path", item.ParsingName);
				var reader2 = command2.ExecuteReader();
				//if the file doesnt exist then add it to DB
				if(!reader2.Read()) {
					FileMetadata fileMetadata = new FileMetadata();
					fileMetadata.path = item.ParsingName;
					fileMetadata.creationDate = GetDateTime(item);
					fileMetadata.dateIndexed = DateTime.Now;
					fileMetadata.size = (long)item.Properties.System.Size.Value;

					var command3 = new System.Data.SQLite.SQLiteCommand("INSERT INTO FileMetadata (path, creationDate, dateIndexed, size, album_ID, category_ID) VALUES (@path, @creationDate, @dateIndexed, @size, @album_ID, @category_ID)", connection);
					command3.Parameters.AddWithValue("@path", fileMetadata.path);
					command3.Parameters.AddWithValue("@creationDate", fileMetadata.creationDate);
					command3.Parameters.AddWithValue("@dateIndexed", fileMetadata.dateIndexed);
					command3.Parameters.AddWithValue("@size", fileMetadata.size);
					command3.Parameters.AddWithValue("@album_ID", listBox_albums.SelectedIndex + 1);
					command3.Parameters.AddWithValue("@category_ID", listBox_categories.SelectedIndex + 1);

					try {
						command3.ExecuteNonQuery();
					}
					catch(Exception e) {
						MessageBox.Show(e.ToString());
					}

					//get the ID of the newly added file
					var command4 = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata WHERE path = @path", connection);
					command4.Parameters.AddWithValue("@path", item.ParsingName);

					var reader4 = command4.ExecuteReader();
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
					MessageBox.Show("Error adding file to Database\n" + item.ParsingName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				//check if this tag already exists
				var command5 = new System.Data.SQLite.SQLiteCommand("SELECT * FROM FileMetadata_has_tag WHERE FileMetadata_ID = @FileMetadata_ID AND tag_ID = @tag_ID", connection);
				command5.Parameters.AddWithValue("@FileMetadata_ID", fileID);
				command5.Parameters.AddWithValue("@tag_ID", tagID);
				var reader5 = command5.ExecuteReader();
				if(!reader5.Read()) {
					try {
						//MessageBox.Show("3.2");
						var command6 = new System.Data.SQLite.SQLiteCommand("INSERT OR IGNORE INTO FileMetadata_has_tag (FileMetadata_ID, tag_ID) VALUES (@FileMetadata_ID, @tag_ID)", connection);
						command6.Parameters.AddWithValue("@FileMetadata_ID", fileID);
						command6.Parameters.AddWithValue("@tag_ID", tagID);
						command6.ExecuteNonQuery();
					} 
					catch (Exception ex){
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
			running = false;
		}

		private void comboBox_addTag_SelectedIndexChanged(object sender, EventArgs e) {
			if(comboBox_addTag.SelectedItem != null) {
				var itemName = ((ComboBoxItem)comboBox_addTag.SelectedItem).Text;
				//find the tag in the database and set the category in the comboBox_tagCategory
				var connection = Database.connection;
				connection.Open();
				var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM tag WHERE name = @name", connection);
				command.Parameters.AddWithValue("@name", itemName);
				var reader = command.ExecuteReader();
				if(reader.Read()) {
					comboBox_tagCategory.Text = (string)reader["type"];
				}
				connection.Close();
			}
		}

		private void button_addtag_Click(object sender, EventArgs e) {
			string tag = comboBox_addTag.Text;
			string tagCategory = comboBox_tagCategory.Text;
			if(comboBox_addTag.Text.Length > 0 && tagCategory.Length > 0) {
				AddTagToSelectedFiles(tag, tagCategory);
				loadComboBox();
			}
			else {
				MessageBox.Show("invalid tag or tag category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void explorerBrowser1_NavigationComplete(object sender, Microsoft.WindowsAPICodePack.Controls.NavigationCompleteEventArgs e) {
			textBox_explorerPath.Text = e.NewLocation.ParsingName;
			Settings.lastDirectory = e.NewLocation.ParsingName;
		}

		private void textBox_explorerPath_TextChanged(object sender, EventArgs e) {
			if(System.IO.Directory.Exists(textBox_explorerPath.Text)) {
				ShellObject Shell = ShellObject.FromParsingName(textBox_explorerPath.Text);
				explorerBrowser1.Navigate(Shell);
			}
		}

		private static DateTime GetDateTime(ShellObject? item) {
			if(item.Properties.System.DateCreated.Value != null) {
				return (DateTime)item.Properties.System.DateCreated.Value;
			}
			else if(item.Properties.System.DateModified.Value != null) {
				return (DateTime)item.Properties.System.DateModified.Value;
			}
			else {
				return DateTime.UnixEpoch;
			}
		}
	}
}
