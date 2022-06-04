using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.ControlText;
using Tests.UI.Automated.Domain;
using Tests.UI.Automated.Pages.Bases;

namespace Tests.UI.Automated.Pages
{
    public class CartPage : Page<CartPageControlText>
    {
        public CartPage(WebDriver webDriver, Domain.PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile)
            : base(webDriver, platformType, cultureInformation, wait, configurationFile)
        {

            WebDriver.FindElement(PageLoadSuccessElement);
        }
        
        private By FunnyCowQuantity => GetProductQuantity(ControlText.FunnyCowItemText);
        private By FluffyBunnyQuantity => GetProductQuantity(ControlText.FluffyBunnyItemText);

        private const string ProductPriceXpath = ".//td[contains(text(),'{0}')]/../td[2]";
        private const string ProductSubTotalXpath = ".//td[contains(text(),'{0}')]/../td[4]";
        private const string ProductQuantityXpath = ".//td[contains(text(),'{0}')]/..//input[@name='quantity']";
        private const string TotalXpath = ".//*[contains(@class, 'total')]";
        protected override By PageLoadSuccessElement => By.XPath(".//li[@id='nav-cart' and contains(@class,'active')]");

        public int GetFunnyCowQuantity() 
        {
            return int.Parse(WebDriver.FindElement(FunnyCowQuantity).GetAttribute("value"));
        }
        public double GetStuffedFrogPrice()
        {
            return GetPriceOfItem(ProductPriceXpath, ControlText.StuffedFrogItemText);
        }
        public double GetFluffyBunnyPrice()
        {
            return GetPriceOfItem(ProductPriceXpath, ControlText.FluffyBunnyItemText);
        }
        public double GetValentineBearPrice()
        {
            return GetPriceOfItem(ProductPriceXpath, ControlText.ValentineBearItemText);
        }
        public double GetStuffedFrogSubTotal()
        {
            return GetPriceOfItem(ProductSubTotalXpath, ControlText.StuffedFrogItemText);
        }
        public double GetFluffyBunnySubTotal()
        {
            return GetPriceOfItem(ProductSubTotalXpath, ControlText.FluffyBunnyItemText);
        }
        public double GetValentineBearSubTotal()
        {
            return GetPriceOfItem(ProductSubTotalXpath, ControlText.ValentineBearItemText);
        }
        public double GetTotal()
        {
            var element = By.XPath(TotalXpath);
            return double.Parse(WebDriver.FindElement(element).Text.Split(' ')[1]);
        }
        public int GetFluffyBunnyQuantity()
        {
            return int.Parse(WebDriver.FindElement(FluffyBunnyQuantity).GetAttribute("value"));
        }
        private double GetPriceOfItem(string priceXpath, string productText)
        {
            var element = By.XPath(string.Format(priceXpath, productText));
            return double.Parse(WebDriver.FindElement(element).Text.Substring(1));            
        }
        
        private By GetProductQuantity(string productText)
        {
            return By.XPath(string.Format(ProductQuantityXpath, productText));
        }
        protected override CartPageControlText GetControlText(Domain.PlatformType platformType, CultureInformation cultureInformation)
        {
            return new CartPageControlText(platformType, cultureInformation);
        }
    }
}
