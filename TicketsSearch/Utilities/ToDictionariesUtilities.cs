using System.Collections.Generic;
using System.Linq;
using TicketsSearch.Models;

namespace TicketsSearch.Utilities
{
	public class ToDictionariesUtilities
	{
		public static (Dictionary<string, OrganizationDictionaryValues>,
			Dictionary<string, UserDictionaryValues>,
			Dictionary<string, TicketDictionaryValues>)
		ToDictionaries(
			List<Organization> organizations,
			List<User> users,
			List<Ticket> tickets
		)
		{
			var organizationDictionary = organizations.ToDictionary(
				organization => organization.Id.ToString(),
				organization => new OrganizationDictionaryValues { 
					Entity = organization,
					Users = new List<User>(),
					Tickets = new List<Ticket>(),
					
				} 
			);
			var userDictionary = users.ToDictionary(
				user => user.Id.ToString(),
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
			users.ForEach(user => {
				var organizationId = user.OrganisationId;
				if(organizationId != null && organizationDictionary.ContainsKey(organizationId))
                {
					organizationDictionary[organizationId].Users.Add(user);
					userDictionary[user.Id.ToString()].Organizations.Add(organizationDictionary[organizationId].Entity);
				}
			});

			tickets.ForEach(ticket =>
			{
				var organizationId = ticket.OrganizationId;
				var ticketId = ticket.Id;
				var assigneeId = ticket.AssigneeId;
				var submitterId = ticket.SubmitterId;
				if(organizationId != null && organizationDictionary.ContainsKey(organizationId))
                {
					organizationDictionary[organizationId].Tickets.Add(ticket);
					ticketDictionary[ticketId].Organizations.Add(organizationDictionary[organizationId].Entity);
				}
				if (assigneeId != null && userDictionary.ContainsKey(assigneeId))
				{
					userDictionary[assigneeId].AssignedTickets.Add(ticket);
					ticketDictionary[ticketId].AssignedUsers.Add(userDictionary[assigneeId].Entity);
				}
				if (submitterId != null && userDictionary.ContainsKey(submitterId))
				{
					userDictionary[submitterId].SubmittedTickets.Add(ticket);
					ticketDictionary[ticketId].SubmitterUsers.Add(userDictionary[submitterId].Entity);
				}
			});
			return (organizationDictionary, userDictionary, ticketDictionary);
		}
	}
}
