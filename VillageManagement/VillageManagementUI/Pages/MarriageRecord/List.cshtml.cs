using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VillageManagementUI.Model;

namespace VillageManagementUI.Pages.MarriageRecord
{
    public class ListModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ListModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<MarriageRecordModel> MarriageRecords { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync("https://localhost:7060/api/Marriage/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                MarriageRecords = JsonConvert.DeserializeObject<List<MarriageRecordModel>>(json);
            }
            else
            {
                MarriageRecords = new List<MarriageRecordModel>(); // fallback to empty list
            }
        }
    }
}
