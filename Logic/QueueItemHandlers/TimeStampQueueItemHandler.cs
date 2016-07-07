using Domain;

namespace Logic
{
    public class TimeStampQueueItemHandler : IQueueItemHandler
    {
        public bool CanHandle(QueueItem queueItem)
        {
            return queueItem is IHasTimeStamp;
        }

        public void Enrich(Item item, QueueItem queueItem)
        {
            item.TimeStamp = queueItem.TimeStamp;
        }
    }
}