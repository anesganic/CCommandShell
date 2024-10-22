using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_CommandShell.Interfaces;

namespace C_CommandShell
{
    internal class CommandInvoker
    {
        public void ExecuteCommand(Type type, List<string> parameters)
        {
            ICommand command = CommandFactory.CreateCommand(type);
            command.Parameters = parameters;
            command.Execute();
        }
    }
}
