using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Interfaces;


namespace CCommandShell.Commands
{
    public class VerCommand : ICommand
    {
        public CommandContent CommandContent { get; set; } = new CommandContent();

        //Constructor
        public VerCommand()
        {
            CommandContent.OutputWriter = new CommandOutputWriter();
        }
        public VerCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContent.OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            OperatingSystem os = Environment.OSVersion;

            CommandContent.OutputWriter.WriteLine("OS Version: " + os.Version.ToString());
        }
    }
}
