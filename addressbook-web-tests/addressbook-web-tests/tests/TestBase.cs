using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigation.OpenHomePage();
            app.Login.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Login.Logout();
            app.Stop();
        }
    }
}
