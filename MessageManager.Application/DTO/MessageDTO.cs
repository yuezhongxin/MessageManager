/**
* author:xishaui
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageManager.Application.DTO
{
    public class MessageDTO
    {
        #region DTO成员
        public string ID { get; set; }
        public string FromUserID { get; set; }
        public string FromUserName { get; set; }
        public string ToUserID { get; set; }
        public string ToUserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReceiveTime { get; set; }
        public bool IsRead { get; set; }
        #endregion
    }
}
