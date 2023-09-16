using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigation.GoToGroupsPage();
            app.GroupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("group-name");
            group.Header = "group-header";
            group.Footer = "group-footer";
            app.GroupHelper
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            app.Login.Logout();
        } 
    }
}