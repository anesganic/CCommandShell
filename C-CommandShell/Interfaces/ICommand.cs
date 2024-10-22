using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_CommandShell.Interfaces
{
	internal interface ICommand
	{
		public List<String> Parameters { get; set; }

		public void Execute();
	}
}
