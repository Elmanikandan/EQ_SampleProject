using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Property.Web.Models;

namespace Property.Web.Controllers
{
    public class PropertiesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Properties> propertyList = new List<Properties>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44351/api/Properties"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    propertyList = JsonConvert.DeserializeObject<List<Properties>>(apiResponse);
                }
            }
            return View(propertyList);
        }
    }
}
