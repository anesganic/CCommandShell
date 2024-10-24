using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CCommandShell;

namespace CCommandShell
{
    internal class CommandContent
    {
        public List<string> Parameters { get; set; }
        public String CurrentDir { get; set; }
        public ShellEnvironment Environment { get; set; }

        public CommandContent() 
        { 
            Parameters = new List<string>();
        }
    }
}
