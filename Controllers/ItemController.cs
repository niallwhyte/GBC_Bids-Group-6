using GBC_Bids_Group_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using GBC_Bids_Group_6.Models;
using System.Net.Http.Headers;


namespace GBC_Bids_Group_6.Controllers
{
    public class ItemController : Controller
    {
        private ItemContext _itemContext { get; set; }

        public ItemController(ItemContext ctx)
        {
            _itemContext = ctx;
        }

        public async Task<IActionResult> Asset()
        {
            return View(await _itemContext.Items.ToListAsync());
        }

        [HttpGet]
        public IActionResult DetailsAsset (int id)
        {
            var item = _itemContext.Items
                     .FirstOrDefault(i => i.ItemId == id);
            var cat = _itemContext.Categories.FirstOrDefault(c => c.Id == item.CategoryID);
            var con = _itemContext.Conditions.FirstOrDefault(d => d.Id == item.ConditionID);
            var sell = _itemContext.Users.FirstOrDefault(d => d.id == item.SellerID);
            ViewBag.catname = cat;
            ViewBag.conname = con;
            ViewBag.sellername = sell;
            return View(item);
        }

        public IActionResult Add()
        {
            var categories = _itemContext.Categories.OrderBy(c => c.Id).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Id).ToList();
            ViewBag.Conditions = conditions;

            ViewBag.Action = "Add";
            ViewBag.Title = "Add Item";
            ViewBag.Items = _itemContext.Items;
            return View("Add", new ItemAsset());
        }


        [HttpPost]
        public async Task<IActionResult> Add(ItemAsset item)
        {
            var categories = _itemContext.Categories.OrderBy(c => c.Id).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Id).ToList();
            ViewBag.Conditions = conditions;

            if (ModelState.IsValid)
            {
                item.AuctionStartDate = DateTime.UtcNow;
                item.SellerID = 2;
                try
                {
                    if (Request.Cookies["username"]!=null)
                    {
                        var uservalue = Request.Cookies["username"];
                        item.SellerID = Int32.Parse(uservalue);
                    }
                }
                catch { item.SellerID = 2; }

                _itemContext.Items.Add(item);
                await _itemContext.SaveChangesAsync();

                return RedirectToAction("Asset", "Home");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.Title = "Add Item";
                ViewBag.Items = _itemContext.Items
                    .OrderBy(c => c.ProductName)
                    .ToList();
                return View("Add", item);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = _itemContext.Categories.OrderBy(c => c.Id).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Id).ToList();
            ViewBag.Conditions = conditions;

            ViewBag.Action = "Edit";
            ViewBag.Items = _itemContext.Items.
                                 OrderBy(i => i.ProductName).ToList();

            var item = _itemContext.Items
                        .FirstOrDefault(i => i.ItemId == id);

            return View(item);
        }



        [HttpPost]
        public IActionResult Edit(ItemAsset i)
        {

            var categories = _itemContext.Categories.OrderBy(c => c.Id).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Id).ToList();
            ViewBag.Conditions = conditions;

            string action = (i.ItemId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                // pass validation
                if (action == "add")
                {
                    i.AuctionStartDate = DateTime.Now;
                    _itemContext.Items.Add(i);
                }
                else
                {
                    _itemContext.Items.Update(i);
                }

                _itemContext.SaveChanges();
                return RedirectToAction("Asset", "Home");

            }
            else
            {
                // fail validation
                ViewBag.Action = action;
                ViewBag.Categories = _itemContext.Items.
                                     OrderBy(i => i.ProductName).ToList();

                return View(i);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemContext.Items
                        .FirstOrDefault(c => c.ItemId == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _itemContext.Items
                        .FirstOrDefault(c => c.ItemId == id);

            if (item != null)
            {
                _itemContext.Items.Remove(item);
                _itemContext.SaveChanges();
            }

            return RedirectToAction("Asset", "Home");
        }

        [HttpPost]
        public IActionResult Search()
        {
            var categories = _itemContext.Categories.OrderBy(c => c.Id).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Id).ToList();
            ViewBag.Conditions = conditions;
            var sorting = HttpContext.Request.Form["sorting"];
            var catID = HttpContext.Request.Form["cat_choice"];
            var conID = HttpContext.Request.Form["con_choice"];
            string searchFor = HttpContext.Request.Form["search"];


            var items = _itemContext.Items.
                OrderBy(i => i.ProductName).ToList();

            if (searchFor != "")
            {
                items =_itemContext.Items.Where(i => i.ProductName.Contains(searchFor)).ToList();
            }

            switch (sorting)
            {
                case "NA":
                    items=items.OrderBy(i => i.ProductName).ToList();
                    break;
                case "ND":
                    items=items.OrderByDescending(i => i.ProductName).ToList();
                    break;
                case "PA":
                    items=items.OrderBy(i => i.MinimumBidAmount).ToList();
                    break;
                case "PD":
                    items=items.OrderByDescending(i => i.MinimumBidAmount).ToList();
                    break;
                default:
                    items=items.OrderBy(i => i.AuctionStartDate).ToList();
                    break;

            }

            int catIDnum;

            try
            {
                catIDnum = Int32.Parse(catID);
            } catch { catIDnum = 0; }

            if(catIDnum > 0 && catIDnum <= categories.Count)
            {
                items=items.Where(i => i.CategoryID == catIDnum).ToList();
            }

            int conIDnum;

            try
            {
                conIDnum = Int32.Parse(conID);
            }
            catch { conIDnum = 0; }

            if(conIDnum > 0 && conIDnum <= conditions.Count)
            {
                items=items.Where(i => i.ConditionID == conIDnum).ToList();
            }

            return View(items);
        }

    }
}
