using System;
using System.IO;
using TicketsSearch.Extensions;
using TicketsSearch.Models;

namespace TicketsSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = File.ReadAllText("Data/organizations.json");
            Organization[] organisations = jsonString.Deserialise();
            
            Console.WriteLine("Search for the values");

            var open = true;
            while (open)
            {
                var command = Console.ReadLine();
                var commandSplit = command.Split(" ");
                if (commandSplit.Length > 1)
                {
                    switch (commandSplit[0])
                    {
                        case "search":
                            Console.WriteLine("Correct value");
                            break;
                        case "q":
                            Console.WriteLine("Correct value");
                            open = false;
                            break;
                        default:
                            Console.WriteLine("Invalid command line argument");
                            break;
                    }
                }
                else
                {
                    switch (command)
                    {
                        case "q":
                            Console.WriteLine("Exiting");
                            return;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
            }
        }
    }
}
