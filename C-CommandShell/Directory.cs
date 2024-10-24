using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell
{
    public class Directory : SystemItem
    {
        public List<SystemItem> Items {  get; set; } = new List<SystemItem>();
        public Directory(Directory DirBefore) 
        {
            this.DirBefore = DirBefore;
        }

        public Directory(List<SystemItem> items, string name, DateTime craeateDate) 
        {
            this.Items = items; 
            this.Name = name;
            this.CreateDate = craeateDate;
        }

    }
}
