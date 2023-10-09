﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.Generic;

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

        public ContactHelper Remove(int p)
        {
            ChooseAddressbookElement(p);
            SubmitAddressbookElementDeleting();
            AcceptContactRemovalAlert();
            return this;
        }

        //---

        public ContactHelper IsAddressbookElementExistsIfNotThenCreate(int index)
        {
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
    }
}
