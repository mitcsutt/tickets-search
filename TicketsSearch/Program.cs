using System;
using System.Collections.Generic;
using System.IO;
using TicketsSearch.Extensions;
using TicketsSearch.Models;

namespace TicketsSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonOrganizations = File.ReadAllText("Data/organizations.json");
            List<Organization> organizations = jsonOrganizations.DeserializeOrganizations();
            string jsonTickets = File.ReadAllText("Data/tickets.json");
            List <Ticket> tickets = jsonTickets.DeserializeTickets();
            string jsonUsers = File.ReadAllText("Data/users.json");
            List <User> users = jsonUsers.DeserializeUsers();

            Console.WriteLine("Search for the values");

            while (true)
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
