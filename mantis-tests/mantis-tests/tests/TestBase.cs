﻿using System;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            app.Auth.Login(new AccountData("administrator", "root"));

        }

        public static Random random = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(random.NextDouble() * max);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                sb.Append(Convert.ToChar(32 + Convert.ToInt32(random.NextDouble() * 65)));
            }
            return sb.ToString();

        }
    }
}