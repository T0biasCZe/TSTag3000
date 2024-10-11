using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSTag3000 {
	public class Settings {
		public static Settings s;
		public string _lastDirectory { get; set; }
		public static string lastDirectory {
			get { return s._lastDirectory; }
			set { s._lastDirectory = value; }
		}
		public static void LoadSettings() {
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000\\settings.xml";
			if(System.IO.File.Exists(path)) {
				//deserialize xml
				XmlSerializer serializer = new XmlSerializer(typeof(Settings));
				System.IO.StreamReader reader = new System.IO.StreamReader(path);
				s = (Settings)serializer.Deserialize(reader);
				reader.Close();
			}
			else {
				s = new Settings();
			}
		}
		public static void SaveSettings() {
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TSTag3000\\settings.xml";
			//serialize xml
			XmlSerializer serializer = new XmlSerializer(typeof(Settings));
			System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
			serializer.Serialize(writer, s);
			writer.Flush();
			writer.Close();
		}
	}
}
