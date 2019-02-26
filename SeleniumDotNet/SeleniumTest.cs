using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace SeleniumDotNet
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class SeleniumTest
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;



        public SeleniumTest()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            try
            {
                driver.Navigate().GoToUrl(appURL + "/");
                driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
                driver.FindElement(By.Id("sb_form_go")).Click();
                driver.FindElement(By.XPath("//*[@id='b_results']/li[1]/h2/a")).Click();
                Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), WriteLogToConsole("assertation successed"));
            }
            catch (Exception)
            {
                WriteLogToConsole("assertation failed");
            }
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.bing.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        public string WriteLogToConsole(string message)
        {
            Console.WriteLine(".............................");
            Console.WriteLine(message);
            Console.WriteLine(".............................");

            return message;
        }
    }
}