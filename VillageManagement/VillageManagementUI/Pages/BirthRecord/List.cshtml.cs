using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VillageManagement.DTO.VillageManagementUI.Model;
using VillageManagementUI.Model;

public class ListModel : PageModel
{
    public List<BirthRecordReadDto> BirthRecords { get; set; }

    public async Task OnGetAsync()
    {
        using var httpClient = new HttpClient();
            var apiUrl = "https://localhost:7060/api/BirthRecords/GetBirthRecord"; // Adjust port if needed

            var response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                BirthRecords = JsonSerializer.Deserialize<List<BirthRecordReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                BirthRecords = new List<BirthRecordReadDto>();
            } 
    }
}
