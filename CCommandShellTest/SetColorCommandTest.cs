using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Commands;

namespace CCommandShellTest
{
    [TestClass]
    public class SetColorCommandTest
    {
        [TestMethod]
        public void SetBackgroundColorDarkblue_ExecuteSetColor_ExpectedColor_Darkblue()
        {
            // Arrange
            SetColorCommand command = new SetColorCommand();
            command.CommandContent.Parameters = new List<string>
            {
                "background:Darkyellow"
            };
            ConsoleColor expected = ConsoleColor.DarkBlue;

            // Act 
            command.Execute();

            // Assert
            Assert.AreEqual(expected, Console.ForegroundColor);
        }

        [TestMethod]
        public void SetForegroundColorYellow_ExecuteSetColor_ExpectedColor_Yellow()
        {
            // Arrange
            SetColorCommand command = new SetColorCommand();
            command.CommandContent.Parameters = new List<string>
            {
                "foreground:Darkyellow"
            };
            ConsoleColor expected = ConsoleColor.DarkYellow;

            // Act 
            command.Execute();

            // Assert
            Assert.AreEqual(expected, Console.ForegroundColor);
        }
    }
}
