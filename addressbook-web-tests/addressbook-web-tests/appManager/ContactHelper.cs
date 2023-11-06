using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptContactRemovalAlert = true;

        public ContactHelper(ApplicationManager manager)
            : base(manager) { }

        public ContactHelper Create(ContactData addressbook)
        {
            manager.Navigation.AddNewAddressbook();
            FillAddressbookForm(addressbook);
            SubmitAddressbookForm();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData addressbookNewData)
        {
            ChooseAddressbookElement(p);
            InitAddressbookElementEditing();
            FillAddressbookForm(addressbookNewData);
            SubmitAddressbookElementEditing();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, ContactData addressbookNewData)
        {
            SelectContact(contact.Id);
            InitAddressbookElementEditing();
            FillAddressbookForm(addressbookNewData);
            SubmitAddressbookElementEditing();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            ChooseAddressbookElement(p);
            SubmitAddressbookElementDeleting();
            AcceptContactRemovalAlert();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
            SubmitAddressbookElementDeleting();
            AcceptContactRemovalAlert();
            return this;
        }

        //---

        public ContactHelper IsAddressbookElementExistsIfNotThenCreate(int index)
        {
            manager.Navigation.GoToHomePage();
            try
            {
                bool element = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td")).Displayed
                             & driver.FindElement(By.XPath("//img[@alt='Edit']")).Displayed;
            }
            catch (NoSuchElementException)
            {
                ContactData contactNewCreated = new ContactData("newly-created-firstname", "newly-created-lastname");
                this.Create(contactNewCreated);
            }
            return this;
        }

        public ContactHelper FillAddressbookForm(ContactData addressbook)
        {
            Type(By.Name("firstname"), addressbook.FirstName);
            Type(By.Name("middlename"), addressbook.MiddleName);
            Type(By.Name("lastname"), addressbook.LastName);
            Type(By.Name("nickname"), addressbook.Nickname);
            driver.FindElement(By.Name("photo")).SendKeys(addressbook.Photo);
            Type(By.Name("title"), addressbook.Title);
            Type(By.Name("company"), addressbook.Company);
            Type(By.Name("address"), addressbook.Address);
            Type(By.Name("home"), addressbook.Home);
            Type(By.Name("mobile"), addressbook.Mobile);
            Type(By.Name("work"), addressbook.Work);
            Type(By.Name("fax"), addressbook.Fax);
            Type(By.Name("email"), addressbook.EmailOne);
            Type(By.Name("email2"), addressbook.EmailTwo);
            Type(By.Name("email3"), addressbook.EmailThree);
            Type(By.Name("homepage"), addressbook.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(addressbook.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(addressbook.Bmonth);
            Type(By.Name("byear"), addressbook.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(addressbook.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(addressbook.Amonth);
            Type(By.Name("ayear"), addressbook.Ayear);
            Type(By.Name("address2"), addressbook.AddressTwo);
            Type(By.Name("phone2"), addressbook.PhoneTwo);
            Type(By.Name("notes"), addressbook.Notes);
            return this;
        }

        public ContactHelper SubmitAddressbookForm()
        {
            driver.FindElement(By.XPath("//input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ChooseAddressbookElement(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td")).Click();
            return this;
        }

        public ContactHelper SubmitAddressbookElementDeleting()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitAddressbookElementEditing()
        {
            driver.FindElement(By.CssSelector("img[alt=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper MakeAddressbookEdition(int index)
        {
            driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitAddressbookElementEditing()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        
        public string AcceptContactRemovalAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptContactRemovalAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptContactRemovalAlert = true;
            }
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null) 
            {
                contactCache = new List<ContactData>();
                //manager.Navigation.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
                int count = 0;
                foreach (IWebElement element in elements)
                {
                    count++;
                    contactCache.Add(new ContactData(element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[3]")).Text,
                        element.FindElement(By.XPath("//tr[@class = 'odd' or @name = 'entry'][" + count + "]//td[2]")).Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value = '" + id + "'])")).Click();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@class = 'odd' or @name = 'entry']")).Count;
        }

        //---

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index-1].FindElements(By.TagName("td"));
            string firstname = cells[2].Text;
            string lastname = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                AllPhones = allPhones,
            };

        }
        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.GoToHomePage();
            MakeAddressbookEdition(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phoneTwo = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string emailOne = driver.FindElement(By.Name("email")).GetAttribute("value");
            string emailTwo = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string emailThree = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string addressTwo = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


            return new ContactData(firstname, lastname)
            {
                MiddleName = middlename,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                PhoneTwo = phoneTwo,
                Nickname = nickname,
                Company = company,
                Title = title,
                Fax = fax,
                EmailOne = emailOne,
                EmailTwo = emailTwo,
                EmailThree = emailThree,
                AddressTwo = addressTwo,
                Homepage = homepage,
                Notes = notes
            };

        }

        public void GoToContactDetails(int index)
        {
            manager.Navigation.GoToHomePage();
            driver.FindElement(By.XPath("(//form[@name='MainForm']//img[@title='Details'])[" + index + "]")).Click();
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigation.GoToHomePage();
            GoToContactDetails(index);
            string allInfo = driver.FindElement(By.XPath("//div[@id = 'content']")).Text;
            return new ContactData()
            {
                AllInfo = allInfo
            };
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        private void SelectContactById(string contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ComitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.GoToHomePage();
            ClearGroupFilter();
            SelectContactById(contact.Id);
            SelectGroupToAdd(group.Name);
            ComitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void GroupFilterByName(String groupName)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupName);
        }
        public void RemoveContactFromgroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigation.GoToHomePage();
            GroupFilterByName(group.Name);
            SelectContactById(contact.Id);
            RemoveContactFromgroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            manager.Navigation.GoToHomePage();

        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.XPath("//tr[@class = 'odd' or @name = 'entry']"));
        }
    }
}
