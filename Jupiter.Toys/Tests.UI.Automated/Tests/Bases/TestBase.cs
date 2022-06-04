using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.Helpers;
using Tests.UI.Automated.Helpers.Factories;

namespace Tests.UI.Automated.Tests.Bases
{
    [TestFixture]
    public class TestBase
    {
        protected IConfigurationFile ConfigurationFile { get; private set; }
        protected WebDriver WebDriver { get; private set; }
        protected DefaultWait<WebDriver> Wait { get; private set; }
        protected Domain.PlatformType PlatformType { get; private set; }
        protected TestHelper TestHelper { get; private set; }
        public TestBase()
        {
            ConfigurationFile = new ConfigurationFile();
            var testHelperFactory = new TestHelperFactory(ConfigurationFile);
            TestHelper = testHelperFactory.GetTestHelper(ConfigurationFile.BrowserType);

            WebDriver = TestHelper.GetWebDriver();
            Wait = TestHelper.GetWaitInstance(WebDriver);
            PlatformType = TestHelper.GetPlatformType();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            OneTimeSetUpExtension();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestHelper.ClearWebDriver(WebDriver);
            OneTimeTearDownExtension();
        }

        [SetUp]
        public void SetUp()
        {
            TestHelper.PrepareWebDriver(WebDriver);
            SetUpExtension();
        }

        [TearDown]
        public void TearDown()
        {
            // TODO: We can add code here to get a screenshot from web driver and save it in screenshots folder to refer later.

            TearDownExtension();
        }

        // If needed can implement in test classes
        public virtual void OneTimeSetUpExtension() 
        { 
        }

        // If needed can implement in test classes
        public virtual void OneTimeTearDownExtension()
        {
        }

        // If needed can implement in test classes
        public virtual void SetUpExtension()
        {
        }

        // If needed can implement in test classes
        public virtual void TearDownExtension()
        {
        }

        

    }
}
