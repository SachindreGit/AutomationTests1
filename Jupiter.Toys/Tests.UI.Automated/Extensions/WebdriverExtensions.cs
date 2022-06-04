using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Tests.UI.Automated.Extensions
{
    public static class WebdriverExtensions
    {
        public static bool IsElimentVisible(this IWebDriver driver, By elementToWaitFor)
        {
            var endTime = DateTime.Now.Add(TimeSpan.FromSeconds(3));
            while (true)
            {
                if (DateTime.Now > endTime)
                {
                    return true;
                }

                try
                {
                    var element = driver.FindElement(elementToWaitFor);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }                
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
        }

        public static IWebElement FindElementWithFluentWait(this WebDriver driver, DefaultWait<WebDriver> wait, By element)
        {
            return wait.Until(x => x.FindElement(element));
        }
        public static void Click(this WebDriver driver, By element, int numberOfTimesToClick)
        {
            var elementFound = driver.FindElement(element);
            for (int i = 0; i < numberOfTimesToClick; i++)
            {
                elementFound.Click();
            }
        }
    }
}
