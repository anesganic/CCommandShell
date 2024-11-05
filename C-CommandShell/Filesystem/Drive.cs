using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Filesystem
{
    public class Drive : FilesystemItem
    {
        public Directory RootDirectory { get; set; }
        public string Label { get; set; }
        public string FilesystemType { get; set; }
        public string DriveType { get; set; }

        public Drive(Directory rootDirectory, string name, string label, string fileSystemType, string driveType)
        {
            RootDirectory = rootDirectory;
            Name = name;
            Label = label;
            FilesystemType = fileSystemType;
            DriveType = driveType;
        }
    }
}
