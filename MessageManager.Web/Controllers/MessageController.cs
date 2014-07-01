/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application;
using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
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
            Session["CurrentUser"] = new UserDTO
            {
                ID = "dac488d3-d7f0-4bd8-9dcb-db7d195e94d1",
                Name = "小菜"
            };
            ViewBag.UserName = (Session["CurrentUser"] as UserDTO).Name;
            ViewBag.ToUserName = (Session["CurrentUser"] as UserDTO).Name.Equals("小菜") ? "大神" : "小菜";
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
            UserDTO sendUserDTO = Session["CurrentUser"] as UserDTO;
            if (messageServiceImpl.SendMessage(title, content, sendUserDTO, incept))
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
