using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_CommandShell.Filesystem;

namespace CCommandShell.Filesystem
{
    public class Directory : FilesystemItem
    {
        public List<FilesystemItem> Items { get; set; } = new List<FilesystemItem>();
        public Directory(Directory DirBefore)
        {
            this.DirBefore = DirBefore;
        }

        public Directory(List<FilesystemItem> items, string name, DateTime craeateDate)
        {
            Items = items;
            Name = name;
            CreateDate = craeateDate;
        }

    }
}
