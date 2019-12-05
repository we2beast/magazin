using System.Collections.Generic;
using System.Web.Mvc;
using Magazin.Areas.Manager.Models;
using BusinessLayer.Domain;
using Magazin.Controllers;
using Service.Services;
using System;

namespace Magazin.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ItemController : MyController
    {
        private IItemService itemService;
        private ICategoryService categoryService;
        public ItemController(IItemService itemServicem, ICategoryService categoryService)
        {
            this.itemService = itemServicem;
            this.categoryService = categoryService;
        }
        public List<SelectListItem> GetSelectList()
        {
            var categorys = categoryService.GetCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var temp in categorys)
            {
                list.Add(new SelectListItem()
                {
                    Text = temp.Name,
                    Value = temp.CategoryId.ToString(),
                });
            }
            list.Add(new SelectListItem() { Text = "", Value = "", Selected = true });
            return list;
        }
        public List<SelectListItem> GetSelectList(Item item)
        {
            var categorys = categoryService.GetCategories();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var temp in categorys)
            {
                list.Add(new SelectListItem()
                {
                    Text = temp.Name,
                    Value = temp.CategoryId.ToString(),
                    Selected = (temp.CategoryId == item.CategoryId ? true : false)
                });
            }
            list.Add(new SelectListItem() { Text = "", Value = "", Selected = true });
            return list;
        }

        public ActionResult Index()
        {
            IEnumerable<Item> items = itemService.GetItems();
            var itemVMs = Mapper.Map<IEnumerable<Item>, List<ItemListModelManager>>(items);
            return View(itemVMs);
        }

        public ActionResult Create()
        {
            ItemCreateModel ItemCM = new ItemCreateModel();
            ItemCM.CategoryList = GetSelectList();
            return View(ItemCM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreateModel itemCM)
        {
            Item item = Mapper.Map<ItemCreateModel, Item>(itemCM);
            itemService.CreateItem(item);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string code)
        {
            Item item = itemService.GetItemByCode(code);
            var itemVM = Mapper.Map<Item, ItemViewModel>(item);
            return View(itemVM);
        }

        public ActionResult Edit(string code)
        {
            Item item = itemService.GetItemByCode(code);
            ItemEditModel itemEM = Mapper.Map<Item, ItemEditModel>(item);
            itemEM.CategoryList = GetSelectList(item); 
            return View(itemEM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemEditModel itemEM)
        {
            Item item = itemService.GetItemByCode(itemEM.Code);

            if (string.IsNullOrWhiteSpace(itemEM.CategoryId))
                item.CategoryId = null;
            else
                item.CategoryId = Guid.Parse(itemEM.CategoryId);
            item.Name = itemEM.Name;
            item.Price = itemEM.Price;
            itemService.EditItem(item);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string code)
        {
            itemService.DeleteItem(code);
            return RedirectToAction("Index");
        }
    }
}