using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCommandShell; 
using CCommandShell.Filesystem;
using CCommandShell.Commands;


namespace CCommandShellTest
{
	[TestClass]
    public class CdCommandTest
    {
        [TestMethod]
        public void GivenRootDirectory_WhenCdToSubdirectoryDir_ThenCurrentDirectoryShouldBeDir()
        {
			// Given
			ShellEnvironment ShellEnvironment = new ShellEnvironment();

            CCommandShell.Filesystem.Directory dir = new CCommandShell.Filesystem.Directory
            {
                ParentDirectory = ShellEnvironment.CurrentDirectory,
                Name = "dir"
            };

            CCommandShell.Filesystem.Directory dir2 = new CCommandShell.Filesystem.Directory
            {
                ParentDirectory = dir,
                Name = "dir2"
            };
            dir.FilesystemItems.Add(dir2);

            CCommandShell.Filesystem.Directory dir3 = new CCommandShell.Filesystem.Directory
            {
                ParentDirectory = dir,
                Name = "dir3"
            };
            dir.FilesystemItems.Add(dir3);
            ShellEnvironment.CurrentDirectory.FilesystemItems.Add(dir);

            CdCommand command = new CdCommand(new TestCommandOutputWriter())
            {
                CommandContent = new CommandContent
                {
                    ShellEnvironment = ShellEnvironment,
                    Parameters = new List<string> { "dir" }
                }
            };

            CCommandShell.Filesystem.Directory expected = dir;

            // When
            command.Execute();

            // Then
            Assert.AreEqual(expected, ShellEnvironment.CurrentDirectory);
        }
    }
}
