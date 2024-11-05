using CCommandShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShellTest
{
    public class TestCommandOutputWriter : ICommandOutputWriter
    {
        public TestCommandOutputWriter() { }

        public ConsoleColor ForegroundColor { get; set; }

        public void Write(string text)
        {

        }

        public void WriteLine(string text)
        {

        }

        public void Clear()
        {

        }

        public void SetCurrentDirectory(string path)
        {

        }

        public void Move(string sourcePath, string destinationPath)
        {

        }
    }
}
