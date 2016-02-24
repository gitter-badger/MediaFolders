using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Model
{
    public class Show : Medium
    {
        private List<Season> seasons;
        public Show(string filepath) : base(filepath)
        {
            seasons=new List<Season>();
            Media=MediaType.TV;
            SetMainCover("poster.jpg");
            foreach (var dir in Root.EnumerateDirectories("Season*"))
            {
                seasons.Add(new Season(dir.FullName));
            }
        }

        public override void ManageCovers()
        {
            base.ManageCovers();
            foreach (var season in seasons)
            {
                season.ManageCovers();
            }
        }
    }
}
