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
            ContactData addressbookNewData = new ContactData("new-firstname", "new-lastname");
            addressbookNewData.MiddleName = null;
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(0);

            List<ContactData> oldContacts = ContactData.GetAll();
            if (app.ContactHelper.IsContactPresent())
            {
                ContactData toBeModificate = oldContacts[0];
                app.ContactHelper.Modify(toBeModificate, addressbookNewData);
            }
            else
            {
                ContactData contactForModificate = new ContactData("new-firstname1", "new-lastname1");
                app.ContactHelper.Create(contactForModificate);
                app.Navigation.ReturnToHomePage();
                oldContacts = ContactData.GetAll();
                ContactData newToBeModificate = oldContacts[0];
                app.ContactHelper.Modify(newToBeModificate, addressbookNewData);
            }
            app.Navigation.ReturnToHomePage();
            Assert.AreEqual(oldContacts.Count, app.ContactHelper.GetContactCount());
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[0].LastName = addressbookNewData.LastName;
            oldContacts[0].FirstName = addressbookNewData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
