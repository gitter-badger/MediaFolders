using System;
using System.IO;
using System.Security.Cryptography;

namespace com.kritikos.MediaFolders.Libs.Crypto
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
