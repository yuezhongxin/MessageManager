/**
* author:xishaui
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Domain.DomainModel
{
    public class Message : IAggregateRoot
    {
        #region 构造方法
        public Message()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        #endregion
        
        #region 实体成员
        public string FromUserID { get; set; }
        public string FromUserName { get; set; }
        public string ToUserID { get; set; }
        public string ToUserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsRead { get; set; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
        #endregion

        #region IEntity成员
        /// <summary>
        /// 获取或设置当前实体对象的全局唯一标识。
        /// </summary>
        public string ID { get; set; }
        #endregion
    }
}
