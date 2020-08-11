using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartcomTask.Domain;
using SmartcomTask.Models;

namespace SmartcomTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));

            return View();
        }

        
    }
}
