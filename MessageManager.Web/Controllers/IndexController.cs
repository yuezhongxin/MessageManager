/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System.Web.Mvc;

namespace MessageManager.Web.Controllers
{
    public class IndexController : Controller
    {
        //#region 应用层服务接口
        //private readonly IAccountService accountServiceImpl = ServiceLocator.Instance.GetService<IAccountService>();
        //#endregion

        //#region 用户操作
        ////
        //// GET: /Message/
        //public ActionResult Index()
        //{
        //    if (!accountServiceImpl.ExistAccount())
        //    {
        //        accountServiceImpl.AddAccount(new List<AccountDTO>(){
        //            new AccountDTO{ ID=Guid.NewGuid().ToString(), Name="小菜"},
        //            new AccountDTO{ ID=Guid.NewGuid().ToString(), Name="大神"}
        //        });
        //    }
        //    return View();
        //}
        ///// <summary>
        ///// 注册用户
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult RegisterAccount(string accountName)
        //{
        //    Session["accountName"] = accountName;
        //    return RedirectToAction("inbox", "message");
        //}
        //#endregion
    }
}
