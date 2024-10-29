using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Filesystem;

namespace CCommandShell.Filesystem
{
    public class Directory : FilesystemItem
    {
        public List<FilesystemItem> Items { get; set; } = new List<FilesystemItem>();

		public Directory() { }
		public Directory(Directory DirBefore)
        {
            this.DirectoryBefore = DirBefore;
        }

        public Directory(List<FilesystemItem> items, string name, DateTime craeateDate)
        {
            Items = items;
            Name = name;
            CreateDate = craeateDate;
        }

    }
}
