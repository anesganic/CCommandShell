using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell
{
    internal class PathHandler
    {
        public String GetPath(Directory CurrendDir)
        {
            string path = "";
            Directory currendDir = CurrendDir;
            bool haveDirBefore = true;
            do
            {
                if (CurrendDir.DirBefore != null)
                {
                    path = "\\" + CurrendDir.Name + path;
                    currendDir = currendDir.DirBefore;
                }
                else
                {
                    path = CurrendDir.Name + path;
                    haveDirBefore = false;
                }
            }
            while (haveDirBefore == true);

            return path;





        }
    }
}
