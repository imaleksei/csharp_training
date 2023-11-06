using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
            : base(manager) { }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigation.GoToGroupsPage();
            
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newGroupData)
        {
            manager.Navigation.GoToGroupsPage();

            SelectGroup(p);
            InitEditionGroup();
            FillGroupForm(newGroupData);
            SubmitEditionGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData group, GroupData groupModificate)
        {
            manager.Navigation.GoToGroupsPage();

            SelectGroup(group.Id);
            InitEditionGroup();
            FillGroupForm(groupModificate);
            SubmitEditionGroup();
            ReturnToGroupsPage();
            return this;
        }

        //---

        public GroupHelper IsGroupElementExistsIfNotThenCreate(int index)
        {
            try
            {
                bool element = driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Displayed;
            }
            catch (NoSuchElementException)
            {
                GroupData groupNewCreated = new GroupData("newly-created-group-name");
                this.Create(groupNewCreated);
            }
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Id("content")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span["+ (index+1) +"]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitEditionGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitEditionGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigation.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }
            return new List<GroupData>(groupCache);
        }

        public bool IsGroupPresent()
        {
            return IsElementPresent(By.XPath("//span[@class = 'group']"));
        }

        public GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }

        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            RemoveGroup();
            return this;
        }
    }
}
