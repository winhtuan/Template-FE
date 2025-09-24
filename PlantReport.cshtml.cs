using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using demo_mescius_report.Models;
using demo_mescius_report.Services;

namespace demo_mescius_report.Pages;

public class PlantReportModel : PageModel
{
    private readonly PlantReportService _plantReportService;
[BindProperty]
public string Type { get; set; }

[BindProperty]
public string? Date { get; set; }

    public PlantReportModel(PlantReportService plantReportService)
    {
        _plantReportService = plantReportService;
    }

   public List<Plant> Plants { get; set; } = new()
{
    // Ngày 06/06/2025
    new Plant { Id = 1, Name = "Hoa Hồng", Category = "Hoa", ScientificName = "Rosa", Description = "Cây hoa đẹp, phổ biến.", Region = "Toàn quốc", CreatedDate = new DateOnly(2025, 6, 6) },
    new Plant { Id = 2, Name = "Cà Chua", Category = "Rau quả", ScientificName = "Solanum lycopersicum", Description = "Cây ăn quả dễ trồng.", Region = "Đồng bằng, cao nguyên", CreatedDate = new DateOnly(2025, 6, 6) },
    new Plant { Id = 3, Name = "Trầu Bà", Category = "Cây cảnh", ScientificName = "Epipremnum aureum", Description = "Cây lọc không khí tốt.", Region = "Toàn quốc", CreatedDate = new DateOnly(2025, 6, 6) },
    new Plant { Id = 4, Name = "Lúa", Category = "Ngũ cốc", ScientificName = "Oryza sativa", Description = "Cây lương thực chính ở Việt Nam.", Region = "ĐBSCL, ĐB Sông Hồng", CreatedDate = new DateOnly(2025, 6, 6) },
    new Plant { Id = 5, Name = "Khoai Lang", Category = "Rau củ", ScientificName = "Ipomoea batatas", Description = "Cây củ ngọt, dễ trồng, giàu dinh dưỡng.", Region = "Miền Trung, ĐBSCL", CreatedDate = new DateOnly(2025, 6, 6) },

    // Ngày 07/06/2025
    new Plant { Id = 6, Name = "Chuối", Category = "Trái cây", ScientificName = "Musa", Description = "Trái cây giàu kali, ăn trực tiếp hoặc chế biến.", Region = "Trung du, miền núi, ĐBSCL", CreatedDate = new DateOnly(2025, 6, 7) },
    new Plant { Id = 7, Name = "Cam", Category = "Trái cây", ScientificName = "Citrus sinensis", Description = "Trái cây giàu vitamin C.", Region = "Miền Bắc, miền Trung", CreatedDate = new DateOnly(2025, 6, 7) },
    new Plant { Id = 8, Name = "Táo", Category = "Trái cây", ScientificName = "Malus domestica", Description = "Trái cây phổ biến trên thế giới.", Region = "Nhập khẩu/Đà Lạt, Sa Pa", CreatedDate = new DateOnly(2025, 6, 7) },
    new Plant { Id = 9, Name = "Dừa", Category = "Cây công nghiệp", ScientificName = "Cocos nucifera", Description = "Cây cung cấp nước, dừa, và dầu.", Region = "Bến Tre, ĐBSCL, duyên hải miền Trung", CreatedDate = new DateOnly(2025, 6, 7) },
    new Plant { Id = 10, Name = "Cà Phê", Category = "Cây công nghiệp", ScientificName = "Coffea arabica", Description = "Cây cho hạt cà phê, phổ biến ở Tây Nguyên.", Region = "Tây Nguyên", CreatedDate = new DateOnly(2025, 6, 7) },

    // Ngày 08/06/2025
    new Plant { Id = 11, Name = "Mía", Category = "Cây công nghiệp", ScientificName = "Saccharum officinarum", Description = "Cây cung cấp đường.", Region = "Miền Trung, ĐBSCL", CreatedDate = new DateOnly(2025, 6, 8) },
    new Plant { Id = 12, Name = "Ngô", Category = "Ngũ cốc", ScientificName = "Zea mays", Description = "Cây lương thực quan trọng.", Region = "Trung du, miền núi, đồng bằng", CreatedDate = new DateOnly(2025, 6, 8) },
    new Plant { Id = 13, Name = "Rau Muống", Category = "Rau ăn lá", ScientificName = "Ipomoea aquatica", Description = "Loại rau phổ biến trong bữa cơm Việt.", Region = "Toàn quốc (ao hồ, ruộng nước)", CreatedDate = new DateOnly(2025, 6, 8) },
    new Plant { Id = 14, Name = "Hoa Lan", Category = "Hoa", ScientificName = "Orchidaceae", Description = "Hoa cảnh có nhiều loài đẹp, quý.", Region = "Miền núi, nhà kính", CreatedDate = new DateOnly(2025, 6, 8) },
    new Plant { Id = 15, Name = "Cúc Vạn Thọ", Category = "Hoa", ScientificName = "Tagetes erecta", Description = "Hoa vàng cam, thường dùng trang trí dịp lễ.", Region = "Đà Lạt, Tây Nguyên, toàn quốc", CreatedDate = new DateOnly(2025, 6, 8) },

    // Ngày 09/06/2025
    new Plant { Id = 16, Name = "Dưa Hấu", Category = "Trái cây", ScientificName = "Citrullus lanatus", Description = "Trái cây mùa hè, mọng nước.", Region = "ĐBSCL, miền Trung", CreatedDate = new DateOnly(2025, 6, 9) },
    new Plant { Id = 17, Name = "Ớt", Category = "Rau quả", ScientificName = "Capsicum annuum", Description = "Gia vị cay, phổ biến ở Việt Nam.", Region = "Toàn quốc", CreatedDate = new DateOnly(2025, 6, 9) },
    new Plant { Id = 18, Name = "Sầu Riêng", Category = "Trái cây", ScientificName = "Durio zibethinus", Description = "Trái cây nhiệt đới, mùi đặc trưng.", Region = "ĐBSCL, Đông Nam Bộ", CreatedDate = new DateOnly(2025, 6, 9) },
    new Plant { Id = 19, Name = "Chanh", Category = "Trái cây", ScientificName = "Citrus limon", Description = "Trái cây giàu vitamin C, vị chua.", Region = "Toàn quốc", CreatedDate = new DateOnly(2025, 6, 9) },
    new Plant { Id = 20, Name = "Cây Xoài", Category = "Trái cây", ScientificName = "Mangifera indica", Description = "Trái cây nhiệt đới, vị ngọt.", Region = "ĐBSCL, miền Đông Nam Bộ", CreatedDate = new DateOnly(2025, 6, 9) }
};
    public void OnGet() { }

public IActionResult OnPostExportPdf()
{
    IEnumerable<Plant> filteredPlants = Plants;
    if (!string.IsNullOrEmpty(Date) && DateOnly.TryParse(Date, out var pickDate))
        filteredPlants = filteredPlants.Where(p => p.CreatedDate == pickDate);

IEnumerable<IGrouping<string, Plant>> grouped;
        switch (Type)
        {
            case "category":
                grouped = filteredPlants.GroupBy(p => p.Category); // Sửa ở đây!
                break;
            case "region":
                grouped = filteredPlants.GroupBy(p => p.Region ?? "Khác");
                break;
            default:
                grouped = filteredPlants.GroupBy(p => p.Category);
                break;
        }

    var pdfBytes = _plantReportService.GeneratePdf(filteredPlants.ToList());
    return File(pdfBytes, "application/pdf", "PlantReport.pdf");
}


    public JsonResult OnGetChartData(string type = "category", string? date = null)
    {
        IEnumerable<Plant> filteredPlants = Plants;
        if (!string.IsNullOrEmpty(date) && DateOnly.TryParse(date, out var pickDate))
        {
            filteredPlants = filteredPlants.Where(p => p.CreatedDate == pickDate);
        }
        IEnumerable<IGrouping<string, Plant>> grouped;
        switch (type)
        {
            case "category":
                grouped = filteredPlants.GroupBy(p => p.Category); // Sửa ở đây!
                break;
            case "region":
                grouped = filteredPlants.GroupBy(p => p.Region ?? "Khác");
                break;
            default:
                grouped = filteredPlants.GroupBy(p => p.Category);
                break;
        }
        var labels = grouped.Select(x => x.Key).ToArray();
        var data = grouped.Select(x => x.Count()).ToArray();

        return new JsonResult(new { labels, data });
    }
}
