using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SharpCoding.SharpHelpers
{
    public static class FileHelper
    {
         public static void SafeDelete(string fileUrl)
            {
                if ((string.IsNullOrEmpty(fileUrl)) || (!File.Exists(fileUrl)))
                    return;

                if (!FileInUse(fileUrl)) File.Delete(fileUrl);
            }

            public static void SafeMove(string fileUrl,string destUrl,FileOperationType mode=FileOperationType.None)
            {
                if ((string.IsNullOrEmpty(fileUrl)) || (!File.Exists(fileUrl)))
                    return;

                switch (mode)
                {
                    case FileOperationType.None:
                        if (File.Exists(destUrl))
                        {
                            SafeDelete(fileUrl);
                            return;
                        }
                        break;
                    case FileOperationType.Delete:
                        if (File.Exists(destUrl) && !FileInUse(destUrl)) File.Delete(destUrl);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mode));
                }

                if (!FileInUse(fileUrl)) File.Move(fileUrl, destUrl);
            }

            public static long GetFileLenght(this string url)
            {
                if (string.IsNullOrEmpty(url)) return default(int);
                if (!File.Exists(url)) return default(int);

                var fi = new FileInfo(url);

                return fi.Length;
            }

            public static bool FileInUse(this string filePath)
            {
                FileStream stream = null;

                try
                {
                    var file = new FileInfo(filePath);
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;
                }
                finally
                {
                    stream?.Close();
                }

                //file is not locked
                return false;
            }

            public static bool FileIsEmpty(this string filePath)
            {
                var length = new FileInfo(filePath).Length;

                return length <= 0;
            }

            public static IEnumerable<string> GetFiles(string sourceFolder, string filter )
            {
                // ArrayList will hold all file names
                var allFiles = new List<string>();

                // Create an array of filter string
                var multipleFilters = filter.Split('|');

                // for each filter find mathing file names
                foreach (var fileFilter in multipleFilters)
                {
                    // add found file names to array list
                    allFiles.AddRange(Directory.GetFiles(sourceFolder , fileFilter));
                }

                // returns string array of relevant file names
                return allFiles;
            }
    }
    public enum FileOperationType
    {
        None,
        Delete
    }
}
