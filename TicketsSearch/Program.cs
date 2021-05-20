using System;
using System.Collections.Generic;
using System.IO;
using TicketsSearch.Utilities;
using TicketsSearch.Models;
using TicketsSearch.Services;

namespace TicketsSearch
{
	class Program
	{
		static void Main(string[] args)
		{
			string jsonOrganizations = File.ReadAllText("Data/organizations.json");
			List<Organization> organizations = jsonOrganizations.Deserialise<Organization>();

			string jsonUsers = File.ReadAllText("Data/users.json");
			List<User> users = jsonUsers.Deserialise<User>();

			string jsonTickets = File.ReadAllText("Data/tickets.json");
			List<Ticket> tickets = jsonTickets.Deserialise<Ticket>();

			var (organizationDictionary, userDictionary, ticketDictionary) =
				ToDictionariesUtilities.ToDictionaries(organizations, users, tickets);
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
							var searchResults = commandSplit[1].Search(
								organizations,
								users,
								tickets,
								organizationDictionary,
								userDictionary,
								ticketDictionary
							);
							if(searchResults.Count > 0)
                            {
								searchResults.ForEach(searchResult => Console.WriteLine(searchResult));
							}
							else
                            {
								Console.WriteLine("No search results");
							}

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
