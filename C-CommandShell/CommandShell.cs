using CCommandShell.Persistency;

namespace CCommandShell
{
    public class CommandShell
    {
        private CommandParser commandParser;
        private CommandInvoker commandInvoker;
        private ShellEnvironment shellEnvironment;

        public CommandShell()
        {
            commandParser = new CommandParser();
            commandInvoker = new CommandInvoker();
            shellEnvironment = new ShellEnvironment();
        }

        public void Run()
        {
            do
            {
                ShowInterface();
                string userInput = Console.ReadLine();
                ProcessInput(userInput);
                PersistencyService.Save(shellEnvironment.Drive);
            } while (true);
        }

        public void ShowInterface()
        {
            Console.Write(shellEnvironment.GetFullPath() + " > ");
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void ProcessInput(string userInput)
        {
            Type type = commandParser.GetCommand(userInput); // The correct GetCommand method should be used here.
            List<string> parameters = commandParser.GetParameters(userInput);

            if (type != null)
            {
                commandInvoker.ExecuteCommand(type, parameters, shellEnvironment);
            }
            else
            {
                Console.WriteLine("Unknown command, type `Help` for a list of all commands!");
                Console.WriteLine("");
            }
        }
    }

}
