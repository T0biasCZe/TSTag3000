using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TSTag3000.db;
namespace TSTag3000 {

	public static class Database {
		public static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000";
		public static SQLiteConnection connection;
		public static void Init() {
			/*Initialize SQLite database, and if it doesn't exist, create it*/
			if(!System.IO.Directory.Exists(AppDataPath)) {
				System.IO.Directory.CreateDirectory(AppDataPath);
			}
			if(!System.IO.Directory.Exists(AppDataPath + "\\thumbnails")) {
				System.IO.Directory.CreateDirectory(AppDataPath + "\\thumbnails");
			}
			if(!System.IO.File.Exists(AppDataPath + "\\TSTag3000.db")) {
				SQLiteConnection.CreateFile(AppDataPath + "\\TSTag3000.db");
			}
			connection = new SQLiteConnection("Data Source=" + AppDataPath + "\\TSTag3000.db;Version=3;");

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
		public static void AddTag(Tag tag) {
			connection.Open();
			SQLiteCommand command = new SQLiteCommand("INSERT INTO tag (name, type) VALUES ('" + tag.name + "', '" + tag.type + "')", connection);
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
