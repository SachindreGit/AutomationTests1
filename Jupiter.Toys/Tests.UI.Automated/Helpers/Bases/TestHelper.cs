using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Tests.UI.Automated.Configuration;

namespace Tests.UI.Automated.Helpers
{
    public abstract  class TestHelper
    {
        public IConfigurationFile ConfigurationFile { get; private set; }
        public TestHelper(IConfigurationFile configurationFile)
        {
            ConfigurationFile = configurationFile;
        }
        public DefaultWait<WebDriver> GetWaitInstance(WebDriver driver)
        {
            // Setup implicit wait
            driver.Manage().Timeouts().ImplicitWait = ConfigurationFile.ImplicitWaitTimeOut;

            // Setup fluent wait
            DefaultWait<WebDriver> fluentWait = new DefaultWait<WebDriver>(driver)
            {
                PollingInterval = ConfigurationFile.FluentWaitPollingInterval,
                Timeout = ConfigurationFile.FluentWaitTimeOut,
                Message = "Elemment not found"
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait;
        }
        public void PrepareWebDriver(WebDriver webDriver)
        {
            // We only need to do this if there is more than one window open:
            if (webDriver.WindowHandles.Count == 1)
            {
                return;
            }

            // Get the current window - we'll make this the one that stays open:
            var currentWindowHandle = webDriver.CurrentWindowHandle;
            foreach (var windowHandle in webDriver.WindowHandles)
            {
                if (windowHandle == currentWindowHandle)
                {
                    continue;
                }

                webDriver.SwitchTo().Window(windowHandle);
                webDriver.Close();
            }

            // Switch focus back to the original window:
            webDriver.SwitchTo().Window(currentWindowHandle);
        }

        public void ClearWebDriver(WebDriver webDriver)
        {
            webDriver.Quit();
        }

        public abstract Domain.PlatformType GetPlatformType();
        public abstract WebDriver GetWebDriver();

        protected static DirectoryInfo GetTestUiDirectory()
        {
            var assemblyFile = new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            var directory = assemblyFile.Directory;

            while (directory != null && directory.Name != "Tests.UI.Automated")
            {
                directory = directory.Parent;
            }

            if (directory == null)
            {
                throw new NullReferenceException("directory variable in TestBase.GetTestUiDirectory() cannot be null");
            }

            return directory;
        }
    }
}
