using System;

namespace TicketsSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search for the values");

            var open = true;
            while (open)
            {
                var command = Console.ReadLine();
                var commandSplit = command.Split(" ");
                if(commandSplit.Length > 1)
                {
                    switch (commandSplit[0])
                    {
                        case "search":
                            Console.WriteLine("Correct value");
                            break;
                        default:
                            Console.WriteLine("Invalid command line argument");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
