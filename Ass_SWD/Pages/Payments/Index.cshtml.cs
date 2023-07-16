using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ass_SWD.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Microsoft.EntityFrameworkCore;

using System.Data;
using ClosedXML.Excel;

namespace Ass_SWD.Pages.Payments
{
    public class IndexModel : PageModel
    {

        public List<Payment> listPayment { get; set; }
        MyStoreContext _storeContext;

        public IndexModel(MyStoreContext storeContext)
        {

            _storeContext = storeContext;
        }

        public void OnGet()
        {
            listPayment = _storeContext.Payments.ToList();
        }


        //public IActionResult OnPostExport()
        //{
        //    listPayment = _storeContext.Payments.ToList();
        //    var payments = _storeContext.Payments.ToList();

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var spreadsheetDocument = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
        //        {
        //            var workbookPart = spreadsheetDocument.AddWorkbookPart();
        //            workbookPart.Workbook = new Workbook();

        //            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //            worksheetPart.Worksheet = new Worksheet();

        //            var sheetData = new SheetData();
        //            worksheetPart.Worksheet.Append(sheetData);

        //            var row = new Row();
        //            row.Append(
        //                new Cell { CellValue = new CellValue("PaymentID"), DataType = CellValues.String },
        //                new Cell { CellValue = new CellValue("InvoiceNumber"), DataType = CellValues.String },
        //                 new Cell { CellValue = new CellValue("CategoryID"), DataType = CellValues.String },
                         
                         
        //                    new Cell { CellValue = new CellValue("Amount"), DataType = CellValues.String }
                            
        //            );
        //            sheetData.Append(row);

        //            foreach (var payment in payments)
        //            {
        //                row = new Row();
        //                row.Append(
        //                    new Cell { CellValue = new CellValue(payment.PaymentId.ToString()), DataType = CellValues.Number },
        //                    new Cell { CellValue = new CellValue(payment.InvoiceNumber.ToString()), DataType = CellValues.String },
        //                    new Cell { CellValue = new CellValue(payment.CategoryId.ToString()), DataType = CellValues.String },
                           
                          
        //                    new Cell { CellValue = new CellValue(payment.Amount.ToString()), DataType = CellValues.String }
                        
        //                );
        //                sheetData.Append(row);
        //            }

        //            workbookPart.Workbook.Save();
        //            spreadsheetDocument.Close();
        //        }

        //        memoryStream.Seek(0, SeekOrigin.Begin);
        //        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Payment.xlsx");
        //    }
        //}

        

    }
}
