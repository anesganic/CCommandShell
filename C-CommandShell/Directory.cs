using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell
{
    internal class Directory
    {
        public String Name;
        public double Size;
        public DateTime CreateDate;
        public Directory DirBefore;

        public Directory() { }
        public Directory(Directory DirBefore, String Name, double Size, DateTime CreateDate)
        {
            this.DirBefore = DirBefore;
            this.Name = Name;
            this.Size = Size;
            this.CreateDate = CreateDate;
        }
    }
}
