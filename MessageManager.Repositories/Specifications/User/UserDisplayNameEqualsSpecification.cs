/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.DomainModel;
using System;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal class UserDisplayNameEqualsSpecification : UserStringEqualsSpecification
    {
        public UserDisplayNameEqualsSpecification(string name)
            : base(name)
        {
        }

        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return c => c.DisplayName == value;
        }
    }
}
