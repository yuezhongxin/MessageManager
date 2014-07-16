/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/


using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using MessageManager.Web.MessageService;
using System.Web.Mvc;

namespace MessageManager.Web.Controllers
{
    public class MessageController : Controller
    {
        #region 消息操作
        // <summary>
        /// 撰写消息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Compose()
        {
            ContactDTO sender = new ContactDTO() { LoginName = "xiaocai", DisplayName = "小菜" };//accountServiceImpl.GetAccountByLoginName(User.Identity.Name);
            return View(sender);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public JsonResult SendMessage(string incept, string title, string content)
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                OperationResponse sendResult = messageServiceClient.SendMessage(title, content, User.Identity.Name, incept);
                if (sendResult.IsSuccess)
                {
                    return Json(new { result = "success", content = sendResult.Message });
                }
                else
                {
                    return Json(new { result = "error", content = sendResult.Message });
                }
            }
        }
        #endregion
    }
}
