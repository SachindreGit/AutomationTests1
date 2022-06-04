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
    public class ContactPage: Page<ContactPageControlText>
    {
        public ContactPage(WebDriver webDriver, PlatformType platformType, CultureInformation cultureInformation, DefaultWait<WebDriver> wait, IConfigurationFile configurationFile) 
            : base(webDriver, platformType, cultureInformation, wait, configurationFile) 
        {

            WebDriver.FindElement(PageLoadSuccessElement);
        }

        private By SubmitButton => By.XPath(".//*[contains(@class,'btn-contact')]");
        private By ForeNameFieldError => By.Id("forename-err");
        private By EmailFieldError => By.Id("email-err");
        private By MessageFieldError => By.Id("message-err");
        private By ForeNameField => By.Id("forename");
        private By EmailField => By.Id("email");
        private By MessageField => By.Id("message");
        private By SuccessfullySubmittedMessage => By.XPath(".//*[contains(@class,'alert-success')]");
        protected override By PageLoadSuccessElement => By.XPath(".//li[@id='nav-contact' and contains(@class,'active')]");

        public string GetForenameFieldErrorMessage()
        {
            return WebDriver.FindElement(ForeNameFieldError).Text;
        }
        public string GetEmailFieldErrorMessage() 
        {
            return WebDriver.FindElement(EmailFieldError).Text;
        }
        public string GetMessageFieldErrorMessage()
        {
            return WebDriver.FindElement(MessageFieldError).Text;
        }
        public void ClickSubmitButton() 
        {

            WebDriver.FindElement(SubmitButton).Click();
        }
        public void PopulateForename(string foreName) {
            WebDriver.FindElement(ForeNameField).SendKeys(foreName);
        }
        public void PopulateEmail(string email)
        {
            WebDriver.FindElement(EmailField).SendKeys(email);
        }
        public void PopulateMessage(string message)
        {
            WebDriver.FindElement(MessageField).SendKeys(message);
        }
        public bool IsForenameValidationErrorDisplayed() {
            return WebDriver.IsElimentVisible(ForeNameFieldError);
        }
        public bool IsEmailValidationErrorDisplayed()
        {
            return WebDriver.IsElimentVisible(EmailFieldError);
        }
        public bool IsMessageValidationErrorDisplayed()
        {
            return WebDriver.IsElimentVisible(MessageFieldError);
        }
        public bool IsSuccessfullySubmittedMessageDisplayed()
        {
            var successMessageElement = WebDriver.FindElementWithFluentWait(Wait, SuccessfullySubmittedMessage);
            return successMessageElement.Displayed;
        }
        public string GetSuccessfullySubmittedMessageText()
        {
            return WebDriver.FindElement(SuccessfullySubmittedMessage).Text;
        }
        protected override ContactPageControlText GetControlText(PlatformType platformType, CultureInformation cultureInformation)
        {
            return new ContactPageControlText(platformType, cultureInformation);
        }
    }
}
