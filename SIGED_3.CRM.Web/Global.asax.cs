using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Error;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        protected void Session_Start(object sender, EventArgs e)
        {
           
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-CO");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-CO");
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exep = Server.GetLastError();
            if (exep != null)
            {
                ExceptionUtility.LogException(Server.GetLastError(), Server.GetLastError().GetType().ToString());
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}