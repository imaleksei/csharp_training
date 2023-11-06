using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void HomePageByUrl()
        {

            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);

        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void AddNewAddressbook()
        {
            if (driver.Url == baseURL + "edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void ReturnToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
