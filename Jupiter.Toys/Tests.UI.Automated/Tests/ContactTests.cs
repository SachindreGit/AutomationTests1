using NUnit.Framework;
using System;
using Tests.UI.Automated.Domain;
using Tests.UI.Automated.Pages;
using Tests.UI.Automated.Tests.Bases;

namespace Tests.UI.Automated.Tests
{
    public class ContactTests: TestBase
    {
        private readonly CultureInformation _userCulture = new CultureInformation(CultureType.English, "en");

        /// <summary>
        /// Test case 1
        /// </summary>
        [Test]
        public void ContactSubmitValidateErrors()
        {
            var forename = "Nirmaan";
            var email = "test@gmail.com";
            var message = "I am interested in toy cars";

            // From the home page go to contact page
            Console.WriteLine("From the home page go to contact page");
            var homePage = HomePage.NavigateHome(WebDriver, PlatformType, _userCulture, Wait, ConfigurationFile);
            var contactPage = homePage.NavigateContactPage();

            // Click submit button
            Console.WriteLine("Click submit button");
            contactPage.ClickSubmitButton();

            // Validate errors
            Console.WriteLine("Validate errors");
            var actualForeNameErrorMessage = contactPage.GetForenameFieldErrorMessage();
            var actualEmailErrorMessage = contactPage.GetEmailFieldErrorMessage();
            var actualMessageErrorMessage = contactPage.GetMessageFieldErrorMessage();

            var expectedForeNameErrorMessage = contactPage.ControlText.ForenameRequiredErrorMessage;
            var expectedEmailErrorMessage = contactPage.ControlText.EmailRequiredErrorMessage;
            var expectedMessageErrorMessage = contactPage.ControlText.MessageRequiredErrorMessage;

            Assert.AreEqual(expectedForeNameErrorMessage, actualForeNameErrorMessage, 
                $"Required error message of Forename field is incorrect. Expected: '{expectedForeNameErrorMessage}', Actual: '{actualForeNameErrorMessage}'");
            Assert.AreEqual(expectedEmailErrorMessage, actualEmailErrorMessage,
                $"Required error message of Email field is incorrect. Expected: '{expectedEmailErrorMessage}', Actual: '{actualEmailErrorMessage}'");
            Assert.AreEqual(expectedMessageErrorMessage, actualMessageErrorMessage,
                $"Required error message of Message field is incorrect. Expected: '{expectedMessageErrorMessage}', Actual: '{actualMessageErrorMessage}'");

            // Populate mandatory fields
            Console.WriteLine("Populate mandatory fields");
            contactPage.PopulateForename(forename);
            contactPage.PopulateEmail(email);
            contactPage.PopulateMessage(message);

            // Validate errors are gone
            Console.WriteLine("Validate errors are gone");
            Assert.IsFalse(contactPage.IsForenameValidationErrorDisplayed(), "Required error message of Forename field is still available");
            Assert.IsFalse(contactPage.IsEmailValidationErrorDisplayed(), "Required error message of Email field is still available");
            Assert.IsFalse(contactPage.IsMessageValidationErrorDisplayed(), "Required error message of Message field is still available");
        }

        /// <summary>
        /// Test case 2
        /// </summary>
        [Test]
        [Repeat(5)]
        public void ContactSubmitValidation() 
        {
            // From the home page go to contact page
            Console.WriteLine("From the home page go to contact page");
            var homePage = HomePage.NavigateHome(WebDriver, PlatformType, _userCulture, Wait, ConfigurationFile);
            var contactPage = homePage.NavigateContactPage();

            // Populate mandatory fields
            Console.WriteLine("Populate mandatory fields");
            var forename = "Nirmaan";
            var email = "test@gmail.com";
            var message = "I am interested in toy cars";

            contactPage.PopulateForename(forename);
            contactPage.PopulateEmail(email);
            contactPage.PopulateMessage(message);

            // Click submit button
            Console.WriteLine("Click submit button");
            contactPage.ClickSubmitButton();

            // Validate successful submission message
            Console.WriteLine("Validate successful submission message");
            Assert.IsTrue(contactPage.IsSuccessfullySubmittedMessageDisplayed(), "Successfully submitted message not displayed after successful submission");

            var successfullySubmittedMessageExpected = string.Format(contactPage.ControlText.SuccessfullySubmittedMessage, forename);
            var successfullySubmittedMessageActual = contactPage.GetSuccessfullySubmittedMessageText();

            Assert.AreEqual(successfullySubmittedMessageExpected, successfullySubmittedMessageActual,
                $"Successfully submitted message is incorrect. Expected: '{successfullySubmittedMessageExpected}', Actual: '{successfullySubmittedMessageActual}'");
        }     
    }
}
