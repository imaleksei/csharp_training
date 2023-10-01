using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void AddressbookCreationTest()
        {
            ContactData addressbook = new ContactData("firstname", "lastname");

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