using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Services;
namespace TicketsSearch.Tests.Services
{
	[TestClass]
	public class SearchOrganizations : SearchTestBase
	{

		[TestMethod]
		public void InvalidKeyword_ReturnsEmptyList()
		{
			var keyword = "non-existant";
			var results = keyword.SearchOrganizations(
				organizations,
				organizationDictionary
			);

			Assert.AreEqual(0, results.Count);
		}

		[DataTestMethod]
		[DataRow("1", true, false)]
		[DataRow("http://example1.com", true, false)]
		[DataRow("Organization 1", true, false)]
		[DataRow("example1.com", true, false)]
		[DataRow("time", true, true)]
		[DataRow("Organization details 1", true, false)]
		[DataRow("true", true, false)]
		[DataRow("Test", true, true)]
		[DataRow("2", false, true)]
		[DataRow("http://example2.com", false, true)]
		[DataRow("Organization 2", false, true)]
		[DataRow("example2.com", false, true)]
		[DataRow("Organization details 2", false, true)]
		[DataRow("false", false, true)]
		public void ValidKeyword_ReturnsResultList(string keyword, bool matchesOrganization1, bool matchesOrganization2)
		{
			var results = keyword.SearchOrganizations(
				organizations,
				organizationDictionary
			);
			var resultsCount = (matchesOrganization1 && matchesOrganization2) ? 12 : 7;
			var organizationsCount = (matchesOrganization1 && matchesOrganization2) ? 2 : 1;
			var resultsIndexAddition = (matchesOrganization1 && matchesOrganization2) ? 5 : 0;

			Assert.AreEqual(resultsCount, results.Count);
			Assert.AreEqual($"Matching organizations({organizationsCount}):", results[0]);
			Assert.AreEqual("----------------------------", results[1]);

			if (matchesOrganization1)
			{
				Assert.AreEqual("\"Organization 1\"", results[2]);
				Assert.AreEqual("*** Linked tickets(1):", results[3]);
				Assert.AreEqual("  - \"Ticket 1\"", results[4]);
				Assert.AreEqual("*** Linked users(1):", results[5]);
				Assert.AreEqual("  - \"User 1\"", results[6]);
			}

			if (matchesOrganization2)
			{
				Assert.AreEqual("\"Organization 2\"", results[resultsIndexAddition + 2]);
				Assert.AreEqual("*** Linked tickets(1):", results[resultsIndexAddition + 3]);
				Assert.AreEqual("  - \"Ticket 2\"", results[resultsIndexAddition + 4]);
				Assert.AreEqual("*** Linked users(1):", results[resultsIndexAddition + 5]);
				Assert.AreEqual("  - \"User 2\"", results[resultsIndexAddition + 6]);
			}
			if (!matchesOrganization1 && !matchesOrganization2)
			{
				Assert.Fail();
			}
		}
	}
}
