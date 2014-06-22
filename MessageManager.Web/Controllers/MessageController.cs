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
        /// 发件箱
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        public ActionResult Outbox()
        {
            ViewBag.UserName = Session["userName"].ToString();
            List<MessageDTO> messages = messageServiceImpl.GetMessagesBySendUser(new UserDTO { Name = Session["userName"].ToString() }).ToList();
            return View(messages);
        }
        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        public ActionResult Inbox()
        {
            ViewBag.UserName = Session["userName"].ToString();
            List<MessageDTO> messages = messageServiceImpl.GetMessagesByReceiveUser(new UserDTO { Name = Session["userName"].ToString() }).ToList();
            return View(messages);
        }
        /// <summary>
        /// 撰写消息
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        public ActionResult Compose()
        {
            ViewBag.UserName = Session["userName"].ToString();
            ViewBag.ToUserName = Session["userName"].ToString().Equals("小菜") ? "大神" : "小菜";
            return View();
        }
        /// <summary>
        /// 查看消息
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        public ActionResult Show(string ID)
        {
            ViewBag.UserName = Session["userName"].ToString();
            ViewBag.ToUserName = Session["userName"].ToString().Equals("小菜") ? "大神" : "小菜";
            MessageDTO messages = messageServiceImpl.ShowMessage(ID, new UserDTO { Name = Session["userName"].ToString() });
            return View(messages);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        [UserSessionCheck]
        [HttpPost]
        public JsonResult SendMessage(string incept, string title, string content)
        {
            MessageDTO message = new MessageDTO();
            message.ID = Guid.NewGuid().ToString();
            message.Title = title;
            message.Content = content.Replace("\n", "<br />");
            message.SendTime = DateTime.Now;
            message.FromUserName = Session["userName"].ToString();
            message.ToUserName = incept;
            message.IsRead = false;
            if (messageServiceImpl.SendMessage(message))
            {
                return Json(new { result = "success", content = "发送成功！" });
            }
            else
            {
                return Json(new { result = "error", content = "发送失败！" });
            }
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [UserSessionCheck]
        [HttpPost]
        public JsonResult DeleteMessage(string ID)
        {
            if (messageServiceImpl.DeleteMessage(new MessageDTO { ID = ID }))
            {
                return Json(new { result = "success", content = "删除成功！" });
            }
            else
            {
                return Json(new { result = "error", content = "删除失败！" }); 
            }
        }
        #endregion
    }
}
