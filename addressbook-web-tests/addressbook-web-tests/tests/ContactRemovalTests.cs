using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.ContactHelper
                .ChooseAddressbookElement("19")
                .SubmitAddressbookElementDeleting();
            app.ContactHelper.AcceptAlert();
            app.Login.Logout();
        }
    }
}
