using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

// run 2 instances of VS to do run Selenium tests against localhost
// instance 1 : run web app e.g. on IIS Express
// instance 2 : from Test Explorer run Selenium test
// or use the dotnet vstest task
// e.g. dotnet vstest seleniumtest\bin\debug\netcoreapp3.1\seleniumtest.dll /Settings:seleniumtest.runsettings

namespace SeleniumTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UnitTest1
    {
        // test harness uses this property to initliase test context
        public TestContext TestContext { get; set; }

        // URI for web app being tested
        private String webAppUri;

        // .runsettings property overriden in vsts test runner 
        // release task to point to run settings file
        // also webAppUri overriden to use pipeline variable

        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            // read URL from SeleniumTest.runsettings
            this.webAppUri = TestContext.Properties["webAppUri"].ToString();
            //this.webAppUri = "http://localhost:53135/";
        }

        [TestMethod]
        public void TestBPCalculator()
        {

            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            var chrome_options = new ChromeOptions();
            chrome_options.AddArguments("--headless");
            chrome_options.AddArguments("--no-sandbox");
            chrome_options.AddArguments("--disable-dev-shm-usage");

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath,chrome_options))
            {
                // any exception below results in a test fail

                // navigate to URI for temperature converter
                // web app running on IIS express
                driver.Navigate().GoToUrl(webAppUri);
                
                Thread.Sleep(20000); // give the page 20 seconds to load before testing

                // get Systolic element, clear existing contents and submit new
                IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));
                systolicElement.Clear();
                systolicElement.SendKeys("170");

                // get Diastolic element, clear existing contents and submit new
                IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
                diastolicElement.Clear();
                diastolicElement.SendKeys("40");

                // submit the form
                driver.FindElement(By.Id("form1")).Submit();

                // explictly wait for result with "BPvalue" item
                IWebElement BPvalueElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("BPvalue")));

                // item comes back like "High Blood Pressure"
                String bpVal = BPvalueElement.Text.ToString();

                StringAssert.EndsWith(bpVal, "High Blood Pressure");

                driver.Dispose();
                driver.Quit();

                // alternative - use Cypress or Playright
            }
        }        
    }
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UnitTest2
    {
        // test harness uses this property to initliase test context
        public TestContext TestContext { get; set; }

        // URI for web app being tested
        private String webAppUri;

        // .runsettings property overriden in vsts test runner 
        // release task to point to run settings file
        // also webAppUri overriden to use pipeline variable

        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            // read URL from SeleniumTest.runsettings
            this.webAppUri = TestContext.Properties["webAppUri"].ToString();
            //this.webAppUri = "http://localhost:53135/";
        }

        [TestMethod]
        public void TestFeatuteText()
        {

            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            var chrome_options = new ChromeOptions();
            chrome_options.AddArguments("--headless");
            chrome_options.AddArguments("--no-sandbox");
            chrome_options.AddArguments("--disable-dev-shm-usage");

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath, chrome_options))
            {
                // any exception below results in a test fail

                // navigate to URI for temperature converter
                // web app running on IIS express
                driver.Navigate().GoToUrl(webAppUri);

                Thread.Sleep(20000); // give the page 20 seconds to load before testing

                // get Systolic element, clear existing contents and submit new
                IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));
                systolicElement.Clear();
                systolicElement.SendKeys("170");

                // get Diastolic element, clear existing contents and submit new
                IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
                diastolicElement.Clear();
                diastolicElement.SendKeys("40");

                // submit the form
                driver.FindElement(By.Id("form1")).Submit();

                // click the info button
                driver.FindElement(By.Id("infoBtn")).Click();

                // explictly wait for result with "BPvalue" item
                IWebElement spielElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("spiel")));

                // item comes back like "High Blood Pressure"
                String spiel = spielElement.Text.ToString();

                StringAssert.StartsWith(spiel, "Your blood pressure is high.");

                driver.Dispose();
                driver.Quit();

                // use this in CMD if chromdriver blocks a rebuild
                // taskkill /f /im chromedriver.exe 
            }
        }
    }
}