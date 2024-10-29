using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Filesystem
{
    public abstract class FilesystemItem
    {
        public string Name;
        public double Size;
        public DateTime CreateDate;
        public Directory DirectoryBefore;

    }
}
