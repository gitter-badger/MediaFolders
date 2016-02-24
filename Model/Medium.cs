using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

using static com.kritikos.MediaFolders.Libs.Crypto.Hashes;

namespace com.kritikos.MediaFolders.Model
{
    public abstract class Medium
    {
        internal FileInfo main;
        internal readonly FileInfo folder;
        internal readonly DirectoryInfo Root;
        internal MediaType Media;

        protected Medium(string filepath)
        {
            Root = new DirectoryInfo(filepath);
            folder = new FileInfo(ConstructPath(Root.FullName, "folder.jpg"));
        }

        public virtual void ManageCovers()
        {
            if (main.Exists)
            {
                if (folder.Exists)
                {
                    if (CompareCovers()) return;
                    folder.Delete();
                    main.CopyTo(folder.FullName);
                }
                else
                {
                    main.CopyTo(folder.FullName);
                }
            }
            else
            {
                if (folder.Exists)
                {
                    folder.CopyTo(main.FullName);
                }
                else
                {
                    RecordMissing();
                }
            }
         }

        internal void SetMainCover(string name)
        {
            if (GetType() != typeof (Season))
            {
                main = new FileInfo(ConstructPath(Root.FullName, name));
            }
            else
            {
                main = new FileInfo(Root.Parent.FullName+Path.DirectorySeparatorChar+Root.Name.ToLower().Replace(" ","")+"-poster.jpg");
            }
        }

        internal static string ConstructPath(params string[] components)
        {
            var path = new StringBuilder();
            foreach (var component in components)
            {
                path.Append(component);
                if (component == components.Last()) { break; }
                path.Append(Path.DirectorySeparatorChar);
            }
            return path.ToString();
        }

        private bool CompareCovers()
        {
            return GetMD5Hash(main) == GetMD5Hash(folder);
        }

        internal void RecordMissing()
        {
            string root;
#if(DEBUG)
            root = @"Z:";
#else
            root = AppDomain.CurrentDomain.BaseDirectory;
#endif
            using (StreamWriter file = new StreamWriter(ConstructPath(root, "missing.txt")))
            {
                file.WriteLine(Media+"\t {location}",this.Root.FullName);
            }
        }
    }
}
