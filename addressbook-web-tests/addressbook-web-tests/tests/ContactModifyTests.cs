using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData addressbookNewData = new ContactData("new-firstname", "new-lastname");
            addressbookNewData.MiddleName = null;
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(0);

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Modify(0, addressbookNewData);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[0].FirstName = addressbookNewData.FirstName;
            oldContacts[0].LastName = addressbookNewData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
