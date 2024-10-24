using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
	public class DirCommand : ICommand
	{
		public CommandContent Content { get; set; } = new CommandContent();
		public void Execute()
		{
			
		}
	}
}
