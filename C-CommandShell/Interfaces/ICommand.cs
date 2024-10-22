using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Interfaces
{
	internal interface ICommand
	{
		public List<String> Parameters { get; set; }
		public ShellEnvironment ShellEnvironment { get; set; }

		public void Execute();
	}
}
