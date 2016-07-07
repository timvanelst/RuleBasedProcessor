using Domain;

namespace Logic
{
    public interface IQueueItemHandler
    {
        bool CanHandle(QueueItem queueItem);
        void Enrich(Item item, QueueItem queueItem);
    }
}