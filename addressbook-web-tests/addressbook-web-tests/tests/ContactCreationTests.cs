using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void AddressbookCreationTest()
        {
            ContactData addressbook = new ContactData("firstname", "lastname");

            app.ContactHelper.Create(addressbook);
        }
    }
}