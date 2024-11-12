using System;
using System.Collections.Generic;
using CCommandShell.Filesystem;
using CCommandShell.Interfaces;
using CCommandShell.Persistency;
using Directory = CCommandShell.Filesystem.Directory;
using File = CCommandShell.Filesystem.File;

namespace CCommandShell.Commands
{
    public class TouchCommand : ICommand
    {
        public CommandContent CommandContent { get; set; }

        public PersistencyService PersistencyService { get; set; }

        // Constructor that initializes the OutputWriter
        public TouchCommand() : this(new CommandOutputWriter()) { }

        public TouchCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent = new CommandContent
            {
                OutputWriter = commandOutputWriter
            };
        }

        // Adds an item to the current directory
        private void AddFilesystemItem(FilesystemItem item) =>
            CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems.Add(item);

        // Checks if a file already exists in the current directory
        private bool FileExists(string fileName) =>
            CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems
                .OfType<Filesystem.File>()
                .Any(file => file.Name == fileName);

        // Ensures the file has a .txt extension
        private string EnsureTxtExtension(string fileName)
        {
            if (!fileName.EndsWith(".txt"))
            {
                CommandContent.OutputWriter.WriteLine("File must have a .txt extension.");
                return null; 
            }
            return fileName; // Return fileName with .txt extension
        }

        // Creates a file with the specified content
        private void CreateFileWithContent(string fileName, string content)
        {
            // Ensure the file has a .txt extension
            var validFileName = EnsureTxtExtension(fileName);
            if (validFileName == null) return; // If the file name was invalid, exit early

            // Check if the file already exists
            if (FileExists(validFileName))
            {
                CommandContent.OutputWriter.WriteLine($"The file '{validFileName}' already exists.");
                return;
            }

            // Create the file and set its content
            var newFile = new Filesystem.File
            {
                Name = validFileName,
                FileContent = content,
                CreateDate = DateTime.Now,
                ParentDirectory = CommandContent.ShellEnvironment.CurrentDirectory
            };

            // Add the new file to the current directory
            AddFilesystemItem(newFile);
            CommandContent.OutputWriter.WriteLine($"File '{validFileName}' has been created with the specified content.");
        }

        public void Execute()
        {
            if (CommandContent.Parameters.Count > 0)
            {
                var fileName = CommandContent.Parameters[0];
                var content = CommandContent.Parameters.Count > 1
                    ? string.Join(" ", CommandContent.Parameters.Skip(1))
                    : ""; // If no content is provided, use an empty string

                CreateFileWithContent(fileName, content);
            }
            else
            {
                CommandContent.OutputWriter.WriteLine("No file name provided.");
            }
        }
    }
}

