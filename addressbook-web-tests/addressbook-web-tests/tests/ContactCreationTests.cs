using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                {
                    MiddleName = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                 new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactDataFronJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFronJsonFile")]
        public void AddressbookCreationTest(ContactData addressbook)
        {

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Create(addressbook);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Add(addressbook);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}