using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CCommandShell.Filesystem;

namespace CCommandShell.Filesystem
{
    public class PathHandler
    {
        private readonly CommandOutputWriter outputWriter = new();

        public string GetFullPath(Directory currentDirectory, Drive drive)
        {
            var fullPath = new List<string>();
            var loopDir = currentDirectory;

            while (loopDir != null)
            {
                fullPath.Insert(0, loopDir.Name);
                loopDir = loopDir.ParentDirectory;
            }

            return $"{drive.Label}:{string.Join("\\", fullPath)}";
        }

        public Directory GetDirectory(string path, Directory currentDir, Drive drive)
        {
            var resultDir = currentDir;
            var pattern = @"\w{1}:";
            var regex = new Regex(pattern);
            var splitted = path.Split('\\');

            foreach (var word in splitted)
            {
                if (word.Equals("..", StringComparison.Ordinal))
                {
                    resultDir = resultDir.ParentDirectory ?? resultDir;
                }
                else if (regex.IsMatch(word))
                {
                    resultDir = drive.RootDirectory;
                }
                else
                {
                    resultDir = FindDirectoryInCurrent(resultDir, word) ?? resultDir;
                }
            }

            return resultDir;
        }

        private Directory FindDirectoryInCurrent(Directory currentDir, string name)
        {
            foreach (var item in currentDir.FilesystemItems)
            {
                if (item.Name.Equals(name, StringComparison.Ordinal) && item is Directory dir)
                {
                    return dir;
                }
            }

            outputWriter.WriteLine("Your Path is invalid!");
            return null;
        }
    }
}
