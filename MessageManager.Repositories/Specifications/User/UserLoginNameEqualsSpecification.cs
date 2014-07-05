/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using System;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal class UserLoginNameEqualsSpecification : UserStringEqualsSpecification
    {
        public UserLoginNameEqualsSpecification(string name)
            : base(name)
        {
        }

        public override System.Linq.Expressions.Expression<Func<User, bool>> GetExpression()
        {
            return c => c.LoginName == value;
        }
    }
}
