using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModifyTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            app.Navigation.GoToGroupsPage();
            app.GroupHelper
                .SelectGroup(2)
                .InitEditionGroup();
            GroupData newGroup = new GroupData("new-group-name");
            newGroup.Header = "new-group-header";
            newGroup.Footer = "new-group-footer";
            app.GroupHelper.SubmitEditionGroup();
            app.Login.Logout();
        }
    }
}
