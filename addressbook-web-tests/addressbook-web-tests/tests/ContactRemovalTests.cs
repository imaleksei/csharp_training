using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(2);

            app.ContactHelper.Remove(2);
        }
    }
}
