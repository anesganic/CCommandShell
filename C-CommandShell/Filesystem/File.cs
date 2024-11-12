using CCommandShell.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Filesystem
{
    public class File : FilesystemItem
    {

        public string FileContent { get; set; }
        public string Extension { get; set; }


        public File() { }
        public File(Directory parentDirectory)
        {
            ParentDirectory = parentDirectory;
        }
        public File Clone() => (File)this.MemberwiseClone();
    }
}
