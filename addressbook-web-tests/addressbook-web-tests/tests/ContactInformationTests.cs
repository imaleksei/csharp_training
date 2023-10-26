using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(3);
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(3);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromDetails = app.ContactHelper.GetContactInformationFromDetails(3);
            ContactData fromEdit = app.ContactHelper.GetContactInformationFromEditForm(3);
            Assert.AreEqual(fromDetails.AllInfo, fromEdit.AllInfo);

        }
    }
}