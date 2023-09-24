using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    internal class ContactModifyTests : TestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData addressbookNewData = new ContactData("new-firstname", "new-lastname");
            addressbookNewData.MiddleName = "new-middlename";

            app.ContactHelper.Modify(addressbookNewData);
        }
    }
}
