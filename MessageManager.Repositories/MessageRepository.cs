/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories.Specifications;
using MessageManager.Domain.Specifications;
using MessageManager.Repositories.EntityFramework;
using MessageManager.Domain.Repositories;

namespace MessageManager.Repositories
{
    public class MessageRepository : EntityFrameworkRepository<Message>, IMessageRepository
    {
        public MessageRepository(IRepositoryContext context)
            : base(context)
        { }

        #region IMessageRepository Members
        public IEnumerable<Message> GetMessagesBySendUser(User user)
        {
            return FindAll(new MessageFromUserIDEqualsSpecification(user), sp => sp.SendTime, SortOrder.Descending);
        }
        public IEnumerable<Message> GetMessagesByReceiveUser(User user)
        {
            return FindAll(new MessageFromUserIDEqualsSpecification(user), sp => sp.ReceiveTime, SortOrder.Descending);
        }
        #endregion
    }
}
