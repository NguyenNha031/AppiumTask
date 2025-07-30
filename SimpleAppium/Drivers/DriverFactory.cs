using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace SimpleAppium.Helpers
{
    public class DriverFactory
    {
        public static AndroidDriver CreateDriver()
        {
            var options = new AppiumOptions
            {
                PlatformName = "Android",
                DeviceName = "emulator-5554",
                AutomationName = "UiAutomator2",
                App = @"D:\TestAppium\SauceLabs-Demo-App.apk"
            };
            options.AddAdditionalAppiumOption("autoGrantPermissions", true);
            options.AddAdditionalAppiumOption("appWaitActivity", "com.saucelabs.mydemoapp.android.view.activities.MainActivity"); 
            options.AddAdditionalAppiumOption("fullReset", false);

            return new AndroidDriver(new Uri("http://127.0.0.1:4723"), options);
        }
    }
}