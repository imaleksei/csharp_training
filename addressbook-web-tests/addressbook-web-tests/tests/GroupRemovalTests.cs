using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.IsGroupElementExistsIfNotThenCreate(1);

            app.GroupHelper.Remove(1);
        }
    }
}
