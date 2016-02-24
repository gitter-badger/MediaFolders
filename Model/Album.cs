using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Model
{
    class Album : Medium
    {
        public Album(string filepath):base(filepath)
        {
            Media=MediaType.Music;
            SetMainCover("cover.jpg");
        }
    }
}
