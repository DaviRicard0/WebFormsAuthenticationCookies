using FormsAuthentications.Models;
using System;
using System.Web.UI;

namespace FormsAuthentications
{
    public partial class Contact : Page
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