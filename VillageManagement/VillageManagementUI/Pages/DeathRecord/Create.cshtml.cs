using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillageManagementUI.Model;
using Newtonsoft.Json;
using System.Text;

namespace VillageManagementUI.Pages.DeathRecord
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty]
        public Model.DeathRecordModel DeathRecord { get; set; }

        public string Message { get; set; }
        public string AlertType { get; set; } = "info";

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _clientFactory.CreateClient("API");
            var json = JsonConvert.SerializeObject(DeathRecord);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7060/api/DeathRecords/Create", content);

            if (response.IsSuccessStatusCode)
            {
                Message = "Death record registered successfully.";
                AlertType = "success";
                DeathRecord = new(); // reset form
            }
            else
            {
                Message = "Something went wrong while submitting.";
                AlertType = "danger";
            }

            return Page();
        }

    }
}
