using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DataManager dataManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DataManager dataManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dataManager = dataManager;
        }

        #region LOGIN

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginModel.UserName);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);
                    if(result.Succeeded)
                    {
                        return Json(new ActionConfirmResult());
                    }
                }
                return Json(new ActionConfirmResult { Errors = new List<string> { "Неверный логин или пароль" } });
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }

        #endregion

        #region REGISTRATION

        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody] RegisterViewModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser(registrationModel);


                List<string> RegistrationErrors = dataManager.userRepository.UserCreateResult(newUser);
                if (RegistrationErrors.IsNullOrEmpty())
                {

                    var result = await userManager.CreateAsync(newUser);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, "User");
                        return Json(new ActionConfirmResult());
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return Json(new ActionConfirmResult { Errors = RegistrationErrors });
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }

        #endregion

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
