using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.ControlText;
using Tests.UI.Automated.Domain;
using Tests.UI.Automated.Pages.Bases;
using PlatformType = Tests.UI.Automated.Domain.PlatformType;

namespace Tests.UI.Automated.Pages
{
    public class HomePage : Page<HomePageControlText>
    {
        public HomePage(WebDriver webDriver, PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile)
            : base(webDriver, platformType, cultureInformation, wait, configurationFile)
        {            
            WebDriver.FindElement(PageLoadSuccessElement);
        }

        private By ContactNavigation => By.XPath(".//*[@id='nav-contact']/a");
        private By ShopNavigation => By.XPath(".//*[@id='nav-shop']/a");

        protected override By PageLoadSuccessElement => By.XPath(".//li[@id='nav-home' and contains(@class,'active')]");

        public ContactPage NavigateContactPage() 
        {
            WebDriver.FindElement(ContactNavigation).Click();
            return new ContactPage(WebDriver, PlatformType, CultureInformation, Wait, ConfigurationFile);
        }
        public ShopPage NavigateShopPage()
        {
            WebDriver.FindElement(ShopNavigation).Click();
            return new ShopPage(WebDriver, PlatformType, CultureInformation, Wait, ConfigurationFile);
        }
        public static HomePage NavigateHome(WebDriver webDriver, PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile) 
        {
            webDriver.Navigate().GoToUrl(configurationFile.ApplicatinUrl);
            return new HomePage(webDriver, platformType, cultureInformation, wait, configurationFile);
        }
        protected override HomePageControlText GetControlText(PlatformType platformType, CultureInformation cultureInformation)
        {
            return new HomePageControlText(platformType, cultureInformation);
        }
    }
}
