using CCommandShell.Filesystem;
using CCommandShell.Persistency;

namespace CCommandShell
{
    public class ShellEnvironment
    {
        public Drive Drive { get; }
        public Filesystem.Directory CurrentDirectory { get; set; }
        public PathHandler PathHandler { get; } = new PathHandler();

        public ShellEnvironment()
        {
            Drive = PersistencyService.Load();
            CurrentDirectory = Drive.RootDirectory;
        }

        public string GetFullPath() => PathHandler.GetFullPath(CurrentDirectory, Drive);
    }
}
