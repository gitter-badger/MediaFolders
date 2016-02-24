using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace com.kritikos.MediaFolders.Libs
{
    public static class Hashes
    {
        public static string GetMD5Hash(FileInfo file)
        {
            if (!file.Exists)
            {
                return string.Empty;
            }

            using (var md5 = MD5.Create())
            {
                using (var stream = file.OpenRead())
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
    }
}
