using System;
using Microsoft.AspNetCore.Mvc;
using Inventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
  public class ItemsController : Controller
  {
    private readonly InventoryContext _db;

    public ItemsController(InventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item, Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      _db.Items.Add(item);
      item.CategoryId = category.Id;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      Category thisCategory = _db.Categories.FirstOrDefault(category => category.Id == thisItem.CategoryId);
      // string categoryName = thisCategory.Name;
      ViewBag.CategoryName = thisCategory.Name;
      return View(thisItem);
    }
  }


}

// using Microsoft.AspNetCore.Mvc;
// using Inventory.Models;
// using System.Collections.Generic;

// namespace Inventory.Controllers
// {
//   public class ItemsController : Controller
//   {

//     [HttpGet("/categories/{categoryId}/items/new")]
//     public ActionResult New(int categoryId)
//     {
//       Category category = Category.Find(categoryId);
//       return View(category);
//     }

//     [HttpPost("/items/delete")]
//     public ActionResult DeleteAll()
//     {
//       Item.ClearAll();
//       return View();
//     }

//     [HttpGet("/categories/{categoryId}/items/{itemId}")]
//     public ActionResult Show(int categoryId, int itemId)
//     {
//       Item item = Item.Find(itemId);
//       Category category = Category.Find(categoryId);
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       model.Add("item", item);
//       model.Add("category", category);
//       return View(model);
//     }
//   }
// }