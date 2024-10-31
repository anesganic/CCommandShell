using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCommandShell.Interfaces
{
    public interface ICommandOutputWriter
    {
        ConsoleColor ForegroundColor { get; set; }
        void Write(string text);
        void WriteLine(string text);
        void Clear();
        void SetCurrentDirectory(string path);
        void Move(string sourcePath, string destinationPath);
    }
}
