using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(0);
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactDetails()
        {
            ContactData fromDetails = app.ContactHelper.GetContactInformationFromDetails(1);
            ContactData fromEdit = app.ContactHelper.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromEdit.AllInfo, fromDetails.AllInfo);

        }
    }
}