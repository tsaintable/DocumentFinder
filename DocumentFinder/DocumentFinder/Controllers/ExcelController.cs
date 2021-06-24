using DocumentFinder.Models;
using NonFactors.Mvc.Grid;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentFinder.Controllers
{
    public class ExcelController : Controller
    {
        DBModel db = new DBModel();
        // GET: Excel
        [HttpGet]
        public ViewResult Index()
        {
            return View(CreateExportableGrid());
        }

        [HttpGet]
        public FileContentResult ExportIndex()
        {
            // Using EPPlus from nuget
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                Int32 row = 2;
                Int32 col = 1;

                package.Workbook.Worksheets.Add("Data");
                IGrid<DOCUMENT> grid = CreateExportableGrid();
                ExcelWorksheet sheet = package.Workbook.Worksheets["Data"];

                foreach (IGridColumn column in grid.Columns)
                {
                    sheet.Cells[1, col].Value = column.Title;
                    sheet.Column(col++).Width = 18;

                    column.IsEncoded = false;
                }

                foreach (IGridRow<DOCUMENT> gridRow in grid.Rows)
                {
                    col = 1;
                    foreach (IGridColumn column in grid.Columns)
                        sheet.Cells[row, col++].Value = column.ValueFor(gridRow);

                    row++;
                }

                return File(package.GetAsByteArray(), "application/unknown", "Export_"+DateTime.Now+".xlsx");
            }
        }

        private IGrid<DOCUMENT> CreateExportableGrid()
        {
            IGrid<DOCUMENT> grid = new Grid<DOCUMENT>(db.DOCUMENTs);
            grid.ViewContext = new ViewContext { HttpContext = HttpContext };
            grid.Query = Request.QueryString;

            grid.Columns.Add(model => model.DocID).Titled("DocID");
            grid.Columns.Add(model => model.DocType).Titled("Type");
            grid.Columns.Add(model => model.DocName).Titled("Name");
            grid.Columns.Add(model => model.DocManuf).Titled("Mfg");
            grid.Columns.Add(model => model.DocCatg).Titled("Catgy");
            grid.Columns.Add(model => model.DocWONum).Titled("WO");
            grid.Columns.Add(model => model.DocPONum).Titled("PO");
            grid.Columns.Add(model => model.DocDate).Titled("Date").Formatted("{0:d}");
            grid.Columns.Add(model => model.DocProjMgr).Titled("ProjMgr");
            grid.Columns.Add(model => model.DocEqpAmt).Titled("Amount").Formatted("{0:C}");
            grid.Columns.Add(model => model.DocDescr).Titled("Description");

            grid.Pager = new GridPager<DOCUMENT>(grid);
            grid.Processors.Add(grid.Pager);
            //grid.Pager.RowsPerPage = 6;

            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

    }
}

