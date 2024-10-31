using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Interfaces;
using CCommandShell;

namespace CCommandShell.Commands
{
    public class CdCommand : ICommand
    {
        public CommandContent CommandContent { get; set; } = new CommandContent();


        public CdCommand()
        {
            CommandContent.OutputWriter = new CommandOutputWriter();
        }
        public CdCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent.OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            if (CommandContent.Parameters != null && CommandContent.Parameters.Count > 0)
            {
                string path = CommandContent.Parameters[0];
                Filesystem.Directory resultDir = CommandContent.ShellEnvironment.PathHandler.GetDirectory(path, CommandContent.ShellEnvironment.CurrentDirectory, CommandContent.ShellEnvironment.Drive);

                CommandContent.ShellEnvironment.CurrentDirectory = resultDir;
            }
            else { CommandContent.OutputWriter.WriteLine("Parameters are null or empty."); }
        }
    }
}