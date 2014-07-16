/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;
using MessageManager.Repositories.EntityFramework;
using System.Collections.Generic;

namespace MessageManager.Repositories
{
    public class MessageRepository : EntityFrameworkRepository<Message>, IMessageRepository
    {
        public MessageRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IMessageRepository Members
        public ICollection<Message> GetUnreadMessageList(Contact reader)
        {
            throw new System.NotImplementedException();
        }

        public int GetUnreadMessageCount(Contact reader)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Message> GetInbox(Contact reader)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Message> GetOutbox(Contact reader)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
