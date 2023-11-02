using Newtonsoft.Json;
using System.Web.Security;
using System.Web;
using System;
using System.Net;

namespace FormsAuthentications.Models
{
    public class CookieAuthentication
    {
        internal static bool SetCookie(HttpResponse response,string username, SessionModel session, bool persistToken = false)
        {
            try
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,                                     // ticket version
                username,                              // authenticated username
                DateTime.Now,                          // issueDate
                DateTime.Now.AddMinutes(10),           // expiryDate
                persistToken,                          // true to persist across browser sessions
                JsonConvert.SerializeObject(session).ToString(),  // user data                            // can be used to store additional user data
                FormsAuthentication.FormsCookiePath);  // the path for the cookie

                // Encrypt the ticket using the machine key
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                // Add the cookie to the request to save it
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                {
                    //HttpOnly = true,
                    Expires = ticket.Expiration
                };
                response.Cookies.Add(cookie);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static FormsAuthenticationTicket GetCookie(HttpRequest request)
        {
            try
            {
                var value = request.Cookies[FormsAuthentication.FormsCookieName]?.Value;

                if (value is null)
                    return null;

                return FormsAuthentication.Decrypt(value);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static SessionModel GetCookieUserData(HttpRequest request)
        {
            try
            {
                var value = request.Cookies[FormsAuthentication.FormsCookieName]?.Value;

                if (value is null)
                    return null;

                return JsonConvert.DeserializeObject<SessionModel>(FormsAuthentication.Decrypt(value).UserData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static bool DeleteCookie(HttpResponse response)
        {
            try
            {
                response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}