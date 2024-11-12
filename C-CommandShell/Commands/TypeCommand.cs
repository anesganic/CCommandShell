using System;
using System.Linq;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class TypeCommand : ICommand
    {
        public CommandContent CommandContent { get; set; } = new CommandContent();

        // Constructor with default or custom output writer
        public TypeCommand() : this(new CommandOutputWriter()) { }

        public TypeCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent.OutputWriter = commandOutputWriter;
        }

        // Execute the command
        public void Execute()
        {
            if (CommandContent.Parameters.Count != 1)
            {
                CommandContent.OutputWriter.WriteLine("Usage: Type <FileName>");
                return;
            }

            var fileName = CommandContent.Parameters[0];
            var fileToDisplay = CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems
                .OfType<Filesystem.File>()
                .FirstOrDefault(item => item.Name == fileName);

            if (fileToDisplay != null)
            {
                // Display the content of the file
                CommandContent.OutputWriter.WriteLine($"File Content for '{fileName}':");
                CommandContent.OutputWriter.WriteLine(fileToDisplay.FileContent);
            }
            else
            {
                CommandContent.OutputWriter.WriteLine($"File '{fileName}' not found.");
            }
        }
    }
}
