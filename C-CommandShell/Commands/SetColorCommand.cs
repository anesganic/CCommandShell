﻿using System;
using System.Collections.Generic;
using CCommandShell.Interfaces;

namespace CCommandShell.Commands
{
    public class SetColorCommand : ICommand
    {
        public List<string> Parameters { get; set; } = new List<string>();
        public ShellEnvironment ShellEnvironment { get; set; }

        public void Execute()
        {
            // Check for no parameters
            if (Parameters.Count == 0)
            {
                Console.WriteLine("Please specify a color for the text or background.");
                return;
            }

            foreach (var param in Parameters)
            {
                var parts = param.ToLower().Split(':');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid parameter format. Use 'foreground:<color>' or 'background:<color>'.");
                    return;
                }

                if (!Enum.TryParse(typeof(ConsoleColor), parts[1].Trim(), true, out var color))
                {
                    Console.WriteLine($"Invalid color '{parts[1]}'. Available colors are: " +
                                      string.Join(", ", Enum.GetNames(typeof(ConsoleColor))));
                    return;
                }

                switch (parts[0].Trim())
                {
                    case "foreground":
                        Console.ForegroundColor = (ConsoleColor)color;
                        Console.WriteLine($"Foreground color changed to {color}.");
                        break;
                    case "background":
                        Console.BackgroundColor = (ConsoleColor)color;
                        Console.Clear(); // Clear to apply background change
                        Console.WriteLine($"Background color changed to {color}.");
                        break;
                    default:
                        Console.WriteLine($"Invalid color type '{parts[0]}'. Use 'foreground' or 'background'.");
                        return;
                }
            }
        }
    }
}