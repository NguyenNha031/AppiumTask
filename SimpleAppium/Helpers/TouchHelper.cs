using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SimpleAppium.Helpers
{
    public class TouchHelper
    {
        private readonly AndroidDriver driver;
        private readonly WebDriverWait wait;

        public TouchHelper(AndroidDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Hàm vuốt từ phải qua trái
        public static void SwipeRightToLeft(AppiumDriver driver, int durationMs = 500)
        {
            var screenSize = driver.Manage().Window.Size;
            int startX = (int)(screenSize.Width * 0.8);
            int endX = (int)(screenSize.Width * 0.2);
            int y = screenSize.Height / 2;

            var touch = new OpenQA.Selenium.Interactions.PointerInputDevice(OpenQA.Selenium.Interactions.PointerKind.Touch);
            var swipe = new ActionSequence(touch, 0);

            swipe.AddAction(touch.CreatePointerMove(OpenQA.Selenium.Interactions.CoordinateOrigin.Viewport, startX, y, TimeSpan.Zero));
            swipe.AddAction(touch.CreatePointerDown(0));
            swipe.AddAction(touch.CreatePointerMove(OpenQA.Selenium.Interactions.CoordinateOrigin.Viewport, endX, y, TimeSpan.FromMilliseconds(durationMs)));
            swipe.AddAction(touch.CreatePointerUp(0));

            driver.PerformActions(new System.Collections.Generic.List<ActionSequence> { swipe });
            driver.ResetInputState();

            Console.WriteLine("📱 Vuốt từ phải sang trái xong.");
        }

        //Hàm lăn tới element
        public IWebElement ScrollToElementByResourceId(string resourceId)
        {
            try
            {
                driver.Context = "NATIVE_APP";
                string uiAutomatorString = $"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().resourceId(\"{resourceId}\"))";
                var element = wait.Until(d => d.FindElement(MobileBy.AndroidUIAutomator(uiAutomatorString)));
                Console.WriteLine($"✅ Đã scroll tới phần tử có resource-id: {resourceId}");
                return element;
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception($"❌ Không tìm thấy phần tử với resource-id '{resourceId}': {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ Lỗi khi cuộn đến phần tử với resource-id '{resourceId}': {ex.Message}");
            }
        }
    }
}