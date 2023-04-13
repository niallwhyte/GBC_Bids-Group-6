using GBC_Bids_Group_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GBC_Bids_Group_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemContext _itemContext;

        public HomeController(ItemContext itemContext)
        {
            _itemContext = itemContext;
        }

        [HttpGet]
        public IActionResult Asset()
        {
            var categories = _itemContext.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.Categories = categories;
            var conditions = _itemContext.Conditions.OrderBy(c => c.Name).ToList();
            ViewBag.Conditions = conditions;
            var items = _itemContext.Items.
                OrderBy(i => i.ProductName).ToList();
            return View(items);
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}