using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Property.Web.Models;
using Property.Web.Services.Base;
using Property.Web.ViewModels;

namespace Property.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public PropertiesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var result = await unitOfWork.PropertiesService.GetAllAsync();
            return View(result.Record);
        }
        [HttpGet]
        public IActionResult Create()
        {
            PropertiesVM propertyView = new PropertiesVM();
            propertyView.Properties = new Properties();
            return View(propertyView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Properties properties)
        {
            if (ModelState.IsValid)
            {
                var response = await unitOfWork.PropertiesService.AddAsync(properties);
                if (response.ResponseCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = response.Message;
                    return View(properties);
                }
            }
            else
                return View(properties);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var response = await unitOfWork.PropertiesService.GetAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    TempData["success"] = response.Message;
                    PropertiesVM propertyView = new PropertiesVM();
                    propertyView.Properties = response.Record;
                    return View("Create", propertyView);
                }
                else
                {
                    TempData["error"] = response.Message;
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Properties properties)
        {
            if (!ModelState.IsValid)
            {
                return View(properties);
            }

            //var response = await _categoryHttpService.UpdateAsync(category);
            var response = await unitOfWork.PropertiesService.UpdateAsync(properties);
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(properties);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await unitOfWork.PropertiesService.GetAllAsync();
            return Json(new { data = response.Record });
        }
    }
}
