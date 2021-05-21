using System.Collections.Generic;
using System.Linq;
using TicketsSearch.Models;
namespace TicketsSearch.Services
{
	public static class SearchService
	{
		public static List<string> SearchOrganizations(
			this string keyword,
			List<Organization> organizations,
			Dictionary<int, OrganizationDictionaryValues> organizationDictionary
		)
		{
			var searchResults = new List<string>();
			var foundOrganizations = organizations.FindAll(organization => organization.Id.ToString() == keyword
				|| organization.Url == keyword
				|| organization.ExternalId == keyword
				|| organization.Tags.Contains(keyword)
				|| organization.CreatedAt == keyword
				|| organization.Name == keyword
				|| organization.DomainNames.Contains(keyword)
				|| organization.Details == keyword
				|| organization.SharedTickets.ToString().ToLower() == keyword);
			if (foundOrganizations.Count > 0)
			{
				searchResults.Add($"{foundOrganizations.Count} matching organizations:");
				searchResults.Add("----------------------------");
				foundOrganizations.ForEach(org =>
				{
					var organization = organizationDictionary[org.Id];
					searchResults.Add($"\"{organization.Entity.Name}\"");
					if (organization.Tickets.Count > 0)
					{
						searchResults.Add($"**  {organization.Tickets.Count} linked tickets:");
						organization.Tickets.ForEach(ticket =>
						{
							searchResults.Add($"  - \"{ticket.Subject}\"");
						});
					}
					if (organization.Users.Count > 0)
					{
						searchResults.Add($"**  {organization.Users.Count} linked users:");
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
			List<User> users,
			Dictionary<int, UserDictionaryValues> userDictionary
		)
		{
			var searchResults = new List<string>();
			var foundUsers = users.FindAll(user => user.Id.ToString() == keyword
				|| user.Url == keyword
				|| user.ExternalId == keyword
				|| user.Tags.Contains(keyword)
				|| user.CreatedAt == keyword
				|| user.Name == keyword
				|| user.Alias == keyword
				|| user.Active.ToString().ToLower() == keyword
				|| user.Verified.ToString().ToLower() == keyword
				|| user.Shared.ToString().ToLower() == keyword
				|| user.Locale == keyword
				|| user.Timezone == keyword
				|| user.LastLoginAt == keyword
				|| user.Email == keyword
				|| user.Phone == keyword
				|| user.Signature == keyword
				|| user.OrganisationId.ToString() == keyword
				|| user.Suspended == keyword
				|| user.Role == keyword);
			if (foundUsers.Count > 0)
			{
				searchResults.Add($"{foundUsers.Count} matching users:");
				searchResults.Add("----------------------------");
				foundUsers.ForEach(user =>
				{
					var currentUser = userDictionary[user.Id];
					searchResults.Add($"\"{currentUser.Entity.Name}\"");
					if (currentUser.Organizations.Count > 0)
					{
						searchResults.Add($"**  Linked organization:");
						currentUser.Organizations.ForEach(organization =>
						{
							searchResults.Add($"  - \"{organization.Name}\"");
						});
					}
					if (currentUser.SubmittedTickets.Count > 0)
					{
						searchResults.Add($"**  {currentUser.SubmittedTickets.Count} submitted tickets:");
						currentUser.SubmittedTickets.ForEach(submittedTickets =>
						{
							searchResults.Add($"  - \"{submittedTickets.Subject}\"");
						});
					}
					if (currentUser.AssignedTickets.Count > 0)
					{
						searchResults.Add($"** {currentUser.AssignedTickets.Count} assigned tickets:");
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
			List<Ticket> tickets,
			Dictionary<string, TicketDictionaryValues> ticketDictionary
		)
		{
			var searchResults = new List<string>();
			var foundTickets = tickets.FindAll(ticket => ticket.Id.ToString() == keyword
				|| ticket.Url == keyword
				|| ticket.ExternalId == keyword
				|| ticket.Tags.Contains(keyword)
				|| ticket.CreatedAt == keyword
				|| ticket.Type == keyword
				|| ticket.Subject == keyword
				|| ticket.Description == keyword
				|| ticket.Priority == keyword
				|| ticket.Status == keyword
				|| ticket.SubmitterId.ToString() == keyword
				|| ticket.AssigneeId.ToString() == keyword
				|| ticket.OrganizationId.ToString() == keyword
				|| ticket.HasIncidents.ToString().ToLower() == keyword
				|| ticket.DueAt == keyword
				|| ticket.Via == keyword);
			if (foundTickets.Count > 0)
			{
				searchResults.Add($"{foundTickets.Count} matching tickets:");
				searchResults.Add("----------------------------");
				foundTickets.ForEach(ticket =>
				{
					var currentTicket = ticketDictionary[ticket.Id];
					searchResults.Add($"\"{currentTicket.Entity.Subject}\"");
					if (currentTicket.Organizations.Count > 0)
					{
						searchResults.Add($"**  {currentTicket.Organizations.Count} linked organizations:");
						currentTicket.Organizations.ForEach(organization =>
						{
							searchResults.Add($"  - \"{organization.Name}\"");
						});
					}
					if (currentTicket.SubmitterUsers.Count > 0)
					{
						searchResults.Add($"**  Submitted by:");
						currentTicket.SubmitterUsers.ForEach(submittedUser =>
						{
							searchResults.Add($"  - \"{submittedUser.Name}\"");
						});
					}
					if (currentTicket.AssignedUsers.Count > 0)
					{
						searchResults.Add($"** Assigned by:");
						currentTicket.AssignedUsers.ForEach(assignedUser =>
						{
							searchResults.Add($"  - \"{assignedUser.Name}\"");
						});
					}
				});
			}

			return searchResults;
		}

		public static List<string> Search(
			this string keyword,
			List<Organization> organizations,
			List<User> users,
			List<Ticket> tickets,
			Dictionary<int, OrganizationDictionaryValues> organizationDictionary,
			Dictionary<int, UserDictionaryValues> userDictionary,
			Dictionary<string, TicketDictionaryValues> ticketDictionary
		)
		{
			var organizationSearchResults = keyword.SearchOrganizations(
				organizations,
				organizationDictionary
			);

			var userSearchResults = keyword.SearchUsers(
				users,
				userDictionary
			);

			var ticketSearchResults = keyword.SearchTickets(
				tickets,
				ticketDictionary
			);
			var searchResults = organizationSearchResults
				.Concat(userSearchResults)
				.Concat(ticketSearchResults)
				.ToList();
			return searchResults;
		}
	}
}
