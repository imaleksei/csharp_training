using OpenQA.Selenium;
using System.Reflection;

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

        //---

        public GroupHelper IsGroupElementExists(int index, GroupData group)
        {
            var element = driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input"));
            if (element == null)
            {
                Create(group);
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
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span["+ index +"]/input")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
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
            return this;
        }

    }
}
