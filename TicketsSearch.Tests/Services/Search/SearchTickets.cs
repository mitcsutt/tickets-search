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
				tickets,
				ticketDictionary
			);

			Assert.AreEqual(0, results.Count);
		}

		[DataTestMethod]
		[DataRow("1", true, true)]
		[DataRow("http://example1.com", true, false)]
		[DataRow("time1", true, false)]
		[DataRow("incident1", true, false)]
		[DataRow("Ticket 1", true, false)]
		[DataRow("A test ticket 1", true, false)]
		[DataRow("high1", true, false)]
		[DataRow("pending1", true, false)]
		[DataRow("Test1", true, false)]
		[DataRow("true", true, false)]
		[DataRow("time1", true, false)]
		[DataRow("web1", true, false)]
		[DataRow("2", true, true)]
		[DataRow("http://example2.com", false, true)]
		[DataRow("time2", false, true)]
		[DataRow("incident2", false, true)]
		[DataRow("Ticket 2", false, true)]
		[DataRow("A test ticket 2", false, true)]
		[DataRow("high2", false, true)]
		[DataRow("pending2", false, true)]
		[DataRow("Test2", false, true)]
		[DataRow("false", false, true)]
		[DataRow("time2", false, true)]
		[DataRow("web2", false, true)]
		public void ValidKeyword_ReturnsResultList(string keyword, bool matchesTicket1, bool matchesTicket2)
		{
			var results = keyword.SearchTickets(
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
