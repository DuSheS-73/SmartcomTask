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
                return Json(dataManager.orderElementRepository.GetOrderElements());
                //return Json(dataManager.orderRepository.GetAllOrders());
            }
            else
            {
                var customer = dataManager.customerRepository.GetCustomerByUserName(User.Identity.Name);
                var data = dataManager.orderElementRepository.GetOrderElementsBelongsToCustomer(customer.Id).ToList();

                return Json(data);
                //return Json(dataManager.orderRepository.GetOrdersBelongsToCustomer(customer.Id));
            }
        }










        [HttpPost]
        public async Task<JsonResult> MakeOrder([FromBody]List<ShoppingCartItem> shoppingCart)
        {
            if(ModelState.IsValid)
            {
                var customer = dataManager.customerRepository.GetCustomerByUserName(User.Identity.Name);

                Order order = new Order()
                {
                    CustomerId = customer.Id,
                    OrderNumber = new Random().Next(),
                    Status = "New"
                };
                dataManager.orderRepository.SaveOrder(order);

                foreach (var item in shoppingCart)
                {
                    OrderElement element = new OrderElement
                    {
                        Order = order,
                        Item = item.Item,
                        ItemsCount = item.Amount,
                        ItemPrice = item.Item.Price
                    };
                    dataManager.orderElementRepository.SaveOrderElement(element);
                }

                await dataManager.Commit();

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }
    }
}
