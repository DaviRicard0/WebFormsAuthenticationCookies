using FormsAuthentications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthentications
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            CookieAuthentication.DeleteCookie(Response);
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}