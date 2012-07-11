using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Domain.Entities;
using System.Linq.Expressions;

namespace Project.Domain.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> All { get; }
        IQueryable<Item> AllIncluding(params Expression<Func<Item, object>>[] includeProperties);
        Item Find(int id);
        void InsertOrUpdate(Item item);
        void Delete(int id);
        void Save();
    }
}
