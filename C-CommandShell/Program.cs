using CCommandShell;

namespace DemoliShell
{
    class Programm
    {
        private CommandShell commandShell;
        static void Main(string[] args)
        {
            CommandShell shell = new CommandShell();
            shell.Run();
        }
    }
}