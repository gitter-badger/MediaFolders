using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Model
{
    class Season : Medium
    {
        public Season(string filepath) : base(filepath)
        {
            Media=MediaType.TV;
            SetMainCover(Root.Parent.FullName+Path.DirectorySeparatorChar+Root.Name.ToLower().Replace(" ","")+ "-poster.jpg");
        }
    }
}
