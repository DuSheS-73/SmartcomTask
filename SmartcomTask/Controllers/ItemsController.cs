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



        [HttpGet("ItemsData")]
        public async Task<JsonResult> ItemsData()
        {
            var items = await dataManager.itemsRepository.GetItems().ToListAsync();
            return Json(items);
        }




        [HttpGet]
        public IActionResult ItemDetails(Guid? Id)
        {
            if (Id == null)
            {
                // set to NotFound page
                return RedirectToAction("Index", "Error");
            }

            var item = dataManager.itemsRepository.GetItemById(Id);

            if (item == null)
            {
                // set to NotFound page
                return RedirectToAction("Index", "Error");
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
                // set to NotFound page
                return RedirectToAction("Index", "Error");
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
        public async Task<JsonResult> Delete(Guid Id)
        {
            dataManager.itemsRepository.DeleteItem(Id);
            await dataManager.Commit();

            return Json(new ActionConfirmResult());
        }




    }
}
