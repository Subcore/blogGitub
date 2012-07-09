using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Domain.Abstract;
using Project.Domain.Entities;
using Project.WebUI.Models;

namespace Project.WebUI.Controllers
{
    public class BlogController : Controller
    {
        /*private IItemRepository repository;

        public BlogController(IItemRepository repo)
        {
            repository = repo;
        }*/

        public ViewResult Index(string returnUrl)
        {
            return View(new ItemIndexViewModel
            {
                blogposts = GetSomeText(),
                ReturnUrl = returnUrl
            });
        }

        public ViewResult AddToBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToBlog(string itemtext, string returnUrl)
        {
            GetSomeText().AddItem(itemtext);       
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromBlog(int itemid)
        { 
            GetSomeText().DeleteItem(itemid);
            return RedirectToAction("Index");
        }

        private Blogpost GetSomeText()
        {
            Blogpost blogpost = (Blogpost)Session["Blogpost"];
            if (blogpost == null)
            {
                blogpost = new Blogpost();
                Session["Blogpost"] = blogpost;
            }
            return blogpost;
        }

    }
}
