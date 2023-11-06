using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.IsGroupElementExistsIfNotThenCreate(1);

            List<GroupData> oldGroups = GroupData.GetAll();
            if (app.GroupHelper.IsGroupPresent())
            {
                GroupData toBeRemoved = oldGroups[0];
                app.GroupHelper.Remove(toBeRemoved);
            }
            else
            {
                GroupData groupForRemove = new GroupData("new-name");
                groupForRemove.Header = "new-header";
                groupForRemove.Footer = "new-footer";
                app.GroupHelper.Create(groupForRemove);
                app.Navigation.ReturnToGroupsPage();
                oldGroups = GroupData.GetAll();
                app.GroupHelper.Remove(groupForRemove);
            }
            app.Navigation.ReturnToGroupsPage();
            if (oldGroups.Count <= 0)
            {
                Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());
            }
            else
            {
                Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupCount());
            }
            List<GroupData> newGroups = GroupData.GetAll();
            if (oldGroups.Count > 0)
            {
                oldGroups.RemoveAt(0);
            }

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
