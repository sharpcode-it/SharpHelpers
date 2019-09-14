using System;
using System.Collections.Generic;
using System.IO;

namespace SharpCoding.SharpHelpers
{
    // (c) 2019 SharpCoding
    // This code is licensed under MIT license (see LICENSE.txt for details)
    public static class FileHelper
    {
        /// <summary>
        /// Given a file url, this method will safely delete the file
        /// </summary>
        /// <param name="fileUrl"></param>
        public static void SafeDelete(string fileUrl)
        {
            if ((string.IsNullOrEmpty(fileUrl)) || (!File.Exists(fileUrl)))
                return;

            if (!FileInUse(fileUrl)) File.Delete(fileUrl);
        }

        /// <summary>
        /// This method move the specified file to the destination Url
        /// Depending on mode parameter, if the file already exists in destination url
        /// FileOperationType.None : The origin file will be deleted and the destination file will not be modified
        /// FileOperationType.Delete : The origin file will overwrite the destination file
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="destUrl"></param>
        /// <param name="mode"></param>
        public static void SafeMove(string fileUrl, string destUrl, FileOperationType mode = FileOperationType.None)
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

        /// <summary>
        /// The method returns the file lenght, if the file url is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static long GetFileLenght(this string url)
        {
            if (string.IsNullOrEmpty(url)) return default(int);
            if (!File.Exists(url)) return default(int);

            var fi = new FileInfo(url);

            return fi.Length;
        }


        /// <summary>
        /// The method returns true if the file is already in use and locked
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
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

        /// <summary>
        /// the method return true is the file is empty
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool FileIsEmpty(this string filePath)
        {
            var length = new FileInfo(filePath).Length;

            return length <= 0;
        }

        /// <summary>
        /// Given a folder path and a string containing filters splitted with | char, the method will return the paths of the files that match the specified filters
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFiles(string sourceFolder, string filters)
        {
            // ArrayList will hold all file names
            var allFiles = new List<string>();

            // Create an array of filter string
            var multipleFilters = filters.Split('|');

            // for each filter find mathing file names
            foreach (var fileFilter in multipleFilters)
            {
                // add found file names to array list
                allFiles.AddRange(Directory.GetFiles(sourceFolder, fileFilter));
            }

            // returns string array of relevant file names
            return allFiles;
        }
    }

    /// <summary>
    /// File operation type operation
    /// </summary>
    public enum FileOperationType
    {
        None,
        Delete
    }
}
