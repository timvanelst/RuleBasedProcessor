using Domain;
using Repository;

namespace Logic
{
    public interface IItemManager
    {
        void InsertAndSave(Item entity);
    }

    public class ItemManager : IItemManager
    {
        private readonly IDataContext dataContext;

        public ItemManager(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void InsertAndSave(Item entity)
        {
            dataContext.Items.Add(entity);
            dataContext.SaveChanges();
        }
    }
}