using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Services;
namespace TicketsSearch.Tests.Services
{
	[TestClass]
	public class SearchUsers : SearchTestBase
	{

		[TestMethod]
		public void InvalidKeyword_ReturnsEmptyList()
		{
			var keyword = "non-existant";
			var results = keyword.SearchUsers(
				users,
				userDictionary
			);

			Assert.AreEqual(0, results.Count);
		}

		[DataTestMethod]
		[DataRow("1", true, false)]
		[DataRow("http://example1.com", true, false)]
		[DataRow("time", true, true)]
		[DataRow("User 1", true, false)]
		[DataRow("Cool User1", true, false)]
		[DataRow("true", true, false)]
		[DataRow("en-AU1", true, false)]
		[DataRow("Australia", true, true)]
		[DataRow("time1", true, false)]
		[DataRow("user@example1.com", true, false)]
		[DataRow("04000000001", true, false)]
		[DataRow("him/he", true, true)]
		[DataRow("Test1", true, false)]
		[DataRow("admin1", true, false)]
		[DataRow("2", false, true)]
		[DataRow("http://example2.com", false, true)]
		[DataRow("User 2", false, true)]
		[DataRow("Cool User2", false, true)]
		[DataRow("false", false, true)]
		[DataRow("en-AU2", false, true)]
		[DataRow("time2", false, true)]
		[DataRow("user@example2.com", false, true)]
		[DataRow("04000000002", false, true)]
		[DataRow("Test2", false, true)]
		[DataRow("false", false, true)]
		[DataRow("admin2", false, true)]
		public void ValidKeyword_ReturnsResultList(string keyword, bool matchesUser1, bool matchesUser2)
		{
			var results = keyword.SearchUsers(
				users,
				userDictionary
			);
			var resultsCount = (matchesUser1 && matchesUser2) ? 16 : 9;
			var userCount = (matchesUser1 && matchesUser2) ? 2 : 1;
			var resultsIndexAddition = (matchesUser1 && matchesUser2) ? 7 : 0;
			Assert.AreEqual(resultsCount, results.Count);
			Assert.AreEqual($"Matching users({userCount}):", results[0]);
			Assert.AreEqual("----------------------------", results[1]);

			if (matchesUser1)
			{
				Assert.AreEqual("\"User 1\"", results[2]);
				Assert.AreEqual("*** Linked organization:", results[3]);
				Assert.AreEqual("  - \"Organization 1\"", results[4]);
				Assert.AreEqual("*** Submitted tickets(1):", results[5]);
				Assert.AreEqual("  - \"Ticket 1\"", results[6]);
				Assert.AreEqual("*** Assigned tickets(1):", results[7]);
				Assert.AreEqual("  - \"Ticket 2\"", results[8]);
			}

			if (matchesUser2)
			{
				Assert.AreEqual("\"User 2\"", results[resultsIndexAddition + 2]);
				Assert.AreEqual("*** Linked organization:", results[resultsIndexAddition + 3]);
				Assert.AreEqual("  - \"Organization 2\"", results[resultsIndexAddition + 4]);
				Assert.AreEqual("*** Submitted tickets(1):", results[resultsIndexAddition + 5]);
				Assert.AreEqual("  - \"Ticket 2\"", results[resultsIndexAddition + 6]);
				Assert.AreEqual("*** Assigned tickets(1):", results[resultsIndexAddition + 7]);
				Assert.AreEqual("  - \"Ticket 1\"", results[resultsIndexAddition + 8]);
			}
			if (!matchesUser1 && !matchesUser2)
			{
				Assert.Fail();
			}
		}
	}
}
