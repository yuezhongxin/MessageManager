/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using System;
using Xunit;

namespace MessageManager.Repositories.Tests
{
    public class ContactRepositoryTest
    {
        [Fact]
        public void RepositoryTest_GetContactByLoginName()
        {
            IContactRepository contactRepository = new ContactRepository();
            Contact contact = contactRepository.GetContactByLoginName("xiaocai");
            Console.WriteLine("Name:" + contact.Name);
            Console.WriteLine("LoginName:" + contact.LoginName);
            Console.WriteLine("DisplayName:" + contact.DisplayName);
        }
    }
}
