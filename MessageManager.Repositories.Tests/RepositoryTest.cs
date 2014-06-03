/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MessageManager.Repositories.Tests
{
    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void UserRepository()
        {
            IUserRepository userRepository = new UserRepository(new EntityFrameworkRepositoryContext());
            User user1 = new User { Name = "小菜" };
            User user2 = new User { Name = "大神" };
            userRepository.Add(user1);
            userRepository.Add(user2);
            userRepository.Context.Commit();
            //var user = URepository.GetUserByName("张三");
            //if (user != null)
            //{
            //    Console.WriteLine(user.Name);
            //}
        }
    }
}
