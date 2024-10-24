using CCommandShell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CCommandShell
{
    public class CommandParser
    {
        private readonly List<Type> commands;
        private readonly CommandFactory commandFactory;

        public CommandParser()
        {
            commandFactory = new CommandFactory();
            commands = CommandFactory.GetCommands();
        }

        public Type GetCommand(string input)
        {
            string commandInUserInput = input.Split(' ').FirstOrDefault()?.ToLower();

            return commands.FirstOrDefault(type => type.Name.Equals(commandInUserInput + "Command", StringComparison.OrdinalIgnoreCase));
        }


        public List<string> GetParameters(string input)
        {
            var parameters = input.Split(' ').Skip(1).ToList();

            return parameters.Any() ? parameters : null;
        }
    }
}
