namespace DemoliShell
{
    internal class CommandShell
    {
        private CommandParser commandParser;
        private CommandInvoker commandInvoker;
        private ShellWorkspace shellWorkspace;

        public CommandShell()
        {
            commandParser = new CommandParser();
            commandInvoker = new CommandInvoker();
            shellWorkspace = new ShellWorkspace();
        }

        public void Run()
        {
            do
            {
                ShowInterface();
                string userInput = Console.ReadLine();
                ProcessInput(userInput);
            } while (true);
        }

        public void ShowInterface()
        {
            Console.Write(shellWorkspace.GetFullPath() + " > ");
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void ProcessInput(string userInput)
        {
            Type type = commandParser.GetCommand(userInput); // The correct GetCommand method should be used here.
            List<string> parameters = commandParser.GetParameter(userInput);

            if (type != null)
            {
                commandInvoker.ExecuteCommand(type, parameters, shellWorkspace);
            }
            else
            {
                Console.WriteLine("Unknown command, type `Help` for a list of all commands!");
                Console.WriteLine("");
            }
        }
    }

    // Ensure there is no duplicate definition for these classes in the same namespace
    internal class CommandParser
    {
        public Type GetCommand(string input)
        {
            // Logic to determine and return the command type based on the input
            return null;
        }

        public List<string> GetParameter(string input)
        {
            // Logic to extract parameters from the input command
            return new List<string>();
        }
    }

    internal class CommandInvoker
    {
        public void ExecuteCommand(Type commandType, List<string> parameters, ShellWorkspace workspace)
        {
            // Logic to execute the command based on type and parameters
        }
    }

    internal class ShellWorkspace
    {
        public string GetFullPath()
        {
            // Logic to return the current path or workspace information
            return "C:\\";
        }
    }
}
