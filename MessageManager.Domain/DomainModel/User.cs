/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainModel
{
    public class User : IAggregateRoot
    {
        #region 构造方法
        public User()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        #endregion
        
        #region 实体成员
        public string Name { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }
        public virtual ICollection<Message> ReceiveMessages { get; set; }
        #endregion

        #region IEntity成员
        /// <summary>
        /// 获取或设置当前实体对象的全局唯一标识。
        /// </summary>
        public string ID { get; set; }
        #endregion
    }
}
