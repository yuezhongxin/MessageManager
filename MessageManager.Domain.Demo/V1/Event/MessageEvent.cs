using System;

namespace MessageManager.Domain.Demo.V1.Event
{
    public class MessageEvent : IDomainEvent
	{
		public Message DoMessage { get; set; }
	}
}
