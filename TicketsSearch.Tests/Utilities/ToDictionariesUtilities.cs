using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Models;
namespace TicketsSearch.Tests.Utilities
{
    [TestClass]
    public class ToDictionariesUtilities : TestBase
    {

        [TestMethod]
        public void OrganizationsHaveValues_ReturnsOrganizationDictionary()
        {
            var (organizationDictionary, userDictionary, ticketDictionary) = TicketsSearch.Utilities.ToDictionariesUtilities.ToDictionaries(
                organizations,
                new List<User>(),
                new List<Ticket>()
            );

            var organization1DictionaryValue = new OrganizationDictionaryValues
            {
                Entity = organization1,
                Tickets = new List<Ticket>(),
                Users = new List<User>()
            };
            var organization2DictionaryValue = new OrganizationDictionaryValues
            {
                Entity = organization2,
                Tickets = new List<Ticket>(),
                Users = new List<User>()
            };

            Assert.AreEqual(2, organizationDictionary.Count);

            Assert.AreEqual(organization1DictionaryValue.Entity, organizationDictionary[organization1.Id].Entity);
            CollectionAssert.AreEqual(organization1DictionaryValue.Tickets, organizationDictionary[organization1.Id].Tickets);
            CollectionAssert.AreEqual(organization1DictionaryValue.Users, organizationDictionary[organization1.Id].Users);

            Assert.AreEqual(organization2DictionaryValue.Entity, organizationDictionary[organization2.Id].Entity);
            CollectionAssert.AreEqual(organization2DictionaryValue.Tickets, organizationDictionary[organization2.Id].Tickets);
            CollectionAssert.AreEqual(organization2DictionaryValue.Users, organizationDictionary[organization2.Id].Users);

            Assert.AreEqual(0, userDictionary.Count);
            Assert.AreEqual(0, ticketDictionary.Count);
        }

        [TestMethod]
        public void UsersHaveValues_ReturnsUserDictionary()
        {
            var (organizationDictionary, userDictionary, ticketDictionary) = TicketsSearch.Utilities.ToDictionariesUtilities.ToDictionaries(
                new List<Organization>(),
                users,
                new List<Ticket>()
            );

            var user1DictionaryValue = new UserDictionaryValues
            {
                Entity = user1,
                Organizations = new List<Organization>(),
                SubmittedTickets = new List<Ticket>(),
                AssignedTickets = new List<Ticket>(),
            };
            var user2DictionaryValue = new UserDictionaryValues
            {
                Entity = user2,
                Organizations = new List<Organization>(),
                SubmittedTickets = new List<Ticket>(),
                AssignedTickets = new List<Ticket>(),
            };

            Assert.AreEqual(0, organizationDictionary.Count);

            Assert.AreEqual(2, userDictionary.Count);
            Assert.AreEqual(user1DictionaryValue.Entity, userDictionary[user1.Id].Entity);
            CollectionAssert.AreEqual(user1DictionaryValue.Organizations, userDictionary[user1.Id].Organizations);
            CollectionAssert.AreEqual(user1DictionaryValue.SubmittedTickets, userDictionary[user1.Id].SubmittedTickets);
            CollectionAssert.AreEqual(user1DictionaryValue.AssignedTickets, userDictionary[user1.Id].AssignedTickets);

            Assert.AreEqual(user2DictionaryValue.Entity, userDictionary[user2.Id].Entity);
            CollectionAssert.AreEqual(user2DictionaryValue.Organizations, userDictionary[user2.Id].Organizations);
            CollectionAssert.AreEqual(user2DictionaryValue.SubmittedTickets, userDictionary[user2.Id].SubmittedTickets);
            CollectionAssert.AreEqual(user2DictionaryValue.AssignedTickets, userDictionary[user2.Id].AssignedTickets);

            Assert.AreEqual(0, ticketDictionary.Count);
        }

