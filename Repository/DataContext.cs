using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        void SaveChanges();

        IDbSet<QueueItem> QueueItems { get; set; }
        IDbSet<Item> Items { get; set; }
    }

    public class DataContext : DbContext, IDataContext
    {
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public IDbSet<QueueItem> QueueItems { get; set; }
        public IDbSet<Item> Items { get; set; }
    }
}
