using System.Linq;
using Domain;

namespace Specifications
{
    internal static class FakeDataContextHelper
    {
        internal static QueueItem CreateQueueItem(this FakeDataContext dataContext, QueueItemDto dto)
        {
            QueueItem queueItem;

            if (dto.Type.HasValue())
            {
                queueItem = new QueueItemWithType
                {
                    Type = dto.Type
                };      
            }
            else
            {
                queueItem = new QueueItem();
            }
            queueItem.TimeStamp = dto.TimeStamp;
            var nextId = dataContext.QueueItems.Any() ? dataContext.QueueItems.Max(qi => qi.Id) : 1;
            queueItem.Id = nextId;
            
            dataContext.QueueItems.Add(queueItem);

            return queueItem;
        }
    }
}