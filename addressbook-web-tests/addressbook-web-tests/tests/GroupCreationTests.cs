using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("group-name");
            group.Header = "group-header";
            group.Footer = "group-footer";

            app.GroupHelper.Create(group);
        }

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.GroupHelper.Create(group);
        }
    }
}