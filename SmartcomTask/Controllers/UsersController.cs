using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
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
                return RedirectToAction("Index", "Error");
            }

            var user = dataManager.userRepository.GetUserById(Id);
            
            if(user == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return Json(user);
        }



        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] RegisterViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var newUser = new ApplicationUser(model);

        //        List<string> RegistrationErrors = dataManager.userRepository.UserCreateResult(newUser);
        //        if(RegistrationErrors.IsNullOrEmpty())
        //        {
        //            var result = await userManager.CreateAsync(newUser);
        //            if (result.Succeeded)
        //            {
        //                await userManager.AddToRoleAsync(newUser, "User");
        //                return Json(new ActionConfirmResult());
        //            }
        //        }
        //        return Json(new ActionConfirmResult { Errors = RegistrationErrors });
        //    }
        //    return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        //}



        public IActionResult Edit(Guid? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index", "Error");
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


                var result = await userManager.UpdateAsync(CurrentUser);
                //try
                //{
                //    dataManager.userRepository.SaveUser(CurrentUser);
                //    await dataManager.Commit();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    throw;
                //}
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
