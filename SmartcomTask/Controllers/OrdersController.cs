using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;

namespace SmartcomTask.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataManager dataManager;
        public OrdersController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> MakeOrder([FromBody][Bind("")]Order order)
        {
            if(ModelState.IsValid)
            {
                dataManager.orderRepository.SaveOrder(order);
                await dataManager.Commit();

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }
    }
}
