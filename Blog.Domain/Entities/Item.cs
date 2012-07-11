using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project.Domain.Entities
{
    //public class Blogpost
    //{
    //    private List<Item> ItemCollection = new List<Item>();

    //    public Item Item { get; set; }

    //    /*public void AddItem(string itemtext)
    //    {
    //        int itemid = ItemCollection.Count();
    //        ItemCollection.Add(new Item { ItemID = itemid , ItemText = itemtext });
    //    }

    //    public void DeleteItem(int itemid)
    //    {
    //        ItemCollection.RemoveAt(itemid);
    //    }*/

    //    public IEnumerable<Item> Items
    //    {
    //        get { return ItemCollection; }
    //    }
    //}

    public class Item
    {
        public int ItemID { get; set; }
        [DataType(DataType.MultilineText)]
        public string ItemText { get; set; }

    }
}
