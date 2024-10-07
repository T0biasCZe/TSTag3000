using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSTag3000 {

	public class Database {
		public static List<FileMetadata> files { get { return db._files; } set { db._files = value; } }
		public static List<string> albums { get { return db._albums; } set { db._albums = value; } }
		public static List<string> categories { get { return db._categories; } set { db._categories = value; } }
		public static List<Tuple<string, string>> albumPasswords { get { return db._albumPasswords; } set { db._albumPasswords = value; } }


		public static Database db;
		private List<FileMetadata> _files;
		private List<string> _albums;
		private List<string> _categories;
		private List<Tuple<string, string>> _albumPasswords;
	}
	public static class TIOS {
		public static string databaseDirectory = "";
		public static void Init() {
			databaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000\\";
		}
		public static void SaveDatabase() {
			//serialize db to databasePath as xml
			XmlSerializer serializer = new XmlSerializer(typeof(Database));
			string databasePath = databaseDirectory + "database.xml";
			if(!System.IO.Directory.Exists(databaseDirectory)) {
				System.IO.Directory.CreateDirectory(databaseDirectory);
			}
			using(System.IO.StreamWriter writer = new System.IO.StreamWriter(databasePath)) {
				serializer.Serialize(writer, Database.db);
			}
		}
		public static void LoadDatabase() {
			//deserialize db from databasePath as xml
			XmlSerializer serializer = new XmlSerializer(typeof(Database));
			string databasePath = databaseDirectory + "database.xml";
			if(System.IO.File.Exists(databasePath)) {
				using(System.IO.StreamReader reader = new System.IO.StreamReader(databasePath)) {
					//deserialize db
					Database.db = (Database)serializer.Deserialize(reader);
				}
			}
			else {
				var result = MessageBox.Show("Database not found. Create new database?", "Database not found", MessageBoxButtons.YesNoCancel);
				if(result == DialogResult.Yes) {
					Database.db = new Database();
					Database.files = new List<FileMetadata>();
					Database.albums = new List<string>();
					Database.categories = new List<string>();
					Database.albumPasswords = new List<Tuple<string, string>>();
					TIOS.SaveDatabase();
				}
				else if(result == DialogResult.No) {
					Environment.Exit(0);
				}
				else {
					Environment.Exit(0);
				}
			}
		}
	}
}
