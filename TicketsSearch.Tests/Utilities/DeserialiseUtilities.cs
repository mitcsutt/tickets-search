using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketsSearch.Utilities;
using TicketsSearch.Models;

namespace TicketsSearch.Tests.Utilities
{
	[TestClass]
	public class DeserialiseUtilities
	{
		[TestMethod]
		public void OrganizationString_CreatesOrganizationList()
		{
			var json = @"[
				{
					'_id': 001,
					'url': 'http://initech.zendesk.com/api/v2/organizations/113.json',
					'external_id': '67d9dbdb-a9c6-4a30-a003-202de05d09e2',
					'name': 'Mitchell',
					'domain_names': [
						'mitch.com',
						'mitchell.com',
					],
					'created_at': '2016-04-09T08:45:29 -10:00',
					'details': 'Coding project',
					'shared_tickets': true,
					'tags': [
						'Zendesk',
						'Project',
					]
				},
				{
					'_id': 002,
					'url': 'http://initech.zendesk.com/api/v2/organizations/113.json',
					'external_id': '67d9dbdb-a9c6-4a30-a003-202de05d09e2',
					'name': 'Suttin',
					'domain_names': [
						'sutton.com',
						'sutt.com',
					],
					'created_at': '2016-04-09T08:45:29 -10:00',
					'details': 'Another coding project',
					'shared_tickets': true,
					'tags': [
						'Melbourne',
						'Office',
					]
				}
			]";

			var result = json.Deserialise<Organization>();

			Assert.AreEqual(2, result.Count);
			Assert.IsInstanceOfType(result[0], typeof(Organization));
			Assert.AreEqual(001, result[0].Id);
			Assert.IsInstanceOfType(result[1], typeof(Organization));
			Assert.AreEqual(002, result[1].Id);
		}

		[TestMethod]
		public void TicketString_CreatesTicketList()
		{
			var json = @"[
				{
					'_id': '9cbbadfe-7242-4d5a-af78-62aa7191d944',
					'url': 'http://initech.zendesk.com/api/v2/tickets/9cbbadfe-7242-4d5a-af78-62aa7191d944.json',
					'external_id': 'd193deb7-92d5-4004-a532-4a1cd30449c5',
					'created_at': '2016-01-30T12:45:37 -11:00',
					'type': 'Zendesk',
					'subject': 'Zendesk project',
					'description': 'A super cool description',
					'priority': 'high',
					'status': 'pending',
					'submitter_id': 1,
					'assignee_id': 2,
					'organization_id': 1,
					'tags': [
						'Ticket',
						'Urgent',
					],
					'has_incidents': false,
					'due_at': '2016-08-14T09:28:10 -10:00',
					'via': 'web'
  				},
				{
					'_id': '423423423-7242-4322-af78-432432243',
					'url': 'http://initech.zendesk.com/api/v2/tickets/9cbbadfe-7242-4d5a-af78-62aa7191d944.json',
					'external_id': 'd193deb7-92d5-4004-a532-4a1cd30449c5',
					'created_at': '2016-01-30T12:45:37 -11:00',
					'type': 'Project',
					'subject': 'Another project',
					'description': 'A super boring description',
					'priority': 'low',
					'status': 'pending',
					'submitter_id': 3,
					'assignee_id': 4,
					'organization_id': 2,
					'tags': [
						'Must have',
						'Tomorrow',
					],
					'has_incidents': false,
					'due_at': '2016-08-14T09:28:10 -10:00',
					'via': 'call'
  				},
			]";

			var result = json.Deserialise<Ticket>();

			Assert.AreEqual(2, result.Count);
			Assert.IsInstanceOfType(result[0], typeof(Ticket));
			Assert.AreEqual("9cbbadfe-7242-4d5a-af78-62aa7191d944", result[0].Id);
			Assert.IsInstanceOfType(result[1], typeof(Ticket));
			Assert.AreEqual("423423423-7242-4322-af78-432432243", result[1].Id);
		}
		[TestMethod]
		public void UserString_CreatesUserList()
		{
			var json = @"[
				{
					'_id': 001,
					'url': 'http://initech.zendesk.com/api/v2/users/72.json',
					'external_id': 'e906b32a-1661-4ac3-b7a6-767291d440de',
					'name': 'Mitchell Sutton',
					'alias': 'Sutto',
					'created_at': '2016-05-13T04:57:19 -10:00',
					'active': false,
					'verified': false,
					'shared': true,
					'locale': 'zh-CN',
					'timezone': 'Guinea-Bissau',
					'last_login_at': '2014-02-11T07:15:16 -11:00',
					'email': 'larsenashley@flotonic.com',
					'phone': '8264-832-164',
					'signature': 'Dont Worry Be Happy!',
					'organization_id': 114,
					'tags': [
						'Orviston',
						'Blanford',
					],
					'suspended': true,
					'role': 'end-user'
				},
				{
					'_id': 002,
					'url': 'http://initech.zendesk.com/api/v2/users/72.json',
					'external_id': 'e906b32a-1661-4ac3-b7a6-767291d440de',
					'name': 'Another User',
					'alias': 'Sutto',
					'created_at': '2016-05-13T04:57:19 -10:00',
					'active': false,
					'verified': false,
					'shared': true,
					'locale': 'zh-CN',
					'timezone': 'Guinea-Bissau',
					'last_login_at': '2014-02-11T07:15:16 -11:00',
					'email': 'larsenashley@flotonic.com',
					'phone': '8264-832-164',
					'signature': 'Dont Worry Be Happy!',
					'organization_id': 114,
					'tags': [
						'Orviston',
						'Blanford',
					],
					'suspended': true,
					'role': 'end-user'
				}
			]";

			var result = json.Deserialise<User>();

			Assert.AreEqual(2, result.Count);
			Assert.IsInstanceOfType(result[0], typeof(User));
			Assert.AreEqual(001, result[0].Id);
			Assert.IsInstanceOfType(result[1], typeof(User));
			Assert.AreEqual(002, result[1].Id);
		}
	}
}
