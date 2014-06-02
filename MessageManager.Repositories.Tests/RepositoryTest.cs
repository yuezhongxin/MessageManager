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
            IUserRepository URepository = new UserRepository(new EntityFrameworkRepositoryContext());
            User user = new User();
            //user.Name = "张三";
            user.Name = "李四";
            URepository.Add(user);
            URepository.Context.Commit();
            //var user = URepository.GetUserByName("张三");
            //if (user != null)
            //{
            //    Console.WriteLine(user.Name);
            //}
        }
    }
}
