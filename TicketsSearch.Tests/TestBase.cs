using TicketsSearch.Models;
using System.Collections.Generic;

namespace TicketsSearch.Tests
{
	public abstract class TestBase
	{
		protected static readonly Organization organization1 = new Organization
		{
			Id = 1,
			Url = "http://example1.com",
			ExternalId = "1",
			Name = "Organization 1",
			DomainNames = new List<string>
			{
				"example1.com",
			},
			CreatedAt = "time",
			Details = "Organization details 1",
			SharedTickets = true,
			Tags = new List<string>
			{
				"Test"
			}
		};
		protected static readonly Organization organization2 = new Organization
		{
			Id = 2,
			Url = "http://example2.com",
			ExternalId = "2",
			Name = "Organization 2",
			DomainNames = new List<string>
			{
				"example2.com",
			},
			CreatedAt = "time",
			Details = "Organization details 2",
			SharedTickets = false,
			Tags = new List<string>
			{
				"Test"
			}
		};
		public static readonly List<Organization> organizations = new List<Organization> {
			organization1,
			organization2
		};
		protected static readonly Ticket ticket1 = new Ticket
		{
			Id = "1",
			Url = "http://example1.com",
			ExternalId = "1",
			CreatedAt = "time1",
			Type = "incident1",
			Subject = "Ticket 1",
			Description = "A test ticket 1",
			Priority = "high1",
			Status = "pending1",
			SubmitterId = 1,
			AssigneeId = 2,
			OrganizationId = 1,
			Tags = new List<string>
			{
				"Test1"
			},
			HasIncidents = true,
			DueAt = "time1",
			Via = "web1"
		};
		protected static readonly Ticket ticket2 = new Ticket
		{
			Id = "2",
			Url = "http://example2.com",
			ExternalId = "2",
			CreatedAt = "time2",
			Type = "incident2",
			Subject = "Ticket 2",
			Description = "A test ticket 2",
			Priority = "high2",
			Status = "pending2",
			SubmitterId = 2,
			AssigneeId = 1,
			OrganizationId = 2,
			Tags = new List<string>
			{
				"Test2"
			},
			HasIncidents = false,
			DueAt = "time2",
			Via = "web2"
		};
		public static readonly List<Ticket> tickets = new List<Ticket> {
			ticket1,
			ticket2
		};
		protected static readonly User user1 = new User
		{
			Id = 1,
			Url = "http://example1.com",
			ExternalId = "1",
			CreatedAt = "time",
			Name = "User 1",
			Alias = "Cool User1",
			Active = true,
			Verified = true,
			Shared = true,
			Locale = "en-AU1",
			Timezone = "Australia",
			LastLoginAt = "time1",
			Email = "user@example1.com",
			Phone = "04000000001",
			Signature = "him/he",
			OrganizationId = 1,
			Tags = new List<string>
			{
				"Test1"
			},
			Suspended = true,
			Role = "admin1"
		};
		protected static readonly User user2 = new User
		{
			Id = 2,
			Url = "http://example2.com",
			ExternalId = "2",
			CreatedAt = "time",
			Name = "User 2",
			Alias = "Cool User2",
			Active = false,
			Verified = false,
			Shared = false,
			Locale = "en-AU2",
			Timezone = "Australia",
			LastLoginAt = "time2",
			Email = "user@example2.com",
			Phone = "04000000002",
			Signature = "him/he",
			OrganizationId = 2,
			Tags = new List<string>
			{
				"Test2"
			},
			Suspended = false,
			Role = "admin2"
		};
		public static readonly List<User> users = new List<User> {
			user1,
			user2
		};
	}
}
