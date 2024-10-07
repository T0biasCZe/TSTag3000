using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTag3000 {
	public class FileMetadata {
		public string FileMetadata_ID;
		public string FileName;
		public string FilePath;
		public string FileSize;
		public string FileDate;

		public Bitmap thumbnail;

		public string album; 
		public string category;

		public List<string> MetaTags;
		public List<string> CopyrightTags;
		public List<string> CharacterTags;
		public List<string> ArtistTags;
		public List<string> GeneralTags;

		public Rating rating;

		public FileMetadata() {
			MetaTags = new List<string>();
			CharacterTags = new List<string>();
			ArtistTags = new List<string>();
			GeneralTags = new List<string>();
			thumbnail = null;
			rating = Rating.Unrated;
		}
	}
	public enum Rating {
		Safe,
		Questionable,
		Explicit,
		Unrated
	}
}
