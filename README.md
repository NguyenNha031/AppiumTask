# AppiumTask
**Các đường link đến video, ppt, báo cáo**

-Drive: https://drive.google.com/drive/folders/15P92TnSTOXUQOrVF9qMF9SQfROxYhBsD?usp=sharing

**Test Case Descriptions: Đây là mô tả ngắn gọn về các test case**

-LoginTests(TestLoginMultipleAccounts_FromExcel)
  + Đọc dữ liệu đăng nhập từ file Excel DataLogin.xlsx, thực hiện đăng nhập nhiều lần với các tài khoản khác nhau.
  + Với mỗi dòng dữ liệu, kiểm tra xem đăng nhập có thành công hay không bằng cách xác minh sự hiển thị của thành phần productTV.
  + Nếu đăng nhập thành công thì thực hiện đăng xuất, nếu thất bại thì ghi log tương ứng.

-RemoveTest(TestShoppingThenRemove)
  + Đăng nhập với tài khoản hợp lệ bod@example.com/10203040.
  + Thực hiện thao tác mua hàng bằng cách thêm sản phẩm vào giỏ.
  + Sau đó xóa sản phẩm ra khỏi giỏ hàng và xác minh việc xóa thành công bằng kiểm tra thành phần noItemTitleTV.
  + Kết thúc bằng cách đăng xuất.

-ShoppingTest(TestShoppingThenPayment)
  + Đăng nhập với tài khoản hợp lệ bod@example.com/10203040.
  + Thêm sản phẩm vào giỏ hàng.
  + Nhập thông tin địa chỉ người nhận và xác minh trang thanh toán mở thành công (enterPaymentMethodTV).
  + Thực hiện thanh toán bằng cách điền thông tin thẻ và xác minh hiển thị thông báo hoàn tất (completeTV).
  + Kết thúc bằng đăng xuất khỏi ứng dụng.
  + 
-Ghi chú chung:
  + Tất cả test case đều sử dụng ExtentReports để ghi log chi tiết, bao gồm trạng thái, hành động và lỗi nếu có.
  + Ảnh chụp màn hình sẽ được chụp tự động khi một test case thất bại, kèm theo vào báo cáo.
  + Dữ liệu đăng nhập được cấu hình từ file Excel đặt tại TestData/DataLogin.xlsx.
  + Các thao tác UI chính được thực hiện thông qua Appium và AndroidDriver.
  + Dự án sử dụng Page Object Model (POM) để tách biệt logic xử lý giao diện và logic test.
