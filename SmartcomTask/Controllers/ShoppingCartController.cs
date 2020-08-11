using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartcomTask.Models;

namespace SmartcomTask.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            //var sessionUser = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("SessionUser"));
            return View();
        }
    }
}
