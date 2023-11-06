using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using addressbook_tests_autoit;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count() == 1)
            {
                GroupData group = new GroupData() { Name = "new-name" };
                app.Groups.Add(group);
                oldGroups = app.Groups.GetGroupList();
            }
            GroupData groupForRemove = oldGroups[0];
            app.Groups.Remove(groupForRemove);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
        }
    }
}