using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Property.Web.Models;
using System.Text;
using System;

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
        public async Task<IActionResult> AddProperty()
        {
            return View("Add");
        }

        public async Task<IActionResult> Create(Properties property)
        {
            var json = JsonConvert.SerializeObject(property);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); 
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:44351/api/Properties", stringContent);
            
            return View("Create",property);
        }
    }
}
