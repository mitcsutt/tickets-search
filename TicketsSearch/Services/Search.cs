using System.Collections.Generic;
using TicketsSearch.Models;
namespace TicketsSearch.Services
{
	public static class SearchService
	{
		public static List<string> Search(
			this string keyword,
			List<Organization> organizations,
			List<User> users,
			List<Ticket> tickets,
			Dictionary<string, OrganizationDictionaryValues> organizationDictionary,
			Dictionary<string, UserDictionaryValues> userDictionary,
			Dictionary<string, TicketDictionaryValues> ticketDictionary
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
					var organization = organizationDictionary[org.Id.ToString()];
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

			var foundUsers = users.FindAll(user => user.Id.ToString() == keyword
				|| user.Url == keyword
				|| user.ExternalId == keyword
				|| user.Tags.Contains(keyword)
				|| user.CreatedAt == keyword
				|| user.Name == keyword
				|| user.Alias.Contains(keyword)
				|| user.Active.ToString().ToLower() == keyword
				|| user.Verified.ToString().ToLower() == keyword
				|| user.Shared.ToString().ToLower() == keyword
				|| user.Locale == keyword
				|| user.Timezone == keyword
				|| user.LastLoginAt == keyword
				|| user.Email == keyword
				|| user.Phone == keyword
				|| user.Signature == keyword
				|| user.OrganisationId == keyword
				|| user.Suspended == keyword
				|| user.Role == keyword);
			if (foundUsers.Count > 0)
			{
				searchResults.Add($"{foundUsers.Count} matching users:");
				searchResults.Add("----------------------------");
				foundUsers.ForEach(org =>
				{
					var user = userDictionary[org.Id.ToString()];
					searchResults.Add($"\"{user.Entity.Name}\"");
					if (user.Organizations.Count > 0)
					{
						searchResults.Add($"**  {user.Organizations.Count} linked organizations:");
						user.Organizations.ForEach(organization =>
						{
							searchResults.Add($"  - \"{organization.Name}\"");
						});
					}
					if (user.SubmittedTickets.Count > 0)
					{
						searchResults.Add($"**  {user.SubmittedTickets.Count} submitted tickets:");
						user.SubmittedTickets.ForEach(submittedTickets =>
						{
							searchResults.Add($"  - \"{submittedTickets.Subject}\"");
						});
					}
					if (user.AssignedTickets.Count > 0)
					{
						searchResults.Add($"** {user.AssignedTickets.Count} assigned tickets:");
						user.AssignedTickets.ForEach(submittedTickets =>
						{
							searchResults.Add($"  - \"{submittedTickets.Subject}\"");
						});
					}
				});
			}

			return searchResults;
		}
	}
}
