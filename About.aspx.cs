using FormsAuthentications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthentications
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CookieAuthentication.GetCookie(Request) is null)
            {
                Response.Redirect("~/Authentication/Login.aspx");
            }
        }
    }
}