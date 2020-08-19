using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [Authorize]
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

        [HttpGet]
        public JsonResult GetOrders()
        {
            if(User.IsInRole("Admin"))
            {
                return Json(dataManager.orderRepository.GetAllOrders());
            }
            else
            {
                var customer = dataManager.customerRepository.GetCustomerByUserName(User.Identity.Name);
                return Json(dataManager.orderRepository.GetOrdersBelongsToCustomer(customer.Id));
            }
        }

        [HttpGet]
        public JsonResult GetOrderDetails(Guid Id)
        {
            return Json(dataManager.orderElementRepository.GetOrderElementsByOrderId(Id));
        }


        [HttpPost]
        public async Task<JsonResult> SetOrderStatus([FromBody]Order order)
        {
            string[] Statuses = { "Новый", "Выполняется", "Выполнен" };
            order.Status = Statuses[ Array.IndexOf(Statuses, order.Status) + 1 ];
            dataManager.orderRepository.SaveOrder(order);

            return Json(new ActionConfirmResult());
        }


        [HttpPost]
        public async Task<JsonResult> DeleteOrder(Guid Id)
        {
            dataManager.orderRepository.DeleteOrder(Id);
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }





       
    }
}
