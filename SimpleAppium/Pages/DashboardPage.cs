using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Threading;
using SimpleAppium.Helpers;

namespace SimpleAppium.Pages
{
    
     public class DashboardPage
    {
        private AndroidDriver driver;
        private WebDriverWait wait;
        private TouchHelper touchHelper;

        public DashboardPage(AndroidDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            touchHelper = new TouchHelper(driver);
        }


        public void Shopping()
        {
            wait.Until(d => d.FindElement(By.XPath("(//android.widget.ImageView[@content-desc=\"Product Image\"])[1]"))).Click();
            wait.Until(d => d.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"Green color\"]"))).Click();
            var element = touchHelper.ScrollToElementByResourceId("com.saucelabs.mydemoapp.android:id/plusIV");
            element.Click();

            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/cartBt"))).Click();
            Thread.Sleep(1000);
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/cartIV"))).Click();
        }


    }
}
