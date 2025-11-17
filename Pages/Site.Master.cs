using System;
using System.Web;


namespace Datwise_Tech_Lead_Home_Assignment.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string page = System.IO.Path.GetFileName(Request.Path).ToLower();

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                mainNav.Visible = false;
            }

            // דפים שלא צריכים Login
            bool isPublicPage = page == "login.aspx" || page == "register.aspx";

            if (!isPublicPage && !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }
    }
}