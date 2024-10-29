using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using C_CommandShell.Filesystem;

namespace CCommandShell.Filesystem
{
    public class PathHandler
    {
        public string GetPath(Directory CurrendDir)
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

        public Directory GetDirectory(string Path, Directory CurrentDir)
        {
            Directory dir = CurrentDir;
            bool exist = false;

            string[] parts = Path.Split('\\');

            foreach (string part in parts)
            {
                if (part == "..")
                {
                    if (dir.DirBefore != null)
                    {
                        dir = dir.DirBefore;
                    }
                }
                else
                {
                    foreach (FilesystemItem item in dir.Items)
                    {
                        if (item.Name == part && item is Directory)
                        {
                            dir = (Directory)item;
                        }
                    }
                }
            }


            return dir;
        }
    }
}
