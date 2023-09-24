using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModifyTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData newGroupData = new GroupData("new-group-name");
            newGroupData.Header = "new-group-header";
            newGroupData.Footer = "new-group-footer";

            app.GroupHelper.Modify(1, newGroupData);
        }
    }
}
