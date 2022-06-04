using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tests.UI.Automated.Configuration;
using Tests.UI.Automated.Domain;
using PlatformType = Tests.UI.Automated.Domain.PlatformType;

namespace Tests.UI.Automated.Pages.Bases
{
    public abstract class Page<TControlText> where TControlText: ControlText.Bases.ControlText
    {
        public IConfigurationFile ConfigurationFile { get; private set; }
        public WebDriver WebDriver { get; private set; }
        public PlatformType PlatformType { get; private set; }
        public TControlText ControlText { get; private set; }
        public CultureInformation CultureInformation { get; private set; }
        public DefaultWait<WebDriver> Wait { get; private set; }
        protected abstract By PageLoadSuccessElement { get; }
        public Page(WebDriver webDriver, PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile) 
        {
            ConfigurationFile = configurationFile;
            WebDriver = webDriver;
            PlatformType = platformType;
            CultureInformation = cultureInformation;
            Wait = wait;
            ControlText = GetControlText(platformType, cultureInformation);
        }
        protected abstract TControlText GetControlText(PlatformType platformType, CultureInformation cultureInformation);
    }
}
