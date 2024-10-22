using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C_CommandShell
{
    internal class CommandFactory
    {
        public List<Type> commands;
        public ICommand CreateCommand (Type type)
        {
			//Search and instance (ChatGpt)
			var commandType = commands.FirstOrDefault(t => t == type); return commandType != null ?
            Activator.CreateInstance(commandType) as ICommand : null;
		}


        public List<Type> GetCommands()
        {
            return commands;
        }

        public List<Type> LoadCommands()
        {
            // Find types from ICommand 
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly  => assembly.GetTypes())
                .Where(type => typeof (ICommand).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract) 
                .ToList();
        }
        
    }
}
