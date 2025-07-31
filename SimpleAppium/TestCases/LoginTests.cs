using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SimpleAppium.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using AventStack.ExtentReports;
using SimpleAppium.Helpers;
using SimpleAppium.Common;
using System.IO;

namespace SimpleAppium.TestCases
{
    [TestClass]
    public class LoginTests : BaseTest
    {
        [TestMethod]
        public void TestLoginMultipleAccounts_FromExcel()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "TestData", "DataLogin.xlsx");
                test.Log(Status.Info, $"🔍 Đang tìm file tại: {filePath}");
                var credentials = ExcelReader.ReadLoginData(filePath);

                var loginPage = new LoginPage(driver);
                test.Log(Status.Info, "✅ App đã mở thành công");
                Thread.Sleep(3000);

                foreach (var (email, password) in credentials)
                {
                    test.Log(Status.Info, $"➡️ Đang thử đăng nhập với: Email='{email ?? "Trống"}', Password='{password ?? "Trống"}'");
                    loginPage.OpenLoginForm();
                    Thread.Sleep(2000);

                    try
                    {
                        loginPage.Login(email, password);
                        Thread.Sleep(2000);

                        if (loginPage.IsLoginSuccessful())
                        {
                            test.Log(Status.Pass, "✅ Đăng nhập thành công");
                            loginPage.Logout();
                            test.Log(Status.Info, "🔁 Đã đăng xuất để tiếp tục bộ tiếp theo");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            test.Log(Status.Warning, "❌ Đăng nhập thất bại");
                            loginPage.ClearLoginForm();
                            Thread.Sleep(2000);
                        }
                    }
                    catch (Exception ex)
                    {
                        test.Log(Status.Error, $"❗ Lỗi khi đăng nhập với Email='{email ?? "Trống"}', Password='{password ?? "Trống"}': {ex.Message}");
                        loginPage.ClearLoginForm();
                        Thread.Sleep(2000);
                    }
                }
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"❌ Lỗi khi thực hiện test: {ex.Message}");
                throw;
            }
        }
    }
}