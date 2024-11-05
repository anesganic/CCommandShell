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
				var sourceDir = GetDir(CommandContent.Parameters[0]);
				var destDir = GetDir(CommandContent.Parameters[1]);
					
				if (IsSubfolder(destDir, sourceDir))
				{
					CommandContent.OutputWriter.WriteLine("Destination is Subfolder of Source.");
					return;
				}

				if (IsSubfolder(sourceDir, destDir))
				{
					CommandContent.OutputWriter.WriteLine("This Directory is affected we navigate you to the Root");
					CommandContent.ShellEnvironment.CurrentDirectory = CommandContent.ShellEnvironment.Drive.RootDirectory;
				}

				MoveDirectory(sourceDir, destDir);
			}
		}

		private Filesystem.Directory GetDir(string path)
		{
			return CommandContent.ShellEnvironment.PathHandler.GetDirectory(path, CommandContent.ShellEnvironment.CurrentDirectory, CommandContent.ShellEnvironment.Drive);
		}

		private bool IsSubfolder(Filesystem.Directory destdir, Filesystem.Directory sourcedir)
		{
			var dir = destdir;
			while (dir.ParentDirectory != null)
			{
				if (dir.ParentDirectory == sourcedir) { return true; }
				dir = dir.ParentDirectory;
			}
			return false;
		}

		private bool IsAffectedByMove(Filesystem.Directory sourcedir, Filesystem.Directory destdir)
		{
			var currentDir = CommandContent.ShellEnvironment.CurrentDirectory;
			if (sourcedir == currentDir || destdir == currentDir || destdir == sourcedir) return false;

			var fileName = sourcedir.Name;
			var dir = currentDir;
			while (dir.ParentDirectory != null)
			{
				if (dir.ParentDirectory.Name == fileName) { return true; }
				dir = dir.ParentDirectory;
			}

			sourcedir.ParentDirectory?.FilesystemItems.Remove(sourcedir);
			return false;
			
		}

		private void MoveDirectory(Filesystem.Directory sourceDir, Filesystem.Directory destDir)
		{
			sourceDir.ParentDirectory?.FilesystemItems.Remove(sourceDir);
			sourceDir.ParentDirectory = destDir;
			destDir.FilesystemItems.Add(sourceDir);
		}

	}
}
