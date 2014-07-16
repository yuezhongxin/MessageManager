using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MessageManager.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public void LogOn()
        {
            FormsAuthentication.SetAuthCookie("xiaocai", false);
            Response.Cookies.Add(new HttpCookie("DisplayName", HttpUtility.UrlEncode("小菜")));


            //HttpCookie cookie = FormsAuthentication.GetAuthCookie("xiaocai2", false);
            //FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            //FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(1,
            //    oldTicket.Name,
            //    oldTicket.IssueDate,
            //    DateTime.Now.AddMinutes(2880),
            //    oldTicket.IsPersistent,
            //    oldTicket.UserData,
            //    FormsAuthentication.FormsCookiePath);
            //cookie.Value = FormsAuthentication.Encrypt(newTicket);
            //Response.Cookies.Add(cookie);

            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
            //    "xiaocai",
            //    DateTime.Now,
            //    DateTime.Now.AddMinutes(2880),
            //    false,
            //    "ApplicationSpecific data for this user.",
            //    FormsAuthentication.FormsCookiePath);

            //// Encrypt the ticket.
            //string encTicket = FormsAuthentication.Encrypt(ticket);

            //// Create the cookie.
            //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            //FormsAuthentication.RedirectFromLoginPage(User.Identity.Name, false);
            Response.Redirect("~/Message/Compose", false);
        }
    }
}
