using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class CdCommand : ICommand
    {
        public CommandContent Content { get; set; } = new CommandContent();

        public void Execute()
        {
            if(Content.Parameters.Count >= 0)
            {
                string path = Content.Parameters[0].ToString();

            }
        }
    }
}
