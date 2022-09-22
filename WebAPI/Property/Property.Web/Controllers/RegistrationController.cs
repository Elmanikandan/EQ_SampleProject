using Microsoft.AspNetCore.Mvc;
using Property.Web.Models;
using Property.Web.Services.Base;
using Property.Web.ViewModels;
using System.Net;

namespace Property.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public RegistrationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var result = await unitOfWork.RegistrationService.GetAllAsync();            
            return View(result.Record);
        }
        [HttpGet]
        public IActionResult Create()
        {
            RegistrationViewModel registrationView = new RegistrationViewModel();
            registrationView.Registration = new RegistrationModel();
            return View(registrationView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationModel registration)
        {            
            if (ModelState.IsValid)
            {
                var response = await unitOfWork.RegistrationService.AddAsync(registration);
                if (response.ResponseCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = response.Message;
                    return View(registration);
                }
            }
            else
                return View(registration);
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
                var response = await unitOfWork.RegistrationService.GetAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    //TempData["success"] = response.Message;
                    RegistrationViewModel registrationView = new RegistrationViewModel();
                    registrationView.Registration = response.Record;
                    return View("Create", registrationView);
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
        public async Task<IActionResult> Edit(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            var response = await unitOfWork.RegistrationService.UpdateAsync(registration);
            if (response.ResponseCode == System.Net.HttpStatusCode.OK)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(registration);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await unitOfWork.RegistrationService.GetAllAsync();
            return Json(new { data = response.Record });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var result = await unitOfWork.RegistrationService.GetAsync(id);
            if (result == null || result.Record == null)
            {
                return Json(new { success = false, message = result.Message });
            }
            var response = await unitOfWork.RegistrationService.DeleteAsync(id);
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
