using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Interfaces
{
	public interface ICommand
	{
		public CommandContent CommandContent { get; set; }

		 void Execute();
	}
}
