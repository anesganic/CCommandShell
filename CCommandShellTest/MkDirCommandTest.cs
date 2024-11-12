using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCommandShell;
using CCommandShell.Filesystem;
using CCommandShell.Commands;

namespace CCommandShellTest
{
    [TestClass]
    public class MkDirCommandTest
    {
        [TestMethod]
        public void GivenValidDirectoryName_WhenExecute_ThenDirectoryShouldBeCreated()
        {
            // Given
            ShellEnvironment shellEnvironment = new ShellEnvironment();
            TestCommandOutputWriter outputWriter = new TestCommandOutputWriter();
            MkDirCommand command = new MkDirCommand(outputWriter);
            command.CommandContent.ShellEnvironment = shellEnvironment;
            command.CommandContent.Parameters = new List<string> { "NewDirectory" };

            string expectedDirectoryName = "NewDirectory";

            // When
            command.Execute();

            // Then
            Assert.IsTrue(shellEnvironment.CurrentDirectory.FilesystemItems.Any(item => item.Name == expectedDirectoryName), "Das Verzeichnis wurde nicht korrekt erstellt.");
        }

    }
}
