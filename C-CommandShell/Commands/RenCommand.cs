using CCommandShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Commands
{
	public class RenCommand : ICommand
	{
		public CommandContent CommandContent { get; set; } = new CommandContent
		{
			OutputWriter = new CommandOutputWriter()
		};

		public RenCommand() { }
		public RenCommand(ICommandOutputWriter commandOutputWriter) 
		{
			CommandContent.OutputWriter = commandOutputWriter;
		}
		public void Execute()
		{
			if (CommandContent.Parameters.Count != 2) 
			{
				CommandContent.OutputWriter.WriteLine("Usage : Ren <oldName> <newName>");
				return;
			}

			string oldName = CommandContent.Parameters[0];
			string newName = CommandContent.Parameters[1];
			bool itemRenamed = false;

			var item = CommandContent.ShellEnvironment.CurrentDirectory.FilesystemItems
				.FirstOrDefault(f => f.Name.Equals(oldName));

			if (item != null) 
			{
				string newFullName = newName;
				int index = 1;

				while (CommandContent.ShellEnvironment.CurrentDirectory
					.FilesystemItems.Any(f => f.Name.Equals(newFullName)));
				{
					newFullName = $"{newName}_{index++}";
				}

				try
				{
					item.Name = newFullName;
					CommandContent.OutputWriter.WriteLine($"Renamed to {newFullName}");
					itemRenamed = true;
				}
				catch (Exception ex)
				{
					CommandContent.OutputWriter.WriteLine($"Error renaming: {ex.Message}");

				}

				if ( !itemRenamed )
				{
					CommandContent.OutputWriter.WriteLine($"File or folder '{oldName}' does not exist.");
				}
			}
			
		}
	}
}