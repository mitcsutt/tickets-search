using System;
using System.Linq;
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

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Search for the values");
				var command = Console.ReadLine();
				var commandSplit = command.Split(" ");

				if (commandSplit.Length == 1)
				{
                    switch (commandSplit[0])
                    {
						case "q":
							Console.WriteLine("Exiting");
							return;
					}
				}
				if (commandSplit.Length > 3)
				{
					var input = $"{commandSplit[0]} {commandSplit[1]}";
					var keyword = string.Join(" ", commandSplit.Skip(3));
					var searchResults = new List<string>();
					switch (input)
					{
						case "search organization":
							var organizationPropertyTypes = typeof(Organization).GetProperties().Select(property => property.Name);
                            if (organizationPropertyTypes.Contains(commandSplit[2]))
                            {
								searchResults = keyword.SearchOrganizations(
									commandSplit[2],
									organizations,
									organizationDictionary
								);
							}
                            else
                            {
								Console.WriteLine("Invalid organization property name");
								continue;
							}
							break;
						case "search user":
							var userPropertyTypes = typeof(User).GetProperties().Select(property => property.Name);
							if (userPropertyTypes.Contains(commandSplit[2]))
							{
								searchResults = keyword.SearchUsers(
									commandSplit[2],
									users,
									userDictionary
								);
							}
							else
							{
								Console.WriteLine("Invalid user property name");
								continue;
							}
							break;
						case "search ticket":
							var ticketPropertyTypes = typeof(Ticket).GetProperties().Select(property => property.Name);
							if (ticketPropertyTypes.Contains(commandSplit[2]))
							{
								searchResults = keyword.SearchTickets(
									commandSplit[2],
									tickets,
									ticketDictionary
								);
							}
							else
							{
								Console.WriteLine("Invalid ticket property name");
								continue;
							}
							break;
					}
					if (searchResults.Count > 0)
					{
						searchResults.ForEach(searchResult => Console.WriteLine(searchResult));
					}
					else
					{
						Console.WriteLine("No search results");
					}
				}

				//switch (commandSplit[0])
				//{
				//	case "search":
				//		if (commandSplit.Length < 3)
				//		{
				//			Console.WriteLine("Invalid search value");
				//			continue;
				//		}
				//		var searchResults = new List<string>();
				//		var keyword = string.Join(" ", commandSplit.Skip(2));
				//		switch (commandSplit[1])
				//		{
				//			case "organization":
				//				var properties = new Organization().GetType().GetProperties().Select(property => property.Name).ToList();
				//				searchResults = keyword.SearchOrganizations(
				//					organizations,
				//					organizationDictionary
				//				);
				//				break;
				//			case "user":
				//				searchResults = keyword.SearchUsers(
				//					users,
				//					userDictionary
				//				);
				//				break;
				//			case "ticket":
				//				searchResults = keyword.SearchTickets(
				//					tickets,
				//					ticketDictionary
				//				);
				//				break;
				//			default:
				//				Console.WriteLine("Invalid entity to search on. Available options are 'organization', 'user' and 'ticket'");
				//				continue;
				//		}
				//		if (searchResults.Count > 0)
				//		{
				//			searchResults.ForEach(searchResult => Console.WriteLine(searchResult));
				//		}
				//		else
				//		{
				//			Console.WriteLine("No search results");
				//		}
				//		Console.WriteLine();
				//		break;
				//	default:
				//		Console.WriteLine("Invalid command line argument");
				//		continue;
				//}
			}
		}
	}
}
