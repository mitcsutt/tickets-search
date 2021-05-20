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

            var foundOrganizations = organizations.FindAll(organization => organization.Name == keyword);
            if(foundOrganizations.Count > 0)
            {
                searchResults.Add($"{foundOrganizations.Count} matching organizations:");
                foundOrganizations.ForEach(org =>
                {
                    var organization = organizationDictionary[org.Id.ToString()];
                    searchResults.Add($"  {organization.Entity.Name}");
                    if(organization.Tickets.Count > 0)
                    {
                        searchResults.Add($"  {organization.Tickets.Count} linked tickets:");
                        organization.Tickets.ForEach(ticket =>
                        {
                            searchResults.Add($"    {ticket.Subject}");
                        });
                    }
                    if (organization.Users.Count > 0)
                    {
                        searchResults.Add($"  {organization.Users.Count} linked users:");
                        organization.Users.ForEach(user =>
                        {
                            searchResults.Add($"    {user.Name}");
                        });
                    }
                });
            }

            return searchResults;
        }
    }
}
