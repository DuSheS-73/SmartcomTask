using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartcomTask.Domain;
using SmartcomTask.Models;
using SmartcomTask.Service;
using SmartcomTask.ViewModels;

namespace SmartcomTask.Controllers
{
    [AllowAnonymous]
    public class ItemsController : Controller
    {
        private readonly DataManager dataManager;

        public ItemsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public JsonResult ItemsData()
        {
            List<Item> items = dataManager.itemsRepository.GetItems().ToList();
            items.Reverse();
            return Json(items);
        }




        [HttpGet]
        public IActionResult ItemDetails(Guid? Id)
        {
            if (Id == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Товар не найден" } });
            }

            var item = dataManager.itemsRepository.GetItemById(Id);

            if (item == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Товар не найден" } });
            }

            return Json(item);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Bind("Code,Name,Price,Category")] Item item)
        {
            if (ModelState.IsValid)
            {
                dataManager.itemsRepository.SaveItem(item);
                await dataManager.Commit();

                return Json(new ActionConfirmResult());
            }
            return Json(new ActionConfirmResult { Errors = ModelState.SelectMany(s => s.Value.Errors.Select(e => e.ErrorMessage)).ToList() });
        }



    

        public IActionResult Edit(Guid? Id)
        {
            if(Id == null)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Товар не найден" } });
            }

            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, [FromBody]Item item)
        {
            if(Id != item.ID)
            {
                return Json(new ActionConfirmResult() { Errors = new List<string>() { "Товар не найден" } });
            }

            if(ModelState.IsValid)
            {
                try
                {
                    dataManager.itemsRepository.SaveItem(item);
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
        public JsonResult ApplyFilter([FromBody] ItemsFilterViewModel model)
        {
            List<Item> items = dataManager.itemsRepository.GetItems().Where(c => c.Price >= model.PriceFrom
                                                                                 && c.Price <= model.PriceTo
                                                                                 && (c.Category.ToUpper() == model.Category.ToUpper() || model.Category == "")).ToList();
            items.Reverse();
            return Json(items);
        }




        [HttpPost]
        public async Task<JsonResult> Delete(Guid Id)
        {
            dataManager.itemsRepository.DeleteItem(Id);
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }




    }
}
