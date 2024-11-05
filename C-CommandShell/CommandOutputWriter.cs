using CCommandShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell
{
    public class CommandOutputWriter : ICommandOutputWriter
    {
        public ConsoleColor ForegroundColor
        {
            get { return Console.ForegroundColor; }
            set
            {
                Console.ForegroundColor = value;
            }
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void SetCurrentDirectory(string path)
        {

        }

        public void Move(string sourcePath, string destinationPath)
        {
            Directory.Move(sourcePath, destinationPath);
        }
    }
}
