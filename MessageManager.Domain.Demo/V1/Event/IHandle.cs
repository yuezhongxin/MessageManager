    using System;

namespace MessageManager.Domain.Demo.V1.Event
{
	public interface IHandle<T>
	{
		void Handle(T args);
	}
}