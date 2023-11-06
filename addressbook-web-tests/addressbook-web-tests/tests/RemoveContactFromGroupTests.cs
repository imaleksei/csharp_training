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
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();
            GroupData group = new GroupData();
            ContactData contactForRemove = new ContactData();
            List<ContactData> oldList = new List<ContactData>();
            int count = 0;
            foreach (GroupData g in groups)
            {
                List<ContactData> contactsInGroup = g.GetContacts();
                if (contactsInGroup.Count > 0)
                {
                    contactForRemove = contactsInGroup[0];
                    group = g;
                    oldList = group.GetContacts();
                    break;
                }
                count++;
                if (count == groups.Count)
                {
                    ContactData contactForAdd = ContactData.GetAll()[0];
                    GroupData groupForAdd = GroupData.GetAll()[0];
                    app.ContactHelper.AddContactToGroup(contactForAdd, groupForAdd);
                    contactForRemove = contactForAdd;
                    group = groupForAdd;
                    oldList = group.GetContacts();
                }
            }

            app.ContactHelper.RemoveContactFromGroup(contactForRemove, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactForRemove);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}