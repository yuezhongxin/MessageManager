using MessageManager.Domain.Demo.V1;
using MessageManager.Domain.Demo.V1.Event;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Demo.Tests
{
    [TestFixture]
    public class DomainTest
    {
        [Test]
        public void MessageTest()
        {
            IUnityContainer _container;

            _container = new UnityContainer()
                        .RegisterType<IDomainEvent, MessageEvent>()
                        .RegisterType<IHandle<Message>, MessageEventHandler>("MessageEventHandler");

            DomainEvents.Container = _container;
            User testSendUser = new User { Name = "小菜" };
            User testReceiveUser = new User { Name = "小菜" };
            Message message = new Message { Title = "test", Content = "test", ToUser = testSendUser };
            testSendUser.SendMessage(message);
        }
    }
}
