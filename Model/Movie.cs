using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Model
{
    public class Movie : Medium
    {
        private readonly string[] legacyCovers=
        {
            "*-banner.jpg",
            "*-poster.jpg",
            "*-clearart.png",
            "*-clearlogo.png",
            "*-discart.png",
            "*-fanart.jpg",
            "*-landscape.jpg",
            "*-poster.jpg"
        };
        public Movie(string filepath) : base(filepath)
        {
            Media=MediaType.Movies;
            SetMainCover("poster.jpg");    
        }

        public override void ManageCovers()
        {
            base.ManageCovers();
            var legacy = GatherLegacyCovers();
            foreach (var cover in legacy)
            {
                cover.Delete();
            }
        }

        private IEnumerable<FileInfo> GatherLegacyCovers()
        {
            var files = new List<FileInfo>();
            foreach (var temp in legacyCovers.Select(cover => Root.GetFiles(cover)))
            {
                files.AddRange(temp);
            }
            return files;
        }
    }
}
