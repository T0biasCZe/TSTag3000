using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTag3000.db {
    public class FileMetadata {
        public int ID;
        public DateTime dateIndexed;
        public string path;
        public long size;
        public DateTime creationDate;
        public Bitmap thumbnail;
        public Rating rating;
        public Album album;
        public List<Tag> tags;

		public FileMetadata() {
			tags = new List<Tag>();
		}

	}
    public enum Rating {
        Safe,
        Questionable,
        Explicit,
        Unrated
    }
}
