using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using WebAddressbookTests;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(0);
            List<ContactData> oldContacts = ContactData.GetAll();
            if (app.ContactHelper.IsContactPresent())
            {
                ContactData contactToBeRemoved = oldContacts[0];
                app.ContactHelper.Remove(contactToBeRemoved);
            }
            else
            {
                ContactData contactForRemove = new ContactData("test", "test");
                app.ContactHelper.Create(contactForRemove);
                app.Navigation.ReturnToHomePage();
                oldContacts = ContactData.GetAll();
                app.ContactHelper.Remove(contactForRemove);
            }

            System.Threading.Thread.Sleep(1000);
            app.Navigation.GoToHomePage();
            if (oldContacts.Count <= 0)
            {
                Assert.AreEqual(oldContacts.Count, app.ContactHelper.GetContactCount());
            }
            else
            {
                Assert.AreEqual(oldContacts.Count - 1, app.ContactHelper.GetContactCount());
            }
            List<ContactData> newContacts = ContactData.GetAll();
            if (oldContacts.Count > 0)
            {
                oldContacts.RemoveAt(0);
            }
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
