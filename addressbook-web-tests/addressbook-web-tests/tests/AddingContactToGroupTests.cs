using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using WebAddressBookTests;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroupTest()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<ContactData> contactList = ContactData.GetAll();
            if (groupList.Count == 0)
            {
                app.GroupHelper.Create(new GroupData("fName"));
                groupList = GroupData.GetAll();
            }
            if (contactList.Count == 0)
            {
                app.ContactHelper.Create(new ContactData("fName", "lName"));
                contactList = ContactData.GetAll();
            }
            int count = 0;
            foreach (GroupData g in groupList)
            {
                List<ContactData> contactsInGroup = g.GetContacts();
                contactList.Sort();
                contactsInGroup.Sort();
                if (contactList.Count() != contactsInGroup.Count())
                {
                    ContactData contact = contactList.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.ContactHelper.AddContactToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }
                count++;
                if (count == groupList.Count())
                {
                    app.ContactHelper.Create(new ContactData("fName1", "lName1"));
                    contactList = ContactData.GetAll();
                    ContactData contact = contactList.Except(contactsInGroup).First();
                    List<ContactData> oldList = g.GetContacts();
                    app.ContactHelper.AddContactToGroup(contact, g);
                    List<ContactData> newList = g.GetContacts();
                    oldList.Add(contact);
                    oldList.Sort();
                    newList.Sort();
                    Assert.AreEqual(oldList, newList);
                }
            }
        }
    }
}