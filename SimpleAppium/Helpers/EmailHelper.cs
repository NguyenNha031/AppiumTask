// File: EmailHelper.cs
using System.Net;
using System.Net.Mail;
using System.IO;
using System;

namespace SimpleAppium.Helpers
{
    public static class EmailHelper
    {
        public static void SendReportViaEmail(string reportFilePath, string testCaseName, string testStatus)
        {
            string fromEmail = "cirsnha0301@gmail.com";
            string toEmail = "cirsnha123@gmail.com";
            string subject = "🔔 Test Report - Appium Project";
            string body = $"Đây là báo cáo test mới nhất.\n\n" +
                         $"Test Case: {testCaseName}\n" +
                         $"Trạng thái: {testStatus}\n\n" +
                         $"Xem file đính kèm để biết chi tiết.";

            MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
            mail.Attachments.Add(new Attachment(reportFilePath));

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromEmail, "eezd bcpg smfu quyp");
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                Console.WriteLine("✅ Gửi báo cáo qua email thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi gửi email: " + ex.Message);
            }
        }
    }
}