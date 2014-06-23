/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Specifications;

namespace MessageManager.Domain.Repositories.Specifications
{
    public class MessageToUserIDEqualsSpecification : Specification<Message>
    {
        private readonly User user;

        public MessageToUserIDEqualsSpecification(User user)
        {
            this.user = user;
        }

        public override System.Linq.Expressions.Expression<Func<Message, bool>> GetExpression()
        {
            return p => p.ToUserID == user.ID;
        }
    }
}
