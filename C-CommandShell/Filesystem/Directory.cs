using CCommandShell.Filesystem;
using CCommandShell.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CCommandShell.Filesystem
{
    public class Directory : FilesystemItem
    {
        PersistencyService persistencyService { get; set; } = new PersistencyService();
        public PersistencyService PersistencyService { get; set; }
        public List<FilesystemItem> FilesystemItems { get; set; } = new List<FilesystemItem> { };


        public Directory() { }
        public Directory(Directory parentDirectory)
        {
            ParentDirectory = parentDirectory;
        }

        public Directory(string name, DateTime createdOn, List<FilesystemItem> filesystemItems)
        {
            Name = name;
            CreateDate = createdOn;
            FilesystemItems = filesystemItems;
        }

        public Directory Clone() { return (Directory)this.MemberwiseClone(); }

    }
}
