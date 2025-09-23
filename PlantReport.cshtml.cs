using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using demo_mescius_report.Models;
using demo_mescius_report.Services;

namespace demo_mescius_report.Pages;

public class PlantReportModel : PageModel
{
    private readonly PlantReportService _plantReportService;

    public PlantReportModel(PlantReportService plantReportService)
    {
        _plantReportService = plantReportService;
    }

    public List<Plant> Plants { get; set; } = new()
    {
        new Plant { Id = 1, Name = "Hoa Hồng", Category = "Hoa", ScientificName = "Rosa", Description = "Cây hoa đẹp, phổ biến." },
        new Plant { Id = 2, Name = "Cà Chua", Category = "Rau quả", ScientificName = "Solanum lycopersicum", Description = "Cây ăn quả dễ trồng." },
        new Plant { Id = 3, Name = "Trầu Bà", Category = "Cây cảnh", ScientificName = "Epipremnum aureum", Description = "Cây lọc không khí tốt." }
    };

    public void OnGet() { }

    public IActionResult OnPostExportPdf()
    {
        var pdfBytes = _plantReportService.GeneratePdf(Plants);
        return File(pdfBytes, "application/pdf", "PlantReport.pdf");
    }
}
