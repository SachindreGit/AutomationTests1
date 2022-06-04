using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.ControlText;
using Tests.UI.Automated.Domain;
using Tests.UI.Automated.Extensions;
using Tests.UI.Automated.Pages.Bases;
using PlatformType = Tests.UI.Automated.Domain.PlatformType;

namespace Tests.UI.Automated.Pages
{
    public class ShopPage : Page<ShopPageControlText>
    {
        public ShopPage(WebDriver webDriver, PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile)
            : base(webDriver, platformType, cultureInformation, wait, configurationFile)
        {

            WebDriver.FindElement(PageLoadSuccessElement);
        }
        protected override By PageLoadSuccessElement => By.XPath(".//li[@id='nav-shop' and contains(@class,'active')]");

        private By CartNavigation => By.XPath(".//*[@id='nav-cart']/a");
        private const string BuyButtonXpath = ".//*[text()='{0}']/following::p/a[text()='{1}']";
        private const string ProductPriceXpath = ".//*[text()='{0}']/following::p/span[contains(@class,'product-price')]";

        public void ClickBuyButtonOfFunnyCow(int numberOfTimesToClick)
        {
            ClickProductBuyButton(ControlText.FunnyCowItemHeader, numberOfTimesToClick);            
        }
        public void ClickBuyButtonOfFluffyBunny(int numberOfTimesToClick)
        {
            ClickProductBuyButton(ControlText.FluffyBunnyItemHeader, numberOfTimesToClick);
        }
        public void ClickBuyButtonOfStuffedFrog(int numberOfTimesToClick)
        {
            ClickProductBuyButton(ControlText.StuffedFrogItemHeader, numberOfTimesToClick);
        }
        public void ClickBuyButtonOfValentineBear(int numberOfTimesToClick)
        {
            ClickProductBuyButton(ControlText.ValentineBearItemHeader, numberOfTimesToClick);
        }
        public double GetStuffedFrogPrice()
        {
            return GetPriceOfItem(ControlText.StuffedFrogItemHeader);
        }
        public double GetFluffyBunnyPrice()
        {
            return GetPriceOfItem(ControlText.FluffyBunnyItemHeader);
        }
        public double GetValentineBearPrice()
        {
            return GetPriceOfItem(ControlText.ValentineBearItemHeader);
        }
        public CartPage NavigateCartPage()
        {
            WebDriver.FindElement(CartNavigation).Click();
            return new CartPage(WebDriver, PlatformType, CultureInformation, Wait, ConfigurationFile);
        }
        private void ClickProductBuyButton(string productHeaderText, int numberOfTimesToClick)
        { 
           var element = By.XPath(string.Format(BuyButtonXpath, productHeaderText, ControlText.ItemBuyButton));
           WebDriver.Click(element, numberOfTimesToClick);
        }
        private double GetPriceOfItem(string productHeaderText) 
        {
            var element = By.XPath(string.Format(ProductPriceXpath, productHeaderText));
            return double.Parse(WebDriver.FindElement(element).Text.Substring(1));
        }
        protected override ShopPageControlText GetControlText(Domain.PlatformType platformType, CultureInformation cultureInformation)
        {
            return new ShopPageControlText(platformType, cultureInformation);
        }
    }
}
