using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;

namespace SmartcomTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly DataManager dataManager;
        public CustomersController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CustomersData()
        {
            var data = dataManager.customerRepository.GetCustomers();
            return Json(data);
        }



        [HttpGet]
        public IActionResult CustomerDetails(Guid? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Error");
            }

            var customer = dataManager.customerRepository.GetCustomerById(Id);
            
            if(customer == null)
            {
                return RedirectToAction("Index", "Error");
            }
            return Json(customer);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Bind("")] Customer model)
        {
            if(ModelState.IsValid)
            {
                dataManager.customerRepository.SaveCustomer(model);
                await dataManager.Commit();

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }








        public IActionResult Edit(Guid? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index", "Error");
            }

            ViewBag.Id = Id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, [FromBody]Customer model)
        {
            if(model.Id == null)
            {
                return RedirectToAction("Index", "Error");
            }

            if(ModelState.IsValid)
            {
                try
                {
                    dataManager.customerRepository.SaveCustomer(model);
                    await dataManager.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }




        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            dataManager.customerRepository.DeleteCustomer(Id);
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }
    }
}
