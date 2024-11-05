using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CCommandShell;
using CCommandShell.Interfaces;

namespace CCommandShell
{
    public class CommandContent
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }
     		public ShellEnvironment ShellEnvironment { get;  set; }

      
		public CommandContent() 
        { 
            Parameters = new List<string>();
        }
    }
}
