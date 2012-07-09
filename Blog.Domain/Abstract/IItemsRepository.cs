using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> Items { get; }
        void AddItem(Item itemtext);
    }
}
