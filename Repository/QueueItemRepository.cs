using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository
{
    public interface IQueueItemRepository
    {
        IList<int> GetActive();
        void SaveChanges();
        QueueItem GetById(int queueItemId);
        void DeleteAndSaveChanges(QueueItem queueItem);
    }

    public class QueueItemRepository : IQueueItemRepository
    {
        readonly IDataContext dataContext;

        public QueueItemRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IList<int> GetActive()
        {
            return dataContext.Set<QueueItem>()
                .Where(qi => !qi.ProcessingFailedAt.HasValue)
                .Select(qi => qi.Id)
                .ToList();
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        public QueueItem GetById(int queueItemId)
        {
            return dataContext.Set<QueueItem>().Find(queueItemId);
        }

        public void DeleteAndSaveChanges(QueueItem queueItem)
        {
            dataContext.Set<QueueItem>().Remove(queueItem);
            SaveChanges();
        }
    }
}