﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SimpleAppium.Helpers
{
    public static class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter sparkReporter;
        public static string ReportPath { get; private set; } 

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                string reportsDir = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
                Directory.CreateDirectory(reportsDir);
                ReportPath = Path.Combine(reportsDir, $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.html");

                Console.WriteLine("📄 Report path: " + ReportPath);

                sparkReporter = new ExtentSparkReporter(ReportPath);
                sparkReporter.Config.DocumentTitle = "Automation Test Report";
                sparkReporter.Config.ReportName = "Test Execution Report";

                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);
                extent.AddSystemInfo("Tester", "Nhã");
            }
            return extent;
        }

        public static string GetReportFilePath()
        {
            return ReportPath;
        }


        public static string CaptureScreenshot(IWebDriver driver, string fileNamePrefix = "screenshot")
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                return ss.AsBase64EncodedString; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Không thể chụp màn hình: " + ex.Message);
                return null;
            }
        }
    }
}