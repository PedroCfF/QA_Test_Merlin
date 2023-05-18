using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Test_Merlin.Test
{
    public static class WebDriverManager
    {
        public static IWebDriver CreateWebDriver()
        {
            return new ChromeDriver();
        }
    }
}
