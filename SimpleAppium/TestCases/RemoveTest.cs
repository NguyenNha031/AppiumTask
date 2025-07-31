using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleAppium.Pages;
using System;
using AventStack.ExtentReports;
using SimpleAppium.Common;

namespace SimpleAppium.TestCases
{
    [TestClass]
    public class RemoveTest : BaseTest
    {
        [DataTestMethod]
        [DataRow("emulator-5556")] 
        public void TestShoppingThenRemove()
        {
            try
            {
                var loginPage = new LoginPage(driver);
                test.Log(Status.Info, "📥 Mở form đăng nhập");
                loginPage.OpenLoginForm();
                test.Log(Status.Info, "🔐 Thực hiện đăng nhập với user bod@example.com");
                loginPage.Login("bod@example.com", "10203040");
                test.Log(Status.Pass, "✅ Đăng nhập thành công!");
                test.Log(Status.Info, "🛒 Thực hiện thao tác thêm giỏ hàng");

                var dashboardPage = new DashboardPage(driver);
                dashboardPage.Shopping();
                test.Log(Status.Pass, "✅ thêm giỏ hàng thành công!");

                var cartPage = new CartPage(driver);
                test.Log(Status.Info, "🗑️ Tiến hành xóa khỏi giỏ hàng");
                cartPage.RemoveCart();
                Assert.IsTrue(cartPage.IsRemoveSuccessful(), "❌ Không thể xóa được sản phẩm");
                test.Log(Status.Pass, "✅ Đã xóa sản phẩm thành công");

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
