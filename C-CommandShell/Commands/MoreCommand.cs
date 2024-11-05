using CCommandShell;
using CCommandShell.Filesystem;
using CCommandShell.Interfaces;


namespace CCommandShell.Commands
{
    public class MoreCommand : ICommand
    {
        public CommandContent CommandContent { get; set; } = new CommandContent();


        public MoreCommand()
        {
            CommandContent.OutputWriter = new CommandOutputWriter();
        }


        public void Execute()
        {
            if (CommandContent.Parameters != null && CommandContent.Parameters.Count > 0)
            {
                string fileName = CommandContent.Parameters[0];
                Filesystem.File file = null;

                foreach (FilesystemItem filesystemItem in CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems)
                {
                    if (filesystemItem.Name == fileName && filesystemItem is Filesystem.File)
                    {
                        file = (Filesystem.File)filesystemItem;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("File can't be found.");
                    }

                }

                if (file != null)
                {
                    CommandContent.OutputWriter.WriteLine($"Content for {fileName}");
                    int chunkSize = 50;
                    int currentId = 0;

                    CommandContent.OutputWriter.WriteLine(
                        file.FileContent.Substring(currentId, Math.Min(chunkSize, file.FileContent.Length - currentId)));
                    currentId += chunkSize;

                    while (currentId < file.FileContent.Length)
                    {
                        CommandContent.OutputWriter.WriteLine("tap space for more");
                        if (Console.ReadKey().KeyChar != ' ')
                        {
                            break;
                        }
                    }


                }



            }
            else { CommandContent.OutputWriter.WriteLine("Parameters are null or empty."); }
        }
    }
}
