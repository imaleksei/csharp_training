using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
