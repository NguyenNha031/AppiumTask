using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SimpleAppium.Helpers
{
    public class WaitHelper
    {
        private readonly AppiumDriver driver;
        private readonly WebDriverWait wait;

        public WaitHelper(AppiumDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement WaitForElement(By locator)
        {
            return wait.Until(d => d.FindElement(locator));
        }
        public bool WaitForElementDisplayed(By locator, int timeoutSeconds = 10)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(d => d.FindElement(locator).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}