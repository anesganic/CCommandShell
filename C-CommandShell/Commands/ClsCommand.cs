using System;
using System.Collections.Generic;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class ClsCommand : ICommand
    {
        public List<string> Parameters { get; set; } = new List<string>();

        public ShellEnvironment ShellEnvironment { get; set; }

        public void Execute()
        {
            Console.Clear();
        }
    }
}
