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
        private readonly IAccountService accountServiceImpl = ServiceLocator.Instance.GetService<IAccountService>();
        #endregion

        #region 消息操作
        // <summary>
        /// 撰写消息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Compose()
        {
            AccountDTO sendAccount = accountServiceImpl.GetAccountByLoginName(User.Identity.Name);
            return View(sendAccount);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public JsonResult SendMessage(string incept, string title, string content)
        {
            OperationResponse sendResult = messageServiceImpl.SendMessage(title, content, User.Identity.Name, incept);
            if (sendResult.IsSuccess)
            {
                return Json(new { result = "success", content = sendResult.Message });
            }
            else
            {
                return Json(new { result = "error", content = sendResult.Message });
            }
        }
        #endregion
    }
}
