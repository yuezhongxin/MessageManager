/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application;
using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageManager.Web.Controllers
{
    public class MessageController : Controller
    {
        #region 应用层服务接口
        private readonly IMessageService messageServiceImpl = ServiceLocator.Instance.GetService<IMessageService>();
        #endregion

        #region 消息操作
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        public ActionResult Inbox()
        {
            ViewBag.UserName = Session["userName"].ToString();
            List<MessageDTO> messages = messageServiceImpl.GetMessagesBySendUser(new UserDTO { Name = Session["userName"].ToString() }).ToList();
            return View(messages);
        }
        #endregion
    }
}
