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
using NPOI.SS.Formula.Functions;

namespace SimpleAppium.Pages
{

    public class CartPage
    {
        private AndroidDriver driver;
        private WebDriverWait wait;
        private TouchHelper touchHelper;

        public CartPage(AndroidDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            touchHelper = new TouchHelper(driver);
        }


        public void EnterInfo()
        {
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/cartBt"))).Click();
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/fullNameET"))).SendKeys("Nguyenha");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/address1ET"))).SendKeys("Vinh Hai");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/address2ET"))).SendKeys("So 123 duong To Huu");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/cityET"))).SendKeys("Thanh pho Nha Trang");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/stateET"))).SendKeys("Khanh Hoa");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/zipET"))).SendKeys("65000");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/countryET"))).SendKeys("Viet Nam");
            var element = touchHelper.ScrollToElementByResourceId("com.saucelabs.mydemoapp.android:id/paymentBtn");
            element.Click();
        }
        public bool IsOpenPaymentSuccessful()
        {
            try
            {
                return driver.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/enterPaymentMethodTV")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void Payment()
        {
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/nameET"))).SendKeys("Nha Thanh Nguyen");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/cardNumberET"))).SendKeys("0395666362 9239 283");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/expirationDateET"))).SendKeys("03/29");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/securityCodeET"))).SendKeys("321");
            var element1 = touchHelper.ScrollToElementByResourceId("com.saucelabs.mydemoapp.android:id/paymentBtn");
            element1.Click();
            touchHelper.ScrollToElementByResourceId( "com.saucelabs.mydemoapp.android:id/totalTextTV");
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/paymentBtn"))).Click();
        }

        public bool IsPaymentSuccessful()
        {
            try
            {
                return driver.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/completeTV")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public void RemoveCart()
        {
            wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/removeBt"))).Click();
        }
        public bool IsRemoveSuccessful()
        {
            try
            {
                return driver.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/noItemTitleTV")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
