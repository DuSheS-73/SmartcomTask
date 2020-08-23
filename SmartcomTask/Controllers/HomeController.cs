using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartcomTask.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetLastTenItems()
        {
            List<Item> items = dataManager.itemsRepository.GetItems().ToList();
            items.Reverse();
            return Json(items.Take(10));
        }
    }
}
