using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    internal class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData addressbookNewData = new ContactData("new-firstname", "new-lastname");
            addressbookNewData.MiddleName = null;

            app.ContactHelper.Modify("35", addressbookNewData);
        }
    }
}
