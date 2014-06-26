using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace MessageManager.Domain.Demo.V1.Event
{
	public static class DomainEvents
	{
		[ThreadStatic] 
		private static List<Delegate> _actions;

		public static IUnityContainer Container { get; set; }

		public static void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (_actions == null)
				_actions = new List<Delegate>();

			_actions.Add(callback);
		}

		public static void ClearCallbacks()
		{
			_actions = null;
		}

		public static void Raise<T>(T args) where T : IDomainEvent
		{
			foreach (var handler in Container.ResolveAll<IHandle<T>>())
				handler.Handle(args);

			if (_actions != null)
				foreach (var action in _actions)
					if (action is Action<T>)
						((Action<T>)action)(args);
		}
	}
}