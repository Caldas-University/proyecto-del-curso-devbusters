using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using EventManagement.Application.DTO;

namespace EventManagement.Api.Reports
{
    public class EventReportExcelGenerator
    {
        public static byte[] Generate(List<EventReportDto> reports, ReportSummaryDto summary)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Event Report");
            
            // Título
            ws.Cells["A1"].Value = "Event Report Summary";
            ws.Cells["A1"].Style.Font.Size = 18;
            ws.Cells["A1"].Style.Font.Bold = true;

            // Métricas
            ws.Cells["A3"].Value = "Total Reports";
            ws.Cells["B3"].Value = summary.TotalReports;

            ws.Cells["A4"].Value = "Average Attendance";
            ws.Cells["B4"].Value = summary.AverageAttendance;

            ws.Cells["A5"].Value = "Average Occupancy";
            ws.Cells["B5"].Value = summary.AverageOccupancy;

            ws.Cells["A6"].Value = "Average Schedule Compliance";
            ws.Cells["B6"].Value = summary.AverageScheduleCompliance;

            // Encabezados de tabla
            ws.Cells["A8"].Value = "Id";
            ws.Cells["B8"].Value = "Activity Type";
            ws.Cells["C8"].Value = "Registered Count";
            ws.Cells["D8"].Value = "Attendance Count";
            ws.Cells["E8"].Value = "Occupancy Rate";
            ws.Cells["F8"].Value = "Resource Usage";
            ws.Cells["G8"].Value = "Schedule Compliance";
            ws.Cells["H8"].Value = "Timestamp";

            using (var range = ws.Cells["A8:H8"])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }

            // Rellenar filas
            int row = 9;
            foreach (var r in reports)
            {
                ws.Cells[row, 1].Value = r.Id.ToString();
                ws.Cells[row, 2].Value = r.ActivityType;
                ws.Cells[row, 3].Value = r.RegisteredCount;
                ws.Cells[row, 4].Value = r.AttendanceCount;
                ws.Cells[row, 5].Value = r.OccupancyRate;
                ws.Cells[row, 6].Value = r.ResourceUsage;
                ws.Cells[row, 7].Value = r.ScheduleCompliance;
                ws.Cells[row, 8].Value = r.Timestamp.ToString("g");
                row++;
            }

            // Ajustar tamaño columnas
            ws.Cells[ws.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}