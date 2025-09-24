using System.Data;
using demo_mescius_report.Models;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Export.Pdf.Section;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Drawing;

namespace demo_mescius_report.Services;

public class PlantReportService
{
    public byte[] GeneratePdf(List<Plant> plants)
    {
        // Tạo DataTable từ List<Plant>
        var dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Category");
        dt.Columns.Add("ScientificName");
        dt.Columns.Add("Description");
        foreach (var p in plants)
            dt.Rows.Add(p.Name, p.Category, p.ScientificName, p.Description);

        var report = new SectionReport();
        report.DataSource = dt;

        // PageHeader
        var pageHeader = new PageHeader();
        var lblHeader = new Label
        {
            Text = "BÁO CÁO DANH SÁCH CÂY TRỒNG",
            Font = new Font("Arial", 14, FontStyle.Bold),
            Top = 0f,
            Left = 0f,
            Width = 4.5f
        };
        pageHeader.Controls.Add(lblHeader);

        // Detail
        var detail = new Detail { Height = 0.3f };
        float left = 0;
        float[] widths = { 1.5f, 1.1f, 1.3f, 2.1f };
        string[] fields = { "Name", "Category", "ScientificName", "Description" };
        for (int i = 0; i < fields.Length; i++)
        {
            var txt = new TextBox
            {
                DataField = fields[i],
                Left = left,
                Top = 0,
                Width = widths[i],
                Height = 0.3f,
            };
            txt.Border.BottomStyle = BorderLineStyle.Solid;
            txt.Border.TopStyle = BorderLineStyle.Solid;
            txt.Border.LeftStyle = BorderLineStyle.Solid;
            txt.Border.RightStyle = BorderLineStyle.Solid;
            detail.Controls.Add(txt);
            left += widths[i] + 0.1f;
        }

        // PageFooter (bắt buộc phải có, dù để trống)
        var pageFooter = new PageFooter();

        // **Chú ý: Thứ tự phải là: PageHeader, Detail, PageFooter**
        report.Sections.Add(pageHeader);
        report.Sections.Add(detail);
        report.Sections.Add(pageFooter);

        report.Run();
        using var ms = new MemoryStream();
        var pdfExport = new PdfExport();
        pdfExport.Export(report.Document, ms);
        return ms.ToArray();
    }
}
// dotnet add package MESCIUS.ActiveReports --version 19.1.1
// dotnet add package MESCIUS.ActiveReports.Aspnetcore.Viewer --version 19.1.1
// dotnet add package MESCIUS.ActiveReports.Export.Pdf --version 19.1.1

