using System;
using Xunit;
using Moq;
using CCommandShell.Interfaces;
using CCommandShell.Commands;

namespace CCommandShell.Tests
{
    public class VerCommandTests
    {
        [Fact]
        public void Execute_ShouldWriteOSVersionToOutput()
        {
            // Arrange
            var mockOutputWriter = new Mock<ICommandOutputWriter>();
            var verCommand = new VerCommand(mockOutputWriter.Object);

            // Act
            verCommand.Execute();

            // Assert
            var osVersion = Environment.OSVersion.Version.ToString();
            var expectedOutput = $"OS Version: {osVersion}";

            mockOutputWriter.Verify(m => m.WriteLine(It.Is<string>(s => s.Contains(expectedOutput))),
                Times.Once, "Expected OS version output was not written.");
        }
    }
}
