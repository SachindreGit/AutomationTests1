using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.UI.Automated.Configuration;

namespace Tests.UI.Automated.Helpers
{
    public class ChromePremiumTestHelper : TestHelper
    {
        public ChromePremiumTestHelper(IConfigurationFile configurationFile):base(configurationFile) 
        {
            //No implementation
        }
        public override Domain.PlatformType GetPlatformType()
        {
            return Domain.PlatformType.Premium;
        }

        public override WebDriver GetWebDriver()
        {
            var options = new ChromeOptions();

            // This enables pop ups as in a real browser
            options.AddExcludedArguments("disable-popup-blocking");
            
#if DEBUG
            // When in debug mode we have a real browser running the tests. Hence start-maximized argument works on the real browser.
            options.AddArgument("start-maximized");
#else
            // When tests are running in headless mode, start-maximized argument does not work because a real browser is not presented.
            // So we specifies the width and height of the headless browser. 
            options.AddArguments("--headless", "--window-size=1366,768");
#endif
            return new ChromeDriver(GetTestUiDirectory().FullName, options);
        }
    }
}
