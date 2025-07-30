using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using SimpleAppium.Helpers;

namespace SimpleAppium.Common
{
    public class BaseTest
    {
        protected AndroidDriver driver;
        protected ExtentReports extent;
        protected ExtentTest test;
        protected WaitHelper waitHelper; 

        [TestInitialize]
        public void SetUp()
        {
            try
            {
                extent = ExtentManager.GetExtent();
                test = extent.CreateTest(TestContext.TestName);

                // Kiểm tra kết nối Appium server
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = client.GetAsync("http://127.0.0.1:4723/status").Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("❌ Appium server không khả dụng tại http://127.0.0.1:4723");
                    }
                }

                driver = DriverFactory.CreateDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                waitHelper = new WaitHelper(driver);

                test.Info("✅ Đã mở app thành công");
                extent.AddSystemInfo("Platform", driver.Capabilities.GetCapability("platformName").ToString());
                extent.AddSystemInfo("Device", driver.Capabilities.GetCapability("deviceName").ToString());
                extent.AddSystemInfo("Appium Version", driver.Capabilities.GetCapability("automationName").ToString());
            }
            catch (Exception ex)
            {
                test.Log(Status.Error, $"❗ Lỗi khi khởi tạo test: {ex.Message}");
                throw;
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                {
                    test.Log(Status.Pass, "✅ Test passed");
                }
                else
                {
                    test.Log(Status.Fail, "❌ Test failed");
                    if (driver != null)
                    {
                        string screenshotBase64 = ExtentManager.CaptureScreenshot(driver, TestContext.TestName);
                        if (screenshotBase64 != null)
                        {
                            test.Log(Status.Fail, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                test.Log(Status.Error, $"❗ Lỗi khi xử lý kết quả test: {ex.Message}");
            }
            finally
            {
                extent.Flush();
                driver?.Quit();
                Console.WriteLine("Đã đóng app và lưu report");
            }
        }

        public TestContext TestContext { get; set; }
    }
}