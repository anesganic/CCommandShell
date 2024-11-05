using System;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class ExitCommand : ICommand
    {
        public CommandContent CommandContent { get; set; }

        // Constructors
        public ExitCommand() : this(new CommandOutputWriter()) { }

        public ExitCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent = new CommandContent { OutputWriter = commandOutputWriter };
        }

        // Execute method to exit the application
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
