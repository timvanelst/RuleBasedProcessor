using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;

namespace Logic
{
    public interface IQueueItemProcessor
    {
        void Process(QueueItem queueItem);
    }

    public class QueueItemProcessor : IQueueItemProcessor
    {
        private readonly IItemConverter itemConverter;
        private readonly IItemManager itemManager;

        public QueueItemProcessor(IItemConverter itemConverter, IItemManager itemManager)
        {
            this.itemConverter = itemConverter;
            this.itemManager = itemManager;
        }

        public void Process(QueueItem queueItem)
        {
            var item = itemConverter.Create(queueItem);
            itemManager.InsertAndSave(item);
        }
    }
}
