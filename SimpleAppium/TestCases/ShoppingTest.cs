using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleAppium.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using AventStack.ExtentReports;
using SimpleAppium.Common;
namespace SimpleAppium.TestCases
{
    [TestClass]
    public class ShoppingTest : BaseTest
    {
        [TestMethod]
        public void TestShoppingThenPayment()
        {
            try
            {
                var loginPage = new LoginPage(driver);
                test.Log(Status.Info, "✅ App đã mở thành công");
                test.Log(Status.Info, "📥 Mở form đăng nhập");
                loginPage.OpenLoginForm();
                test.Log(Status.Info, "🔐 Thực hiện đăng nhập với user bod@example.com");
                loginPage.Login("bod@example.com", "10203040");
                test.Log(Status.Pass, "✅ Đăng nhập thành công!");
                test.Log(Status.Info, "🛒 Thực hiện thao tác thêm giỏ hàng");

                var dashboardPage = new DashboardPage(driver);
                dashboardPage.Shopping();
                test.Log(Status.Pass, "✅ thêm giỏ hàng thành công!");
                test.Log(Status.Info, "Tiến hành thanh toán");

                var cartPage = new CartPage(driver);
                test.Log(Status.Info, "Tiến hành nhập địa chỉ");
                cartPage.EnterInfo();
                test.Log(Status.Pass, "Nhập địa chỉ thành công, tiến hành thanh toán");

                Assert.IsTrue(cartPage.IsOpenPaymentSuccessful(), "❌ Không mở được trang thanh toán");
                test.Log(Status.Pass, "✅ Đã mở thành công trang thanh toán");
                test.Log(Status.Info, "Tiến hành nhập thông tin trang thanh toán");
                cartPage.Payment();

                Assert.IsTrue(cartPage.IsPaymentSuccessful(), "❌ Thanh toán chưa thành công");
                test.Log(Status.Pass, "✅ Thanh toán thành công");

                test.Log(Status.Info, "🚪 Đăng xuất khỏi ứng dụng");
                loginPage.Logout();
                test.Log(Status.Pass, "✅ Đăng xuất thành công");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"❌ Lỗi khi thực hiện test: {ex.Message}");
                throw;
            }
        }

    }
}
