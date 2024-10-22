using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Interfaces;

namespace CCommandShell
{
    internal class CommandFactory
    {
        public static List<Type> commands = LoadCommands();

        public static ICommand? CreateCommand (Type type)
        {
            //Search and instance (ChatGpt)
            return commands.FirstOrDefault(t => t == type) != null
            ? Activator.CreateInstance(type) as ICommand
            : null;
        }


        public static List<Type> GetCommands()
        {
            return commands;
        }

        public static List<Type> LoadCommands()
        {
            // Find types from ICommand 

            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic) // Nur geladene Assemblies durchsuchen, die nicht dynamisch sind
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();
        }
        
    }
}
