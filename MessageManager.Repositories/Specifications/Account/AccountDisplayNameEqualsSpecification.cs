/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Domain.Entity;
using System;

namespace MessageManager.Domain.Repositories.Specifications
{
    internal class AccountDisplayNameEqualsSpecification : AccountStringEqualsSpecification
    {
        public AccountDisplayNameEqualsSpecification(string name)
            : base(name)
        {
        }

        public override System.Linq.Expressions.Expression<Func<Account, bool>> GetExpression()
        {
            return c => c.DisplayName == value;
        }
    }
}
