/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MessageManager.Web.Controllers
{
    /// <summary>
    /// Session验证过期验证特性
    /// </summary>
    public class UserSessionCheck : System.Web.Mvc.ActionFilterAttribute
    {
        public UserSessionCheck()
        {
         
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase ctx = filterContext.HttpContext;
            if (ctx.Session["userName"] == null)
            {
                filterContext.Result = new EmptyResult();
                ctx.Response.Write("<script type='text/javascript'>if(window!= top) top.location.href ='/index/index';</script> ");

            }
            base.OnActionExecuting(filterContext);
        }
    }
}