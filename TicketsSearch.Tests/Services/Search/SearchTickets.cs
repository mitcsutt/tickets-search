using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Services;
namespace TicketsSearch.Tests.Services
{
	[TestClass]
	public class SearchTickets : SearchTestBase
	{

		[TestMethod]
		public void InvalidKeyword_ReturnsEmptyList()
		{
			var keyword = "non-existant";
			var results = keyword.SearchTickets(
				"Url",
				tickets,
				ticketDictionary
			);

			Assert.AreEqual(0, results.Count);
		}

		[DataTestMethod]
		[DataRow("1", "Id", true, false)]
		[DataRow("http://example1.com", "Url", true, false)]
		[DataRow("time1", "CreatedAt", true, false)]
		[DataRow("incident1", "Type", true, false)]
		[DataRow("Ticket 1", "Subject", true, false)]
		[DataRow("A test ticket 1", "Description", true, false)]
		[DataRow("high1", "Priority", true, false)]
		[DataRow("pending1", "Status", true, false)]
		[DataRow("Test1", "Tags", true, false)]
		[DataRow("true", "HasIncidents", true, false)]
		[DataRow("time1", "DueAt", true, false)]
		[DataRow("web1", "Via", true, false)]
		[DataRow("2", "Id", false, true)]
		[DataRow("http://example2.com", "Url", false, true)]
		[DataRow("time2", "CreatedAt", false, true)]
		[DataRow("incident2", "Type", false, true)]
		[DataRow("Ticket 2", "Subject", false, true)]
		[DataRow("A test ticket 2", "Description", false, true)]
		[DataRow("high2", "Priority", false, true)]
		[DataRow("pending2", "Status", false, true)]
		[DataRow("Test2", "Tags", false, true)]
		[DataRow("false", "HasIncidents", false, true)]
		[DataRow("time2", "DueAt", false, true)]
		[DataRow("web2", "Via", false, true)]
		public void ValidKeyword_ReturnsResultList(string keyword, string property, bool matchesTicket1, bool matchesTicket2)
		{
			var results = keyword.SearchTickets(
				property,
				tickets,
				ticketDictionary
			);
			var resultsCount = (matchesTicket1 && matchesTicket2) ? 16 : 9;
			var ticketCount = (matchesTicket1 && matchesTicket2) ? 2 : 1;
			var resultsIndexAddition = (matchesTicket1 && matchesTicket2) ? 7 : 0;
			Assert.AreEqual(resultsCount, results.Count);
			Assert.AreEqual($"Matching tickets({ticketCount}):", results[0]);
			Assert.AreEqual("----------------------------", results[1]);

			if (matchesTicket1)
			{
				Assert.AreEqual("\"Ticket 1\"", results[2]);
				Assert.AreEqual("*** Linked organization:", results[3]);
				Assert.AreEqual("  - \"Organization 1\"", results[4]);
				Assert.AreEqual("*** Submitted by:", results[5]);
				Assert.AreEqual("  - \"User 1\"", results[6]);
				Assert.AreEqual("*** Assigned by:", results[7]);
				Assert.AreEqual("  - \"User 2\"", results[8]);
			}

			if (matchesTicket2)
			{
				Assert.AreEqual("\"Ticket 2\"", results[resultsIndexAddition + 2]);
				Assert.AreEqual("*** Linked organization:", results[resultsIndexAddition + 3]);
				Assert.AreEqual("  - \"Organization 2\"", results[resultsIndexAddition + 4]);
				Assert.AreEqual("*** Submitted by:", results[resultsIndexAddition + 5]);
				Assert.AreEqual("  - \"User 2\"", results[resultsIndexAddition + 6]);
				Assert.AreEqual("*** Assigned by:", results[resultsIndexAddition + 7]);
				Assert.AreEqual("  - \"User 1\"", results[resultsIndexAddition + 8]);
			}
			if (!matchesTicket1 && !matchesTicket2)
			{
				Assert.Fail();
			}
		}
	}
}
