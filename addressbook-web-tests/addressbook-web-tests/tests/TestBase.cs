using NUnit.Framework;
using System.Text;
using System;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        // Генератор псевдослучайных чисел
        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            // Число от 0 до max
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            // Генерация строки
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                // Генерация случайных символов. 223  + 32  - Коды символов в соответсвии с таблицей ASCII и все символы меньше 32 непечатные
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));

            }
            return builder.ToString();

        }
        /*
                [TearDown]
                public void TeardownApplicationManager()
                {
                    //app.ApplicationManagerClose();
                }
        */
    }
}
