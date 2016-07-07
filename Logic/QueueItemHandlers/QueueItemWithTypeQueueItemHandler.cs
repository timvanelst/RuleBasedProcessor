using Domain;

namespace Logic
{
    public class QueueItemWithTypeQueueItemHandler : IQueueItemHandler
    {
        private readonly ITypeAdapter typeAdapter;

        public QueueItemWithTypeQueueItemHandler(ITypeAdapter typeAdapter)
        {
            this.typeAdapter = typeAdapter;
        }

        public bool CanHandle(QueueItem queueItem)
        {
            return queueItem is IHasType;
        }

        public void Enrich(Item item, QueueItem queueItem)
        {
            var queueItemWithType = queueItem as IHasType;
            if (queueItemWithType == null) return;
            item.Type = typeAdapter.CreateOrDefault(queueItemWithType.Type);
        }
    }
}