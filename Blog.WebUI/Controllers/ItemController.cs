using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Domain.Entities;
using Project.Domain.Abstract;
using Project.Domain.Concrete;

namespace Blog.WebUI.Controllers
{   
    public class ItemController : Controller
    {
		private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
			this.itemRepository = itemRepository;
        }

        //
        // GET: /Item/

        public ViewResult Index()
        {
            return View(itemRepository.All);
        }

        //
        // GET: /Item/Details/5

        public ViewResult Details(int id)
        {
            return View(itemRepository.Find(id));
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid) {
                itemRepository.InsertOrUpdate(item);
                itemRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Item/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(itemRepository.Find(id));
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid) {
                itemRepository.InsertOrUpdate(item);
                itemRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Item/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(itemRepository.Find(id));
        }

        //
        // POST: /Item/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            itemRepository.Delete(id);
            itemRepository.Save();

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing) {
        //        itemRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private Item GetSomeText()
        //{
        //    Item item = (Item)Session["Item"];
        //    if (item == null)
        //    {
        //        item = new Item();
        //        Session["Item"] = item;
        //    }
        //    return item;
        //}
    }
}

