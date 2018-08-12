using System;
using System.Threading.Tasks;
using MessagePack;
using Rebus.Handlers;

namespace template_identifier.PublicationMessage
{
    [MessagePackObject]
    public class PublicationMessageHandler : IHandleMessages<PublicationMessage>
    {
        public Task Handle(PublicationMessage message)
        {
            throw new NotImplementedException();
        }
    }
}