using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void AddressbookCreationTest()
        {
            app.Navigation.AddNewAddressbook();
            ContactData addressbook = new ContactData("firstname", "lastname");
            app.ContactHelper
                .FillAddressbookForm(addressbook)
                .SubmitAddressbookForm();
            app.Navigation.GoToHomePage();
            app.Login.Logout();
        }
    }
}