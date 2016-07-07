using System.Collections.Generic;
using Domain;
using Repository;

namespace Logic
{
    public interface IQueueManager
    {
        IList<int> GetItemsIds();
        QueueItem GetItem(int queueItemId);
        void SaveChanges();
        void HandleProcessError(QueueItem queueItem, IList<string> businessException);
        void DeQueue(QueueItem queueItem);
    }

    public class QueueManager : IQueueManager
    {
        private readonly IQueueItemRepository queueItemRepository;

        public QueueManager(IQueueItemRepository queueItemRepository)
        {
            this.queueItemRepository = queueItemRepository;
        }

        public IList<int> GetItemsIds()
        {
            return queueItemRepository.GetActive();
        }

        public QueueItem GetItem(int queueItemId)
        {
            return queueItemRepository.GetById(queueItemId);
        }

        public void SaveChanges()
        {
            queueItemRepository.SaveChanges();
        }

        public void HandleProcessError(QueueItem queueItem, IList<string> businessException)
        {
            throw new System.NotImplementedException();
        }

        public void DeQueue(QueueItem queueItem)
        {
            queueItemRepository.DeleteAndSaveChanges(queueItem);
        }
    }
}