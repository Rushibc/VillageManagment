using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace VillageManagementUI.Pages.DeathRecord
{
    public class ListModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public List<Model.DeathRecordModel> DeathRecords { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            using var httpClient = new HttpClient();

            string url = string.IsNullOrWhiteSpace(SearchTerm)
                ? "https://localhost:7060/api/DeathRecords/GetAll"
                : $"https://localhost:7060/api/DeathRecords/GetById/{SearchTerm}";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                DeathRecords = JsonConvert.DeserializeObject<List<Model.DeathRecordModel>>(json);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("API");
            var response = await client.DeleteAsync($"https://localhost:7060/api/DeathRecords/Delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Record deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to delete the record.";
            }

            return RedirectToPage();
        }
    }

  
}
