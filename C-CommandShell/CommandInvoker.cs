using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Interfaces;

namespace CCommandShell
{
    internal class CommandInvoker
    {
        public void ExecuteCommand(Type type, List<string> parameters, ShellEnvironment shellEnvironment)
        {
            ICommand command = CommandFactory.CreateCommand(type);
            command.Parameters = parameters;
            command.ShellEnvironment = shellEnvironment;
            command.Execute();
        }
    }
}
