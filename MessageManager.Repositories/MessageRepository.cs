/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Repositories.EntityFramework;
using System;
using System.Collections.Generic;

namespace MessageManager.Repositories
{
    public class MessageRepository : EntityFrameworkRepository<Message>, IMessageRepository
    {
        public MessageRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IMessageRepository Members
        public int GetMessageCount(User senduser, DateTime sendTime)
        {
            return 3;
        }

        public ICollection<Message> GetOutbox(User readUser)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Message> GetInbox(User readUser)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
