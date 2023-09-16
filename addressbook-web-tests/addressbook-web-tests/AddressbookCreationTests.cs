using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class AddressbookCreationTests : TestBase
    {

        [Test]
        public void AddressbookCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewAddressbook();
            AddressbookData addressbook = new AddressbookData("firstname", "lastname");
            FillAddressbookForm(addressbook);
            SubmitAddressbookForm();
            GoToHomePage();
            Logout();
        }
    }
}