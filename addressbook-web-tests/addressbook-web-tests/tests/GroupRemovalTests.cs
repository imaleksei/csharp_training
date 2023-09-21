using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupsPage();
            app.GroupHelper
                .SelectGroup(2)
                .RemoveGroup()
                .ReturnToGroupsPage();
            app.Login.Logout();
        }
    }
}
