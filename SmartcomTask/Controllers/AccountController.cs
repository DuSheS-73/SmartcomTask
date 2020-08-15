using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartcomTask.Models;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region LOGIN

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
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
                        return RedirectToAction("Index", "Home");
                        //return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(loginModel);
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
        public async Task<IActionResult> Registration([FromBody]RegisterViewModel registrationModel)
        {
            var newUser = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = registrationModel.UserName,
                NormalizedUserName = registrationModel.UserName.ToUpper(),
                Email = registrationModel.Email,
                NormalizedEmail = registrationModel.Email.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = registrationModel.Name,
                    Address = registrationModel.Address,
                    Code = new Random().Next(1000, 9999).ToString() + "-" + new DateTime().Year.ToString("yyyy"),
                    Discount = 0
                }
            };

            var result = await userManager.CreateAsync(newUser, registrationModel.Password);
            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "User");
                await signInManager.SignInAsync(newUser, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(registrationModel);
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
