using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> LoadProperty()
        {
            var result = await unitOfWork.PropertiesService.GetAllAsync();
            return View(result.Record);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PropertiesVM propertyView = new PropertiesVM();
            propertyView.Properties = new Properties();
            var result = await unitOfWork.RegistrationService.GetAllAsync();
            var ownerList = result.Record.Where(x=> x.Type == "Owner").ToList();
            List<SelectListItem> item = new List<SelectListItem>();
            foreach(var owner in ownerList)
            {
                SelectListItem lst = new SelectListItem();
                lst.Text = owner.Name;
                lst.Value = owner.Name;
                item.Add(lst);
            }
            propertyView.Owner = item;

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
                    PropertiesVM propertyView = new PropertiesVM();
                    propertyView.Properties = response.Record;                
                   
                    var result = await unitOfWork.RegistrationService.GetAllAsync();
                    var ownerList = result.Record.Where(x => x.Type == "Owner").ToList();
                    List<SelectListItem> item = new List<SelectListItem>();
                    foreach (var owner in ownerList)
                    {
                        SelectListItem lst = new SelectListItem();
                        lst.Text = owner.Name;
                        lst.Value = owner.Name;
                        item.Add(lst);
                    }
                    propertyView.Owner = item;
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
            var response = await unitOfWork.PropertiesService.UpdateAsync(properties);
            if (response.ResponseCode == System.Net.HttpStatusCode.OK)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await unitOfWork.PropertiesService.GetAsync(id);
            if (result == null || result.Record == null)
            {
                return Json(new { success = false, message = result.Message });
            }
            var response = await unitOfWork.PropertiesService.DeleteAsync(id);
            if (response.ResponseCode == System.Net.HttpStatusCode.OK)
            {
                return Json(new { success = true, message = response.Message });
            }
            else
            {
                return Json(new { success = false, message = response.Message });
            }

        }
    }
}