        [TestMethod]
        public void TicketsHaveValues_ReturnsTicketDictionary()
        {
            var (organizationDictionary, userDictionary, ticketDictionary) = TicketsSearch.Utilities.ToDictionariesUtilities.ToDictionaries(
                new List<Organization>(),
                new List<User>(),
                tickets
            );

            var ticket1DictionaryValue = new TicketDictionaryValues
            {
                Entity = ticket1,
                Organizations = new List<Organization>(),
                SubmitterUsers = new List<User>(),
                AssignedUsers = new List<User>(),
            };
            var ticket2DictionaryValue = new TicketDictionaryValues
            {
                Entity = ticket2,
                Organizations = new List<Organization>(),
                SubmitterUsers = new List<User>(),
                AssignedUsers = new List<User>(),
            };

            Assert.AreEqual(0, organizationDictionary.Count);

            Assert.AreEqual(0, userDictionary.Count);

            Assert.AreEqual(2, ticketDictionary.Count);
            Assert.AreEqual(ticket1DictionaryValue.Entity, ticketDictionary[ticket1.Id].Entity);
            CollectionAssert.AreEqual(ticket1DictionaryValue.Organizations, ticketDictionary[ticket1.Id].Organizations);
            CollectionAssert.AreEqual(ticket1DictionaryValue.SubmitterUsers, ticketDictionary[ticket1.Id].SubmitterUsers);
            CollectionAssert.AreEqual(ticket1DictionaryValue.AssignedUsers, ticketDictionary[ticket1.Id].AssignedUsers);

            Assert.AreEqual(ticket2DictionaryValue.Entity, ticketDictionary[ticket2.Id].Entity);
            CollectionAssert.AreEqual(ticket2DictionaryValue.Organizations, ticketDictionary[ticket2.Id].Organizations);
            CollectionAssert.AreEqual(ticket2DictionaryValue.SubmitterUsers, ticketDictionary[ticket2.Id].SubmitterUsers);
            CollectionAssert.AreEqual(ticket2DictionaryValue.AssignedUsers, ticketDictionary[ticket2.Id].AssignedUsers);

        }

        [TestMethod]
        public void AllArraysHaveValues_ReturnsAllConnectedDictionaries()
        {
            var (organizationDictionary, userDictionary, ticketDictionary) = TicketsSearch.Utilities.ToDictionariesUtilities.ToDictionaries(
                organizations,
                users,
                tickets
            );

            var organization1DictionaryValue = new OrganizationDictionaryValues
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
            var organization2DictionaryValue = new OrganizationDictionaryValues
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

            var user1DictionaryValue = new UserDictionaryValues
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
            var user2DictionaryValue = new UserDictionaryValues
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

            var ticket1DictionaryValue = new TicketDictionaryValues
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
            var ticket2DictionaryValue = new TicketDictionaryValues
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

            Assert.AreEqual(2, organizationDictionary.Count);

            Assert.AreEqual(organization1DictionaryValue.Entity, organizationDictionary[organization1.Id].Entity);
            CollectionAssert.AreEqual(organization1DictionaryValue.Tickets, organizationDictionary[organization1.Id].Tickets);
            CollectionAssert.AreEqual(organization1DictionaryValue.Users, organizationDictionary[organization1.Id].Users);

            Assert.AreEqual(organization2DictionaryValue.Entity, organizationDictionary[organization2.Id].Entity);
            CollectionAssert.AreEqual(organization2DictionaryValue.Tickets, organizationDictionary[organization2.Id].Tickets);
            CollectionAssert.AreEqual(organization2DictionaryValue.Users, organizationDictionary[organization2.Id].Users);

            Assert.AreEqual(2, userDictionary.Count);
            Assert.AreEqual(user1DictionaryValue.Entity, userDictionary[user1.Id].Entity);
            CollectionAssert.AreEqual(user1DictionaryValue.Organizations, userDictionary[user1.Id].Organizations);
            CollectionAssert.AreEqual(user1DictionaryValue.SubmittedTickets, userDictionary[user1.Id].SubmittedTickets);
            CollectionAssert.AreEqual(user1DictionaryValue.AssignedTickets, userDictionary[user1.Id].AssignedTickets);

            Assert.AreEqual(user2DictionaryValue.Entity, userDictionary[user2.Id].Entity);
            CollectionAssert.AreEqual(user2DictionaryValue.Organizations, userDictionary[user2.Id].Organizations);
            CollectionAssert.AreEqual(user2DictionaryValue.SubmittedTickets, userDictionary[user2.Id].SubmittedTickets);
            CollectionAssert.AreEqual(user2DictionaryValue.AssignedTickets, userDictionary[user2.Id].AssignedTickets);

            Assert.AreEqual(2, ticketDictionary.Count);
            Assert.AreEqual(ticket1DictionaryValue.Entity, ticketDictionary[ticket1.Id].Entity);
            CollectionAssert.AreEqual(ticket1DictionaryValue.Organizations, ticketDictionary[ticket1.Id].Organizations);
            CollectionAssert.AreEqual(ticket1DictionaryValue.SubmitterUsers, ticketDictionary[ticket1.Id].SubmitterUsers);
            CollectionAssert.AreEqual(ticket1DictionaryValue.AssignedUsers, ticketDictionary[ticket1.Id].AssignedUsers);

            Assert.AreEqual(ticket2DictionaryValue.Entity, ticketDictionary[ticket2.Id].Entity);
            CollectionAssert.AreEqual(ticket2DictionaryValue.Organizations, ticketDictionary[ticket2.Id].Organizations);
            CollectionAssert.AreEqual(ticket2DictionaryValue.SubmitterUsers, ticketDictionary[ticket2.Id].SubmitterUsers);
            CollectionAssert.AreEqual(ticket2DictionaryValue.AssignedUsers, ticketDictionary[ticket2.Id].AssignedUsers);
        }
    }
}
