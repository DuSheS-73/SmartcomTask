using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<ApplicationUser> userManager;
        public UsersController(DataManager dataManager, UserManager<ApplicationUser> userManager)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult UsersData()
        {
            return Json(dataManager.userRepository.GetUsers());
        }



        [HttpGet]
        public IActionResult UserDetails(Guid? Id)
        {
            if (Id == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Пользователь не найден" } });
            }

            var user = dataManager.userRepository.GetUserById(Id);
            
            if(user == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Пользователь не найден" } });
            }
            return Json(user);
        }



        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit(Guid? Id)
        {
            if(Id == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Пользователь не найден" } });
            }

            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, [FromBody] EditUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var CurrentUser = dataManager.userRepository.GetUserById(Id);
                CurrentUser.Customer.Name = model.Name;
                CurrentUser.UserName = model.UserName;
                CurrentUser.Email = model.Email;
                CurrentUser.Customer.Code = model.Code;
                CurrentUser.Customer.Address = model.Address;
                CurrentUser.Customer.Discount = model.Discount;


                await userManager.UpdateAsync(CurrentUser);
                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            dataManager.userRepository.DeleteUser(Id);
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }
    }
}
