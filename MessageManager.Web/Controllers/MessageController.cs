/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application;
using MessageManager.Infrastructure;
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
        /// 撰写消息
        /// </summary>
        /// <returns></returns>
        //[UserSessionCheck]
        public ActionResult Compose()
        {
            HttpCookie userCookie = new HttpCookie("LoginUserNameKey", "xiaocai");
            Response.Cookies.Add(userCookie);
            ViewBag.DisplayUserName = "小菜";
            ViewBag.ReceiveDisplayUserName = "大神";
            return View();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        //[UserSessionCheck]
        [HttpPost]
        public JsonResult SendMessage(string incept, string title, string content)
        {
            if (messageServiceImpl.SendMessage(title, content, Request.Cookies["LoginUserNameKey"].Value, incept))
            {
                return Json(new { result = "success", content = "发送成功！" });
            }
            else
            {
                return Json(new { result = "error", content = "发送失败！" });
            }
        }
        #endregion
    }
}
