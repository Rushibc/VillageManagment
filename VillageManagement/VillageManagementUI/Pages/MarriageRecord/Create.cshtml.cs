using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VillageManagementUI.Model;

namespace VillageManagementUI.Pages.MarriageRecord
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public MarriageRecordModel MarriageRecord { get; set; }

        public void OnGet()
        {
            // Initialization logic if needed
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _clientFactory.CreateClient("API");
            var json = JsonConvert.SerializeObject(MarriageRecord);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7060/api/Marriage/Create", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/MarriageRecord/List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error saving the marriage record.");
                return Page();
            }
        }
    }
}
