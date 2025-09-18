using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using VillageManagement.DTO;
using VillageManagementUI.Model; // ✅ Use the UI-side DTO

public class CreateModel : PageModel
{
    [BindProperty]
    public BirthRecordCreateDto BirthRecord { get; set; } // ✅ Use DTO from UI project

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7060/api/BirthRecords/CreateBirthRecord"; // ✅ Your API URL
        var json = JsonSerializer.Serialize(BirthRecord);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(apiUrl, content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("/BirthRecord/List");
        }

        ModelState.AddModelError("", "Error saving birth record.");
        return Page();
    }
}
