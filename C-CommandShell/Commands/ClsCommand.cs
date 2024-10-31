using System;
using System.Collections.Generic;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class ClsCommand : ICommand
    {
		public CommandContent CommandContent { get; set; } = new CommandContent();

		public void Execute()
        {
            Console.Clear();
        }

	}
}
