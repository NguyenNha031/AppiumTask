using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports; 
using SimpleAppium.Helpers;     

namespace SimpleAppium.Pages
{
    public class LoginPage
    {
        private AndroidDriver driver;
        private WebDriverWait wait;
        private ExtentTest test; 

        public LoginPage(AndroidDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenLoginForm()
        {
            wait.Until(d => d.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"View menu\"]"))).Click();
            wait.Until(d => d.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Login Menu Item\"]"))).Click();
        }

        public void Login(string username, string password)
        {
            var emailElement = wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/nameET")));
            var passwordElement = wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/passwordET")));

            emailElement.Clear();
            if (!string.IsNullOrWhiteSpace(username)) emailElement.SendKeys(username);
            else Console.WriteLine("⚠️ Email is empty or null.");

            passwordElement.Clear();
            if (!string.IsNullOrWhiteSpace(password)) passwordElement.SendKeys(password);
            else Console.WriteLine("⚠️ Password is empty or null.");

            var btnSubmit = wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/loginBtn")));
            if (!btnSubmit.Enabled)
            {
                throw new Exception("❌ Nút Submit không được enabled!");
            }
            btnSubmit.Click();
        }

        public bool IsLoginSuccessful()
        {
            try
            {
                return driver.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/productTV")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClearLoginForm()
        {
            var emailElement = wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/nameET")));
            var passwordElement = wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/passwordET")));

            emailElement.Clear();
            passwordElement.Clear();
        }

        public void Logout()
        {
            try
            {
                wait.Until(d => d.FindElement(By.XPath("//android.widget.ImageView[@content-desc=\"View menu\"]"))).Click();
                wait.Until(d => d.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Logout Menu Item\"]"))).Click();
                wait.Until(d => d.FindElement(By.Id("android:id/button1"))).Click();
                wait.Until(d => d.FindElement(By.Id("com.saucelabs.mydemoapp.android:id/nameET"))); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khi Logout: " + ex.Message);
                throw;
            }
        }
    }
}