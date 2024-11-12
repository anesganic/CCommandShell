using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCommandShell;
using CCommandShell.Filesystem;
using CCommandShell.Commands;

namespace CCommandShellTest
{
    [TestClass]
    public class DelCommandTest
    {
        [TestMethod]
        public void GivenDirectoryWithSubdirectory_WhenDeleteSubdirectory_ThenSubdirectoryShouldBeRemoved()
        {
            // Given
            ShellEnvironment ShellEnvironment = new ShellEnvironment();

            CCommandShell.Filesystem.Directory subDir = new CCommandShell.Filesystem.Directory
            {
                ParentDirectory = ShellEnvironment.CurrentDirectory,
                Name = "subDir"
            };
            ShellEnvironment.CurrentDirectory.FilesystemItems.Add(subDir);

            DelCommand command = new DelCommand(new TestCommandOutputWriter());
            command.CommandContent.ShellEnvironment = ShellEnvironment;
            command.CommandContent.Parameters = new List<string> { "subDir" };

            bool expected = false; // Das Unterverzeichnis soll nach der Ausführung gelöscht sein

            // When
            command.Execute();

            // Then
            bool actual = ShellEnvironment.CurrentDirectory.FilesystemItems.Contains(subDir);
            Assert.AreEqual(expected, actual);
        }
    }
}
