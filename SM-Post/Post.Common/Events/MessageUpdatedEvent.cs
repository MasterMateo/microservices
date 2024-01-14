using CQRS.Core.Events;
using MongoDB.Driver.Core.Operations;

namespace Post.Common.Events
{
    public class MessageUpdatedEvent : BaseEvent 
    {
        public MessageUpdatedEvent() : base(nameof(MessageUpdatedEvent))
        {
        }

        public string Message { get; set; }
    }
}
