using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.IO;

namespace SimpleAppium.Helpers
{
    public class DriverFactory
    {
        public static AndroidDriver CreateDriver()
        {
            string basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\.."));
            string appPath = Path.Combine(basePath, "SimpleAppium", "SauceLabs-Demo-App.apk");
            Console.WriteLine($"[DEBUG] App path: {appPath}");

            var options = new AppiumOptions
            {
                PlatformName = "Android",
                DeviceName = "emulator-5554",
                AutomationName = "UiAutomator2",
                App = appPath
            };
            options.AddAdditionalAppiumOption("autoGrantPermissions", true);
            options.AddAdditionalAppiumOption("appWaitActivity", "com.saucelabs.mydemoapp.android.view.activities.MainActivity");
            options.AddAdditionalAppiumOption("fullReset", false);

            return new AndroidDriver(new Uri("http://127.0.0.1:4723"), options);
        }
    }
}
