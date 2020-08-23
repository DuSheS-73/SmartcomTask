using System;
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

        [HttpPost]
        public JsonResult GetOrders([FromBody]OrderStatusReceiveViewModel model)
        {
            if(User.IsInRole("Admin"))
            {
                return Json(dataManager.orderRepository.GetAllOrders(model.GetStatus()));
            }
            else
            {
                var customer = dataManager.customerRepository.GetCustomerByUserName(User.Identity.Name);
                var data = dataManager.orderRepository.GetOrdersBelongsToCustomer(customer.Id, model.GetStatus());
                return Json(data);
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
            order.SetStatus();
            dataManager.orderRepository.SaveOrder(order);
            await dataManager.Commit();
            
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
