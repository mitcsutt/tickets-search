using TicketsSearch.Models;
using System.Collections.Generic;

namespace TicketsSearch.Tests.Services
{
	public abstract class SearchTestBase : TestBase
	{
		protected static readonly OrganizationDictionaryValues organization1DictionaryValue = new()
		{
			Entity = organization1,
			Tickets = new List<Ticket>
				{
					ticket1
				},
			Users = new List<User>
				{
					user1
				}
		};
		protected static readonly OrganizationDictionaryValues organization2DictionaryValue = new()
		{
			Entity = organization2,
			Tickets = new List<Ticket>
				{
					ticket2
				},
			Users = new List<User>
				{
					user2
				}
		};

		protected static readonly Dictionary<int, OrganizationDictionaryValues> organizationDictionary = new()
		{
			{ organization1.Id, organization1DictionaryValue },
			{ organization2.Id, organization2DictionaryValue }
		};

		protected static readonly UserDictionaryValues user1DictionaryValue = new()
		{
			Entity = user1,
			Organizations = new List<Organization>
				{
					organization1
				},
			SubmittedTickets = new List<Ticket>
				{
					ticket1
				},
			AssignedTickets = new List<Ticket>
				{
					ticket2
				},
		};
		protected static readonly UserDictionaryValues user2DictionaryValue = new()
		{
			Entity = user2,
			Organizations = new List<Organization>
				{
					organization2
				},
			SubmittedTickets = new List<Ticket>
				{
					ticket2
				},
			AssignedTickets = new List<Ticket>
				{
					ticket1
				},
		};

		protected static readonly Dictionary<int, UserDictionaryValues> userDictionary = new()
		{
			{ user1.Id, user1DictionaryValue },
			{ user2.Id, user2DictionaryValue }
		};

		protected static readonly TicketDictionaryValues ticket1DictionaryValue = new()
		{
			Entity = ticket1,
			Organizations = new List<Organization>
				{
					organization1
				},
			SubmitterUsers = new List<User>
				{
					user1
				},
			AssignedUsers = new List<User>
				{
					user2
				},
		};
		protected static readonly TicketDictionaryValues ticket2DictionaryValue = new()
		{
			Entity = ticket2,
			Organizations = new List<Organization>
				{
					organization2
				},
			SubmitterUsers = new List<User>
				{
					user2
				},
			AssignedUsers = new List<User>
				{
					user1
				},
		};
		protected static readonly Dictionary<string, TicketDictionaryValues> ticketDictionary = new()
		{
			{ ticket1.Id, ticket1DictionaryValue },
			{ ticket2.Id, ticket2DictionaryValue }
		};
	}
}
