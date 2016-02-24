using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Model
{
    class Artist : Medium
    {
        private List<Album> albums;

        public Artist(string filepath) : base(filepath)
        {
            Media=MediaType.Music;
            albums=new List<Album>();
            foreach (var dir in Root.GetDirectories())
            {
                albums.Add(new Album(dir.FullName));
            }
        }

        public override void ManageCovers()
        {
            if (!folder.Exists)
            {
                RecordMissing();
            }
            foreach (var album in albums)
            {
                album.ManageCovers();
            }
        }
    }
}
