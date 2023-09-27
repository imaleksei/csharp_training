using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData addressbookNewData = new ContactData("new-firstname", "new-lastname");
            addressbookNewData.MiddleName = null;
            app.ContactHelper.IsAddressbookElementExistsIfNotThenCreate(2);

            app.ContactHelper.Modify(2, addressbookNewData);
        }
    }
}
