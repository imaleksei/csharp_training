using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModifyTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData newGroupData = new GroupData("new-group-name");
            newGroupData.Header = null;
            newGroupData.Footer = null;
            app.GroupHelper.IsGroupElementExistsIfNotThenCreate(1);

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Modify(0, newGroupData);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
