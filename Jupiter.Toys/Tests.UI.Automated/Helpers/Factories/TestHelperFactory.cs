using System;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.Domain;

namespace Tests.UI.Automated.Helpers.Factories
{
    public class TestHelperFactory
    {
        protected IConfigurationFile ConfigurationFile { get; private set; }
        public TestHelperFactory(IConfigurationFile configurationFile) 
        {
            ConfigurationFile = configurationFile;
        }
        public TestHelper GetTestHelper(BrowserType browserType) {
            switch (browserType) {
                case BrowserType.ChromePremium:
                    return new ChromePremiumTestHelper(ConfigurationFile);

                // For other browser types, we can create test helper objects
                // ex:
                //case BrowserType.SafariMacSauceLabs:
                //    return new SafariMacSauceLabsTestHelper();

                default:
                    var message = string.Format("Could not create WebDriver for BrowserType '{0}'", browserType);
                    throw new InvalidOperationException(message);
            }
        }
    }
}
