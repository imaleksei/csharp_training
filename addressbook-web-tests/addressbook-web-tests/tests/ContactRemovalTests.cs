using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(0);
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Remove(0);
            
            app.Navigation.GoToHomePage();
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
