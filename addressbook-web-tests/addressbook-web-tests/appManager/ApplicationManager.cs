using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace WebAddressBookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }


        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
                try 
                {
                    driver.SwitchTo().Alert().Accept();
                }
                catch (Exception) 
                { 
                }
            }
            catch (Exception)
            {
            }
        }
/*
        public void ApplicationManagerClose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }
*/
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        {
            get 
            {
                return driver;
            }
        }
  
        public LoginHelper Auth
        { get { return loginHelper; } }

        public NavigationHelper Navigation
        { get { return navigationHelper; } }

        public GroupHelper GroupHelper
        { get { return groupHelper; } }

        public ContactHelper ContactHelper
        { get { return contactHelper; } }
    }
}
