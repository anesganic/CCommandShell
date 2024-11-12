using System;
using Xunit;
using Moq;
using CCommandShell.Interfaces;
using CCommandShell.Commands;

namespace CCommandShellTest
{
    [TestClass]
    public class VerCommandTests
    {
        [TestMethod]
        public void GivenVerCommand_WhenExecuted_ShouldWriteOSVersionToOutput()
        {
            // Given
            var mockOutputWriter = new Mock<ICommandOutputWriter>();
            var verCommand = new VerCommand(mockOutputWriter.Object);

            // When
            verCommand.Execute();

            // Then
            var osVersion = Environment.OSVersion.Version.ToString();
            var expectedOutput = $"OS Version: {osVersion}";

            mockOutputWriter.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains(expectedOutput))),
                Times.Once, "Expected OS version output was not written.");
        }

    }
}
