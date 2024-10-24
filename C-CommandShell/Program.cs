namespace CCommandShell
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