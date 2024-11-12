using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCommandShell.Commands;
using CCommandShell.Interfaces;

namespace CCommandShell
{
    public class CommandFactory
    {
        public static List<Type> commands = LoadCommands();

        public static ICommand? CreateCommand(Type type)
        {

            var command = commands.FirstOrDefault(t => t == type) != null
                ? Activator.CreateInstance(type) as ICommand
                : null;

            if (command == null)
            {
                Console.WriteLine($"Error: Could not create command for type {type.Name}");
            }

            return command;
        }



        public static List<Type> GetCommands()
        {
            return commands;
        }

        public static List<Type> LoadCommands()
        {

            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();
        }
        
    }
}
