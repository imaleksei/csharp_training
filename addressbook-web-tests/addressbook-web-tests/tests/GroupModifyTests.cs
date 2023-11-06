using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModifyTests : GroupTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData group = new GroupData("new-group-name");
            group.Header = null;
            group.Footer = null;
            app.GroupHelper.IsGroupElementExistsIfNotThenCreate(1);
            app.Navigation.GoToGroupsPage();
            List<GroupData> oldGroups = GroupData.GetAll();
            if (app.GroupHelper.IsGroupPresent())
            {
                GroupData toBeModificate = oldGroups[0];
                app.GroupHelper.Modify(toBeModificate, group);
            }
            else
            {
                GroupData groupForModificate = new GroupData("new-group-name1");
                groupForModificate.Header = "new-group-header1";
                groupForModificate.Footer = "new-group-footer1";
                app.GroupHelper.Create(groupForModificate);
                app.Navigation.ReturnToGroupsPage();
                oldGroups = GroupData.GetAll();
                GroupData newToBeModificate = oldGroups[0];
                app.GroupHelper.Modify(newToBeModificate, group);
            }
            app.Navigation.ReturnToGroupsPage();
            Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
