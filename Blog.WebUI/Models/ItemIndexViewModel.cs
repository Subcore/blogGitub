using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Domain.Entities;

namespace Project.WebUI.Models
{
    public class ItemIndexViewModel
    {
        public Blogpost blogposts { get; set; }
        public string ReturnUrl { get; set; }
    }
}