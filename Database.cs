using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace TSTag3000 {

	public static class Database {
		public static string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000";
		public static SQLiteConnection connection;
		public static void Init() {
			/*Initialize SQLite database, and if it doesn't exist, create it*/
			if(!System.IO.Directory.Exists(AppDataPath)) {
				System.IO.Directory.CreateDirectory(AppDataPath);
			}
			if(!System.IO.File.Exists(AppDataPath + "\\TSTag3000.db")) {
				SQLiteConnection.CreateFile(AppDataPath + "\\TSTag3000.db");
			}
			connection = new SQLiteConnection("Data Source=" + AppDataPath + "\\TSTag3000.db;Version=3;");

		}
		public static void SaveShutdown() {
			connection.Close();		
		}
	}
}
