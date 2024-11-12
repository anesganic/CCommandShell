using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCommandShell;
using CCommandShell.Filesystem;
using CCommandShell.Commands;

namespace CCommandShellTest
{
    [TestClass]
    public class RenCommandTest
    {
        [TestMethod]
        public void GivenDirectoryWithItem_WhenRenameItem_ThenItemShouldBeRenamed()
        {
            // Given
            ShellEnvironment shellEnvironment = new ShellEnvironment();

            var file = new CCommandShell.Filesystem.File
            {
                ParentDirectory = shellEnvironment.CurrentDirectory,
                Name = "oldName"
            };
            shellEnvironment.CurrentDirectory.FilesystemItems.Add(file);

            RenCommand command = new RenCommand(new TestCommandOutputWriter());
            command.CommandContent.ShellEnvironment = shellEnvironment;
            command.CommandContent.Parameters = new List<string> { "oldName", "testName" };

            string expected = "testName_1";

            // When
            command.Execute();

            // Then
            string actual = file.Name;
            Assert.AreEqual(expected, actual, "Das Element wurde nicht korrekt umbenannt.");
        }
    }
}
