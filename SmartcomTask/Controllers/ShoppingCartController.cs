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
using SmartcomTask.Service;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly DataManager dataManager;
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartController(DataManager dataManager, ShoppingCart shoppingCart)
        {
            this.dataManager = dataManager;
            this.shoppingCart = shoppingCart;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetCart()
        {
            ShoppingCartViewModel cartVM = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                Total = shoppingCart.GetShoppingCartTotal()
            };

            return Json(cartVM);
        }


        [HttpPost]
        public JsonResult AddToCart([FromBody]Item item)
        {
            if(ModelState.IsValid)
            {
                shoppingCart.AddToCart(item, 1);

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }



        [HttpPost]
        public async Task<JsonResult> RemoveFromCart([FromBody]Item item)
        {
            if (ModelState.IsValid)
            {
                shoppingCart.RemoveFromCart(item);
                await dataManager.Commit();

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }


        [HttpPost]
        public async Task<JsonResult> ClearAll()
        {
            shoppingCart.ClearCart();
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }



        [HttpPost]
        public async Task<IActionResult> ConfirmOrder([FromBody] List<ShoppingCartItem> shoppingCartItems)
        {
            if (ModelState.IsValid)
            {
                var customer = dataManager.customerRepository.GetCustomerByUserName(User.Identity.Name);

                Order order = new Order(customer.Id);
                dataManager.orderRepository.SaveOrder(order);

                foreach (var item in shoppingCartItems)
                {
                    OrderElement element = new OrderElement(order, item);
                    dataManager.orderElementRepository.SaveOrderElement(element);
                }

                await dataManager.Commit();

                await ClearAll();
                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }
    }
}
