using Development.Assesment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Development.Assessment.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<User> Users { get; set; } = new List<User>();
        public List<Group> Groups { get; set; } = new List<Group> { };
        public List<Permission> Permissions { get; set; } = new List<Permission>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            string userdata = await GetData("User");
            Users = JsonConvert.DeserializeObject<List<User>>(userdata);

            string groupdata = await GetData("Group");
            Groups = JsonConvert.DeserializeObject<List<Group>>(groupdata);

            string permissiondata = await GetData("Permission");
            Permissions = JsonConvert.DeserializeObject<List<Permission>>(permissiondata);

        }

        private async Task<string> GetData(string service)
        {
            using (HttpClient client = new HttpClient())
            {
                // Set the base URL of your API
                client.BaseAddress = new Uri("https://localhost:7051/");

                // Set the endpoint and query parameters
                string endpoint = "Operations/Read";

                // Build the full URL
                string requestUrl = $"{endpoint}?service={service}";

                // Make the GET request
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
    }
}