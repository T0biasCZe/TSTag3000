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

namespace TSTag3000 {
	public partial class ManagePage : UserControl {
		public ManagePage() {
			InitializeComponent();
			this.BackColor = Color.Transparent;

			ManagePage_Resize(null, null);
		}

		private void ManagePage_Resize(object sender, EventArgs e) {
			panel_left.Height = this.Height - toolStrip1.Height;
			listBox_albums.Height = panel_left.Height - 40;


			explorerBrowser1.Width = this.Width - 392;
			explorerBrowser1.Height = this.Height - toolStrip1.Height - 48;
			listBox_tags.Left = this.Width - 184;
			listBox_tags.Height = this.Height - toolStrip1.Height - 78;
			comboBox1.Left = this.Width - 184;
			panel_info.Left = this.Width - 224;
			button_addAlbum.Top = listBox_albums.Height + listBox_albums.Top + 8;
			button1.Top = listBox_albums.Height + listBox_albums.Top + 8;
			textBox_explorerPath.Width = this.Width - 392 - 64;

			toolStrip1.Width = this.Width + 10;

		}

		private void ManagePage_Load(object sender, EventArgs e) {
			loadAlbumList();
			explorerBrowser1.Show();
		}
		private void loadAlbumList() {
			/*load table "album" from database and add to listBox_albums*/
			listBox_albums.Items.Clear();
			var connection = Database.connection;
			connection.Open();
			var command = new System.Data.SQLite.SQLiteCommand("SELECT * FROM album", connection);
			var reader = command.ExecuteReader();
			while(reader.Read()) {
				listBox_albums.Items.Add(reader["name"]);
			}
			connection.Close();
		}

		private void button1_Click(object sender, EventArgs e) {
			loadAlbumList();
		}

		private void explorerBrowser1_Load(object sender, EventArgs e) {
			try {
				string path = Environment.ExpandEnvironmentVariables("%UserProfile%\\pictures\\");
				ShellObject Shell = ShellObject.FromParsingName(path);
				explorerBrowser1.Navigate(Shell);
				textBox_explorerPath.Text = path;
			}
			catch {
				string path = Environment.ExpandEnvironmentVariables("C:\\");
				ShellObject Shell = ShellObject.FromParsingName(path);
				explorerBrowser1.Navigate(Shell);
				textBox_explorerPath.Text = path;
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
				Bitmap bitmap = new Bitmap(reader["path"].ToString());
				Size inputBitmapSize = bitmap.Size;

				if(inputBitmapSize.Width > inputBitmapSize.Height) {
					bitmap = new Bitmap(bitmap, 160, 160 * inputBitmapSize.Height / inputBitmapSize.Width);
				}
				else {
					bitmap = new Bitmap(bitmap, 160 * inputBitmapSize.Width / inputBitmapSize.Height, 160);
				}

				//compress the image to jpeg with quality 50, and save it to the database as BLOB into the "thumbnail" column
				System.IO.MemoryStream stream = new System.IO.MemoryStream();
				var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
				var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20L) } };
				bitmap.Save(stream, encoder, encParams);
				bitmap.Save(Database.AppDataPath + "\\thumbnails\\" + reader["path"].ToString().GetHashCode().ToString() + ".jpg", encoder, encParams);
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
					//file is in the database
					Bitmap bitmap = new Bitmap(item.ParsingName);
					Size inputBitmapSize = bitmap.Size;

					if(inputBitmapSize.Width > inputBitmapSize.Height) {
						bitmap = new Bitmap(bitmap, 160, 160 * inputBitmapSize.Height / inputBitmapSize.Width);
					}
					else {
						bitmap = new Bitmap(bitmap, 160 * inputBitmapSize.Width / inputBitmapSize.Height, 160);
					}

					//compress the image to jpeg with quality 50, and save it to the database as BLOB into the "thumbnail" column
					System.IO.MemoryStream stream = new System.IO.MemoryStream();
					var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
					var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20L) } };
					bitmap.Save(stream, encoder, encParams);
					bitmap.Save(Database.AppDataPath + "\\thumbnails\\" + item.ParsingName.GetHashCode().ToString() + ".jpg", encoder, encParams);
					command = new System.Data.SQLite.SQLiteCommand("UPDATE FileMetadata SET thumbnail = @thumbnail WHERE path = @path", connection);
					command.Parameters.AddWithValue("@thumbnail", stream.ToArray());
					command.Parameters.AddWithValue("@path", item.ParsingName);
					command.ExecuteNonQuery();
					stream.Close();
				}
				else {
					//file is not in the database
					label1.Text = "Skipping file " + item.Name;
					Thread.Sleep(200);
				}
			}
			connection.Close();
			panel_info.Visible = false;
		}

		private void toolStripButton_addToAlbum_Click(object sender, EventArgs e) {

		}

		private void toolStripButton_ffmpegTag_Click(object sender, EventArgs e) {

		}

		private void explorerBrowser1_SelectionChanged(object sender, EventArgs e) {
			var selectedItems = explorerBrowser1.SelectedItems;
			listBox_tags.Items.Clear();
			if(selectedItems.Count() == 0){
				return;
			}
			else if(selectedItems.Count() == 1) {

				var selectedItem = selectedItems[0];
				//check in database if there is entry in FileMetadata table, if there is put it in FileMetadata object, else create new object

			}
			else {
				listBox_tags.Items.Add("Tag view N/A in batch edit");
			}
		}

	}
}
