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
				"Name",
				users,
				userDictionary
			);

			Assert.AreEqual(0, results.Count);
		}

		[DataTestMethod]
		[DataRow("1", "Id", true, false)]
		[DataRow("http://example1.com", "Url", true, false)]
		[DataRow("time", "CreatedAt", true, true)]
		[DataRow("User 1", "Name", true, false)]
		[DataRow("Cool User1", "Alias", true, false)]
		[DataRow("true", "Active", true, false)]
		[DataRow("en-AU1", "Locale", true, false)]
		[DataRow("Australia", "Timezone", true, true)]
		[DataRow("time1", "LastLoginAt", true, false)]
		[DataRow("user@example1.com", "Email", true, false)]
		[DataRow("04000000001", "Phone", true, false)]
		[DataRow("him/he", "Signature", true, true)]
		[DataRow("Test1", "Tags", true, false)]
		[DataRow("admin1", "Role", true, false)]
		[DataRow("2", "Id", false, true)]
		[DataRow("http://example2.com", "Url", false, true)]
		[DataRow("User 2", "Name", false, true)]
		[DataRow("Cool User2", "Alias", false, true)]
		[DataRow("false", "Active", false, true)]
		[DataRow("en-AU2", "Locale", false, true)]
		[DataRow("user@example2.com", "Email", false, true)]
		[DataRow("04000000002", "Phone", false, true)]
		[DataRow("Test2", "Tags", false, true)]
		[DataRow("false", "Suspended", false, true)]
		[DataRow("admin2", "Role", false, true)]
		public void ValidKeyword_ReturnsResultList(string keyword, string property, bool matchesUser1, bool matchesUser2)
		{
			var results = keyword.SearchUsers(
				property,
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
