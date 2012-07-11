using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Domain.Abstract;
using Project.Domain.Entities;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web;

namespace Project.Domain.Concrete
{
    public class ItemRepository : IItemRepository
    {
        public class ProjectWebUIContext : DbContext
        {
            public DbSet<Project.Domain.Entities.Item> Items { get; set; }
        }

        ProjectWebUIContext context = new ProjectWebUIContext();
        
        /*private Blogpost GetSomeText()
        {
            Blogpost blogpost = (Blogpost)Session["Blogpost"];
            if (blogpost == null)
            {
                blogpost = new Blogpost();
                Session["Blogpost"] = blogpost;
            }
            return blogpost;
        }*/

        public IQueryable<Item> All
        {
            get { return context.Items; }
        }

        public IQueryable<Item> AllIncluding(params Expression<Func<Item, object>>[] includeProperties)
        {
            IQueryable<Item> query = context.Items;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Item Find(int id)
        {
            return context.Items.Find(id);
        }

        public void InsertOrUpdate(Item item)
        {
            if (item.ItemID == default(int))
            {
                // New entity
                context.Items.Add(item);
            }
            else
            {
                // Existing entity
                context.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var item = context.Items.Find(id);
            context.Items.Remove(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
