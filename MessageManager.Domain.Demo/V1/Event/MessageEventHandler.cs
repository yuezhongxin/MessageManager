using System;

namespace MessageManager.Domain.Demo.V1.Event
{
    public class MessageEventHandler : IHandle<Message>
	{
		public void Handle(Message args)
		{
			Console.WriteLine("send email for message");
		}
    }
}