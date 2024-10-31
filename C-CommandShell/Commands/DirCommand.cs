using System;
using System.Collections.Generic;
using CCommandShell.Interfaces;
using CCommandShell;

namespace CCommandShell.Commands
{
    public class DirCommand : ICommand
    {
        public CommandContent CommandContent { get; set; }

        public DirCommand() : this(new CommandOutputWriter()) { }

        public DirCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent = new CommandContent { OutputWriter = commandOutputWriter };
        }

        public void Execute()
        {
            long totalDirSize = 0;
            long totalFileSize = 0;
            int dirCount = 0;
            int fileCount = 0;

            var drive = CommandContent.ShellEnvironment.Drive;
            var currentDirectory = CommandContent.ShellEnvironment.CurrentDirectory;
            var outputWriter = CommandContent.OutputWriter;

            outputWriter.WriteLine($"Volume in {drive.Name} is {drive.Label}");
            outputWriter.WriteLine($"Type: {drive.DriveType}\n");
            outputWriter.WriteLine($"Directory of {currentDirectory.Name}\n");

            foreach (var item in currentDirectory.FilesystemItems)
            {
                string itemType = item is Filesystem.Directory ? "<dir>" : item.Size.ToString();
                outputWriter.WriteLine($"{item.CreateDate,-30} {itemType,-10} {item.Name,-20}");

                if (item is Filesystem.Directory)
                {
                    totalDirSize += (long)item.Size;
                    dirCount++;
                }
                else
                {
                    totalFileSize += (long)item.Size;
                    fileCount++;
                }
            }

            outputWriter.WriteLine($"{fileCount} File(s)".PadLeft(45) + $"{totalFileSize} bytes used".PadLeft(15));
            outputWriter.WriteLine($"{dirCount} Dir(s)".PadLeft(45) + $"{totalDirSize} bytes used".PadLeft(15));
        }
    }
}
