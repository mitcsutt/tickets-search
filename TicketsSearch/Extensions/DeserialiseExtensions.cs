using System.Collections.Generic;
using Newtonsoft.Json;
using TicketsSearch.Models;
namespace TicketsSearch.Extensions
{
	public static class DeserialiseExtensions
	{
		public static List<Organization> DeserializeOrganizations(this string json)
		{
			return JsonConvert.DeserializeObject<List<Organization>>(json);
		}
		public static List<Ticket> DeserializeTickets(this string json)
		{
			return JsonConvert.DeserializeObject<List<Ticket>>(json);
		}
		public static List<User> DeserializeUsers(this string json)
		{
			return JsonConvert.DeserializeObject<List<User>>(json);
		}
	}
}
