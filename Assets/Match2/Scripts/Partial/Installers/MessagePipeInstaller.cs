using Match2.Partial.Messages;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Match2.Partial.Installers
{
    public class MessagePipeInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            // RegisterMessagePipe returns options.
            var options = builder.RegisterMessagePipe(/* configure option */);
        
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            // RegisterMessageBroker: Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
            builder.RegisterMessageBroker<int>(options);

            builder.RegisterMessageBroker<SelectLevelFrameMessage>(options);
            builder.RegisterMessageBroker<OnCellClickedMessage>(options);
            builder.RegisterMessageBroker<OnMatchFoundMessage>(options);
        }
    }
}
