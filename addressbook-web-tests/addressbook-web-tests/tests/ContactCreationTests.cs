using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                {
                    MiddleName = GenerateRandomString(20)
                });
            }
            return contact;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void AddressbookCreationTest(ContactData addressbook)
        {

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Create(addressbook);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Add(addressbook);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}