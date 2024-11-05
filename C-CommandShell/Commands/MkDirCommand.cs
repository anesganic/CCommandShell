using System;
using CCommandShell.Filesystem;
using CCommandShell.Interfaces;
using CCommandShell.Persistency;

namespace CCommandShell.Commands
{
    public class MkDirCommand : ICommand
    {
        public CommandContent CommandContent { get; set; }

        public PersistencyService PersistencyService { get; set; }

        public MkDirCommand() : this(new CommandOutputWriter()) { }
        public MkDirCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent = new CommandContent
            {
                OutputWriter = commandOutputWriter
            };
        }

        private void AddFilesystemItem(FilesystemItem item) =>
            CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems.Add(item);

        private bool DirectoryExists(string directoryName) =>
            CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems
                .OfType<Filesystem.Directory>()
                .Any(dir => dir.Name == directoryName);

        private void CreateDirectory(string directoryName)
        {
            var newDirectory = new Filesystem.Directory
            {
                Name = directoryName,
                CreateDate = DateTime.Now,
                ParentDirectory = CommandContent.ShellEnvironment.CurrentDirectory
            };

            AddFilesystemItem(newDirectory);
            CommandContent.OutputWriter.WriteLine($"Verzeichnis '{directoryName}' erstellt.");
        }

        public void MakeDirectory(string directoryName)
        {
            if (string.IsNullOrWhiteSpace(directoryName))
            {
                CommandContent.OutputWriter.WriteLine("Verzeichnisname darf nicht leer sein.");
                return;
            }

            if (DirectoryExists(directoryName))
            {
                CommandContent.OutputWriter.WriteLine("Das Verzeichnis existiert bereits.");
                return;
            }

            CreateDirectory(directoryName);
        }

        public void Execute()
        {
            if (CommandContent.Parameters.Count > 0)
                MakeDirectory(CommandContent.Parameters[0]);
            else
                CommandContent.OutputWriter.WriteLine("Kein Verzeichnisname angegeben.");
        }
    }
}
