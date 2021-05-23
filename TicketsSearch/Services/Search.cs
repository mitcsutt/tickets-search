using System.Collections.Generic;
using System.Linq;
using TicketsSearch.Models;
namespace TicketsSearch.Services
{
	public static class SearchService
	{

		public static bool KeywordMatches(this object value, string keyword)
		{
			if(value is string @string)
            {
				return @string == keyword;
			}
			if (value is int @int)
			{
				return @int.ToString() == keyword;
			}
			if (value is bool @bool)
			{
				return @bool.ToString().ToLower() == keyword;
			}
			if (value is List<string> @list)
			{
				return @list.Contains(keyword);
			}
			return false;
		}

		public static List<string> SearchOrganizations(
			this string keyword,
			string property,
			List<Organization> organizations,
			Dictionary<int, OrganizationDictionaryValues> organizationDictionary
		)
		{
			var searchResults = new List<string>();
			var foundOrganizations = organizations.FindAll(organization => organization[property].KeywordMatches(keyword));
			if (foundOrganizations.Count > 0)
			{
				searchResults.Add($"Matching organizations({foundOrganizations.Count}):");
				searchResults.Add("----------------------------");
				foundOrganizations.ForEach(org =>
				{
					var organization = organizationDictionary[org.Id];
					searchResults.Add($"\"{organization.Entity.Name}\"");
					if (organization.Tickets.Count > 0)
					{
						searchResults.Add($"*** Linked tickets({organization.Tickets.Count}):");
						organization.Tickets.ForEach(ticket =>
						{
							searchResults.Add($"  - \"{ticket.Subject}\"");
						});
					}
					if (organization.Users.Count > 0)
					{
						searchResults.Add($"*** Linked users({organization.Users.Count}):");
						organization.Users.ForEach(user =>
						{
							searchResults.Add($"  - \"{user.Name}\"");
						});
					}
				});
			}
			return searchResults;
		}

		public static List<string> SearchUsers(
			this string keyword,
			string property,
			List<User> users,
			Dictionary<int, UserDictionaryValues> userDictionary
		)
		{
			var searchResults = new List<string>();
			var foundUsers = users.FindAll(user => user[property].KeywordMatches(keyword));

			if (foundUsers.Count > 0)
			{
				searchResults.Add($"Matching users({foundUsers.Count}):");
				searchResults.Add("----------------------------");
				foundUsers.ForEach(user =>
				{
					var currentUser = userDictionary[user.Id];
					searchResults.Add($"\"{currentUser.Entity.Name}\"");
					if (currentUser.Organizations.Count > 0)
					{
						searchResults.Add($"*** Linked organization:");
						currentUser.Organizations.ForEach(organization =>
						{
							searchResults.Add($"  - \"{organization.Name}\"");
						});
					}
					if (currentUser.SubmittedTickets.Count > 0)
					{
						searchResults.Add($"*** Submitted tickets({currentUser.SubmittedTickets.Count}):");
						currentUser.SubmittedTickets.ForEach(submittedTickets =>
						{
							searchResults.Add($"  - \"{submittedTickets.Subject}\"");
						});
					}
					if (currentUser.AssignedTickets.Count > 0)
					{
						searchResults.Add($"*** Assigned tickets({currentUser.AssignedTickets.Count}):");
						currentUser.AssignedTickets.ForEach(submittedTickets =>
						{
							searchResults.Add($"  - \"{submittedTickets.Subject}\"");
						});
					}
				});
			}

			return searchResults;
		}

		public static List<string> SearchTickets(
			this string keyword,
			string property,
			List<Ticket> tickets,
			Dictionary<string, TicketDictionaryValues> ticketDictionary
		)
		{
			var searchResults = new List<string>();
			var foundTickets = tickets.FindAll(ticket => ticket[property].KeywordMatches(keyword));

			if (foundTickets.Count > 0)
			{
				searchResults.Add($"Matching tickets({foundTickets.Count}):");
				searchResults.Add("----------------------------");
				foundTickets.ForEach(ticket =>
				{
					var currentTicket = ticketDictionary[ticket.Id];
					searchResults.Add($"\"{currentTicket.Entity.Subject}\"");
					if (currentTicket.Organizations.Count > 0)
					{
						searchResults.Add($"*** Linked organization:");
						currentTicket.Organizations.ForEach(organization =>
						{
							searchResults.Add($"  - \"{organization.Name}\"");
						});
					}
					if (currentTicket.SubmitterUsers.Count > 0)
					{
						searchResults.Add($"*** Submitted by:");
						currentTicket.SubmitterUsers.ForEach(submittedUser =>
						{
							searchResults.Add($"  - \"{submittedUser.Name}\"");
						});
					}
					if (currentTicket.AssignedUsers.Count > 0)
					{
						searchResults.Add($"*** Assigned by:");
						currentTicket.AssignedUsers.ForEach(assignedUser =>
						{
							searchResults.Add($"  - \"{assignedUser.Name}\"");
						});
					}
				});
			}

			return searchResults;
		}
	}
}
