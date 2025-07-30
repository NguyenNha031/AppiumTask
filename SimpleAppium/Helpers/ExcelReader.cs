using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleAppium.Common
{
    public class ExcelReader
    {
        public static List<(string email, string password)> ReadLoginData(string filePath)
        {
            var dataList = new List<(string email, string password)>();

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                for (int row = 0; row < Math.Min(4, sheet.LastRowNum + 1); row++)
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow != null)
                    {
                        string email = currentRow.GetCell(0)?.ToString();
                        string password = currentRow.GetCell(1)?.ToString();

                        dataList.Add((email, password));
                    }
                }
            }

            return dataList;
        }
    }
}