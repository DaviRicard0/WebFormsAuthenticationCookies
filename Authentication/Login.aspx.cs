using FormsAuthentications.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormsAuthentications.Autenticacao
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CookieAuthentication.GetCookie(Request) != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (CookieAuthentication.SetCookie(
                Response,
                Guid.NewGuid().ToString(),
                new SessionModel { Id = 1, Email = Email.Text, Roles = new List<string> { "R1", "R2", "R3" } },
                true
            ))
            {
                Response.Redirect("~/Default.aspx");
            };
        }
    }
}