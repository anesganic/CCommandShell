using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    internal class CdCommand
    {
        public List<String> Parameters { get; set; }
        public CommandContent Content { get; set; }
        public ShellEnvironment Environment { get; set; }
        public CdCommand()
        {
            Content = new CommandContent();
            Parameters = new List<String>();
            Environment = new ShellEnvironment();
        }

        public void Execute()
        {
            if(Content.Parameters.Count >= 0)
            {
                string path = Content.Parameters[0].ToString();

            }
        }
    }
}
