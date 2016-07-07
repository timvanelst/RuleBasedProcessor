using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Logic
{
    public interface IItemConverter
    {
        Item Create(QueueItem queueItem);
    }

    public class ItemConverter: IItemConverter
    {
        private readonly IEnumerable<IQueueItemHandler> handlers;

        public ItemConverter(IEnumerable<IQueueItemHandler> handlers)
        {
            this.handlers = handlers;
        }

        public Item Create(QueueItem queueItem)
        {
            var item = new Item();
            foreach (var handler in handlers.Where(h => h.CanHandle(queueItem)))
            {
                handler.Enrich(item, queueItem);
            }
            return item;
        }
    }
}