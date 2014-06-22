using MessageManager.Domain.DomainModel;
using MessageManager.Domain.DomainService;
using MessageManager.Repositories;
using MessageManager.Repositories.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.Tests
{
    [TestFixture]
    public class DomainTest
    {
        [Test]
        public void UserDomainService()
        {
            IUserDomainService userDomainService = new UserDomainService(
                new UserRepository(new EntityFrameworkRepositoryContext()));
            List<User> users = new List<User>();
            users.Add(new User { Name = "小菜" });
            users.Add(new User { Name = "大神" });
            userDomainService.AddUser(users);
            //userDomainService.ExistUser();
            //var user = userDomainService.GetUserByName("小菜");
            //if (user != null)
            //{
            //    Console.WriteLine(user.Name);
            //}
        }
        [Test]
        public void DomainServiceTest()
        {
            IUserDomainService userDomainService = new UserDomainService(
                new UserRepository(new EntityFrameworkRepositoryContext()));
            IMessageDomainService messageDomainService = new MessageDomainService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            List<User> users = new List<User>();
            users.Add(new User { Name = "小菜" });
            users.Add(new User { Name = "大神" });
            userDomainService.AddUser(users);
            messageDomainService.DeleteMessage(null);
        }
        [Test]
        public void MessageServiceTest()
        {
            IMessageDomainService messageDomainService = new MessageDomainService(
                new MessageRepository(new EntityFrameworkRepositoryContext()),
                new UserRepository(new EntityFrameworkRepositoryContext()));
            Message message = messageDomainService.ShowMessage("ID", new User { Name = "小菜" });
            Console.WriteLine(message.IsRead);
        }
    }
}
