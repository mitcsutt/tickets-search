using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Models;
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
		[DataRow("1", 1)]
		[DataRow("http://example1.com", 1)]
		[DataRow("1", 1)]
		[DataRow("Organization 1", 1)]
		[DataRow("example1.com", 1)]
		[DataRow("time1", 1)]
		[DataRow("Organization details 1", 1)]
		[DataRow("true", 1)]
		[DataRow("Test 1", 1)]
		[DataRow("2", 2)]
		[DataRow("http://example2.com", 2)]
		[DataRow("2", 2)]
		[DataRow("Organization 2", 2)]
		[DataRow("example2.com", 2)]
		[DataRow("time2", 2)]
		[DataRow("Organization details 2", 2)]
		[DataRow("false", 2)]
		[DataRow("Test 2", 2)]
		public void ValidKeyword_ReturnsResultList(string keyword, int number)
		{
			var results = keyword.SearchOrganizations(
				organizations,
				organizationDictionary
			);
			Assert.AreEqual(7, results.Count);
			Assert.AreEqual("1 matching organizations:", results[0]);
			Assert.AreEqual("----------------------------", results[1]);

			switch (number)
            {
				case 1:
					Assert.AreEqual("\"Organization 1\"", results[2]);
					Assert.AreEqual("*** 1 linked tickets:", results[3]);
					Assert.AreEqual("  - \"Ticket 1\"", results[4]);
					Assert.AreEqual("*** 1 linked users:", results[5]);
					Assert.AreEqual("  - \"User 1\"", results[6]);
					break;
				case 2:
					Assert.AreEqual("\"Organization 2\"", results[2]);
					Assert.AreEqual("*** 1 linked tickets:", results[3]);
					Assert.AreEqual("  - \"Ticket 2\"", results[4]);
					Assert.AreEqual("*** 1 linked users:", results[5]);
					Assert.AreEqual("  - \"User 2\"", results[6]); break;
				default:
					Assert.Fail();
					break;
            }
		}
	}
}
