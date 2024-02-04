using Post.Common.Events;

namespace Post.Query.Infrasructure.Handlers
{
    public interface IEventHandler
    {
        Task On(PostCreatedEvent @event);
        Task On(MessageUpdatedEvent @event);
        Task On(PostLikedEvent @event);
        Task On(CommentAddedEvent @event);
        Task On(CommentUpdatedEvent @event);
        Task On(CommentRemoveEvent @event);
        Task On(PostRemovedEvent @event);

    }
}
