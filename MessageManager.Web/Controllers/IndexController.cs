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
    public class IndexController : Controller
    {
        #region 应用层服务接口
        private readonly IUserService userServiceImpl = ServiceLocator.Instance.GetService<IUserService>();
        #endregion

        #region 用户操作
        //
        // GET: /Message/
        public ActionResult Index()
        {
            if (!userServiceImpl.ExistUser())
            {
                userServiceImpl.AddUser(new List<UserDTO>(){
                    new UserDTO{ ID=Guid.NewGuid().ToString(), Name="小菜"},
                    new UserDTO{ ID=Guid.NewGuid().ToString(), Name="大神"}
                });
            }
            return View();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterUser(string userName)
        {
            Session["userName"] = userName;
            return RedirectToAction("inbox", "message");
        }
        #endregion
    }
}
