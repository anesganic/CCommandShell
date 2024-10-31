using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Filesystem
{
    public abstract class FilesystemItem
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime CreateDate { get; set; }
        public Directory ParentDirectory { get; set; }

    }
}
