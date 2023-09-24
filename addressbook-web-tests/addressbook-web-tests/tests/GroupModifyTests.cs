using NUnit.Framework;

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

            app.GroupHelper.Modify(1, newGroupData);
        }
    }
}
