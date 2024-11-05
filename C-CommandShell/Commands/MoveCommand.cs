using CCommandShell.Filesystem;
using CCommandShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Commands
{
	public class MoveCommand : ICommand
	{
		public CommandContent CommandContent { get; set; } = new CommandContent();

		// Constructor
		public MoveCommand()
		{
			CommandContent.OutputWriter = new CommandOutputWriter();
		}

		public MoveCommand(ICommandOutputWriter commandOutputWriter)
		{
			CommandContent.OutputWriter = commandOutputWriter;
		}

		public void Execute()
		{
			if (CommandContent.Parameters != null && CommandContent.Parameters.Count > 0)
			{
				// Get path of source directory
				string sourcePath = CommandContent.Parameters[0];
				Filesystem.Directory sourceDir = CommandContent.ShellEnvironment.PathHandler.GetDirectory(sourcePath, CommandContent.ShellEnvironment.CurrentDirectory, CommandContent.ShellEnvironment.Drive);

				// Get path of destination directory
				string destinationPath = CommandContent.Parameters[1];
				Filesystem.Directory destinationDir = CommandContent.ShellEnvironment.PathHandler.GetDirectory(destinationPath, CommandContent.ShellEnvironment.CurrentDirectory, CommandContent.ShellEnvironment.Drive);
				Filesystem.Directory destinationDirClone = destinationDir.Clone();

				while (destinationDirClone.ParentDirectory != null)
				{
					if (destinationDirClone.ParentDirectory == sourceDir)
					{
						return;
					}
					// Move to the next parent directory
					destinationDirClone = destinationDirClone.ParentDirectory;
				}
			}
		}

	}
}
