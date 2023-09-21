using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    internal class ContactModifyTests : TestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            app.ContactHelper.InitAddressbookElementEditing();
            ContactData addressbook = new ContactData("new-firstname", "new-lastname");
            app.ContactHelper.SubmitAddressbookElementEditing();
            app.Login.Logout();
        }
    }
}
