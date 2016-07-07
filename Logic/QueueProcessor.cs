using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public interface IQueueProcessor
    {
        void Process();
    }

    public class QueueProcessor : IQueueProcessor
    {
        private readonly IQueueManager queueManager;
        private readonly IQueueItemProcessor queueItemProcessor;
        private readonly ILogger logger;

        public QueueProcessor(IQueueManager queueManager, IQueueItemProcessor queueItemProcessor, ILogger logger)
        {
            this.queueManager = queueManager;
            this.queueItemProcessor = queueItemProcessor;
            this.logger = logger;
        }

        public void Process()
        {
            ProcessItems(queueManager.GetItemsIds());
        }

        private void ProcessItems(IList<int> queueItemIds)
        {
            try
            {
                while (queueItemIds.Any())
                {
                    var nextItem = queueManager.GetItem(queueItemIds.First());
                    if (nextItem != null)
                    {
                        try
                        {
                            queueItemProcessor.Process(nextItem);
                            queueManager.DeQueue(nextItem);
                            queueManager.SaveChanges();
                        }
                        catch (BusinessException businessException)
                        {
                            queueManager.HandleProcessError(nextItem, businessException.TranslatedMessages);
                        }
                    }
                    queueItemIds.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}