using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.IsGroupElementExistsIfNotThenCreate(1);

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Remove(0);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
