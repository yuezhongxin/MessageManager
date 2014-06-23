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
using MessageManager.Domain.Repositories.Specifications;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal class UserNameEqualsSpecification : Specification<User>
    {
        private readonly User user;
        public UserNameEqualsSpecification(User user)
        {
            this.user = user;
        }

        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return c => c.Name == user.Name;
        }
    }
}
