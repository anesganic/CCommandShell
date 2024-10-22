using C_CommandShell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C_CommandShell
{
    internal class CommandParser
    {
        private readonly List<Type> commands;
        private readonly CommandFactory commandFactory;

        public CommandParser()
        {
            commandFactory = new CommandFactory();
            commands = commandFactory.LoadCommands();
        }

        public Type GetCommand(string input)
        {
            string commandInUserInput = input.Split(' ').FirstOrDefault()?.ToLower() + "command";

            return commands.FirstOrDefault(type => type.Name.Equals(commandInUserInput, StringComparison.OrdinalIgnoreCase));
        }

        public List<string> GetParameters(string input)
        {
            var parameters = input.Split(' ').Skip(1).ToList();

            return parameters.Any() ? parameters : null;
        }
    }
}
