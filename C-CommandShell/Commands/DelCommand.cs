using System;
using CCommandShell.Filesystem;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class DelCommand : ICommand
    {
        public CommandContent CommandContent { get; set; } = new CommandContent();

        // Constructors
        public DelCommand() : this(new CommandOutputWriter()) { }

        public DelCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent.OutputWriter = commandOutputWriter;
        }

        public void Execute()
        {
            if (CommandContent.Parameters == null || CommandContent.Parameters.Count == 0)
            {
                CommandContent.OutputWriter.WriteLine("Parameters are null or empty.");
                return;
            }

            string filepath = CommandContent.Parameters[0];
            var shellEnvironment = CommandContent.ShellEnvironment;
            var currentDir = shellEnvironment?.CurrentDirectory;
            var targetDir = shellEnvironment?.PathHandler.GetDirectory(filepath, currentDir, shellEnvironment.Drive);

            if (targetDir == null || targetDir.ParentDirectory == null)
            {
                CommandContent.OutputWriter.WriteLine("Specified directory or file not found.");
                return;
            }

            // If the current directory is affected by this deletion, relocate to the root
            if (IsCurrentDirectoryAffected(targetDir))
            {
                CommandContent.OutputWriter.WriteLine("Your current Directory is affected by this change, you will be relocated to the root Directory!");
                shellEnvironment.CurrentDirectory = shellEnvironment.Drive.RootDirectory;
            }

            // Remove the item if it exists
            bool itemDeleted = DeleteItem(targetDir);

            if (itemDeleted)
            {
                CommandContent.OutputWriter.WriteLine("The File has been deleted!");
            }
            else
            {
                CommandContent.OutputWriter.WriteLine("Specified file not found in the directory.");
            }
        }

        // Helper method to check if the current directory or its parents are affected
        private bool IsCurrentDirectoryAffected(CCommandShell.Filesystem.Directory targetDir)
        {
            var current = CommandContent.ShellEnvironment.CurrentDirectory;
            while (current != null)
            {
                if (current == targetDir) return true;
                current = current.ParentDirectory;
            }
            return false;
        }

        // Helper method to delete the item from the parent directory's items
        private bool DeleteItem(CCommandShell.Filesystem.Directory targetDir)
        {
            var parentDir = targetDir.ParentDirectory;
            var itemToDelete = parentDir?.FilesystemItems.FirstOrDefault(item => item.Name == targetDir.Name);

            if (itemToDelete != null)
            {
                parentDir.FilesystemItems.Remove(itemToDelete);
                return true;
            }

            return false;
        }
    }
}
