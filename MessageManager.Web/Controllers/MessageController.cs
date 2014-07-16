/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Infrastructure;
using MessageManager.Web.MessageService;
using System.Web.Mvc;

namespace MessageManager.Web.Controllers
{
    public class MessageController : Controller
    {
        #region 消息操作
        [Authorize]
        public ActionResult Compose()
        {
            //ContactDTO sender = new ContactDTO() { LoginName = "xiaocai", DisplayName = "小菜" };//accountServiceImpl.GetAccountByLoginName(User.Identity.Name);
            return View();
        }
        [Authorize]
        [HttpPost]
        public JsonResult SendMessage(string incept, string title, string content)
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                OperationResponse sendResult = messageServiceClient.SendMessage(title, content.Replace("\n", "<br />"), User.Identity.Name, incept);
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
        [Authorize]
        public ActionResult Outbox()
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                return View(messageServiceClient.ReadOutbox(User.Identity.Name).Data);
            }
        }
        [Authorize]
        public ActionResult Inbox()
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                return View(messageServiceClient.ReadInbox(User.Identity.Name).Data);
            }
        }
        [Authorize]
        public ActionResult Sender(string id)
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                return View("show", messageServiceClient.ReadMessageSender(id, User.Identity.Name).Data);
            }
        }
        [Authorize]
        public ActionResult Recipient(string id)
        {
            using (MessageServiceClient messageServiceClient = new MessageServiceClient())
            {
                return View("show", messageServiceClient.ReadMessageRecipient(id, User.Identity.Name).Data);
            }
        }
        #endregion
    }
}
