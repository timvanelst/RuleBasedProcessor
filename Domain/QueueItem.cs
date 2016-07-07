using System;

namespace Domain
{
    public interface IHasTimeStamp
    {
        DateTime TimeStamp { get; set; }
    }

    public interface IHasType
    {
        string Type { get; }
    }

    public class QueueItem : IHasTimeStamp
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime? ProcessingFailedAt { get; set; }
        public string ReferenceId { get; set; }
    }

    public class QueueItemWithType : QueueItem, IHasType
    {
        public string Type { get; set; }
    }
}