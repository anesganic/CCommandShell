
namespace CCommandShell.Interfaces
{
	public interface ICommand
	{
		public CommandContent Content { get; set; }

		public void Execute();
	}
}
