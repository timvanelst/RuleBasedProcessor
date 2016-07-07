using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Repository;

namespace Specifications
{
    public class FakeDataContext : IDataContext
    {
        public FakeDataContext()
        {
            Items = new InMemoryDbSet<Item>();
            QueueItems = new InMemoryDbSet<QueueItem>();
        }
        public IDbSet<QueueItem> QueueItems { get; set; }
        public IDbSet<Item> Items { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            if (typeof(T) == typeof(Item))
            {
                return (IDbSet<T>)Items;
            }
            if (typeof(T) == typeof(QueueItemWithType))
            {
                return (IDbSet<T>)QueueItems;
            }
            if (typeof(T) == typeof(QueueItem))
            {
                return (IDbSet<T>) QueueItems;
            }

            throw new NotImplementedException(string.Format("Set<{0}> not yet implemented in {1}",
                typeof(T),
                "FakeDataContext"));
        }

        public void SaveChanges()
        {
        }
    }
}