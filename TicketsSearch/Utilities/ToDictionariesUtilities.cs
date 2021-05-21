using System.Collections.Generic;
using System.Linq;
using TicketsSearch.Models;

namespace TicketsSearch.Utilities
{
	public class ToDictionariesUtilities
	{
		public static (Dictionary<int, OrganizationDictionaryValues>,
			Dictionary<int, UserDictionaryValues>,
			Dictionary<string, TicketDictionaryValues>)
		ToDictionaries(
			List<Organization> organizations,
			List<User> users,
			List<Ticket> tickets
		)
		{
			var organizationDictionary = organizations.ToDictionary(
				organization => organization.Id,
				organization => new OrganizationDictionaryValues
				{
					Entity = organization,
					Users = new List<User>(),
					Tickets = new List<Ticket>(),

				}
			);
			var userDictionary = users.ToDictionary(
				user => user.Id,
				user => new UserDictionaryValues
				{
					Entity = user,
					SubmittedTickets = new List<Ticket>(),
					AssignedTickets = new List<Ticket>(),
					Organizations = new List<Organization>()
				}
			);
			var ticketDictionary = tickets.ToDictionary(
				ticket => ticket.Id,
				ticket => new TicketDictionaryValues
				{
					Entity = ticket,
					SubmitterUsers = new List<User>(),
					AssignedUsers = new List<User>(),
					Organizations = new List<Organization>()
				}
			);
			users.ForEach(user =>
			{
				var organizationId = user.OrganisationId;
				if (organizationId != null && organizationDictionary.ContainsKey((int)organizationId))
				{
					organizationDictionary[(int)organizationId].Users.Add(user);
					userDictionary[user.Id].Organizations.Add(organizationDictionary[(int)organizationId].Entity);
				}
			});

			tickets.ForEach(ticket =>
			{
				var organizationId = ticket.OrganizationId;
				var ticketId = ticket.Id;
				var assigneeId = ticket.AssigneeId;
				var submitterId = ticket.SubmitterId;
				if (organizationId != null && organizationDictionary.ContainsKey((int)organizationId))
				{
					organizationDictionary[(int)organizationId].Tickets.Add(ticket);
					ticketDictionary[ticketId].Organizations.Add(organizationDictionary[(int)organizationId].Entity);
				}
				if (assigneeId != null && userDictionary.ContainsKey((int)assigneeId))
				{
					userDictionary[(int)assigneeId].AssignedTickets.Add(ticket);
					ticketDictionary[ticketId].AssignedUsers.Add(userDictionary[(int)assigneeId].Entity);
				}
				if (userDictionary.ContainsKey(submitterId))
				{
					userDictionary[submitterId].SubmittedTickets.Add(ticket);
					ticketDictionary[ticketId].SubmitterUsers.Add(userDictionary[submitterId].Entity);
				}
			});
			return (organizationDictionary, userDictionary, ticketDictionary);
		}
	}
}
