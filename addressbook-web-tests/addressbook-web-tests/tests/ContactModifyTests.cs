using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModifyTests : ContactTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData addressbookNewData = new ContactData("new-firstname-test", "new-lastname-test");
            addressbookNewData.MiddleName = null;
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(1);

            List<ContactData> oldContacts = ContactData.GetAll();
            if (app.ContactHelper.IsContactPresent())
            {
                ContactData toBeModificate = oldContacts[1];
                app.ContactHelper.Modify(toBeModificate, addressbookNewData);
            }
            else
            {
                ContactData contactForModificate = new ContactData("new-firstname1", "new-lastname1");
                app.ContactHelper.Create(contactForModificate);
                app.Navigation.ReturnToHomePage();
                oldContacts = ContactData.GetAll();
                ContactData newToBeModificate = oldContacts[1];
                app.ContactHelper.Modify(newToBeModificate, addressbookNewData);
            }
            app.Navigation.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count, app.ContactHelper.GetContactCount());
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[1].LastName = addressbookNewData.LastName;
            oldContacts[1].FirstName = addressbookNewData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
