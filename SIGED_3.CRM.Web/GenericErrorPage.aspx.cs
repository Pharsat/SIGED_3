using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace SIGED_3.CRM.Web
{
    public partial class GenericErrorPage : System.Web.UI.Page
    {
        protected Exception ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                //// Get the last error from the server
                //Exception ex = Server.GetLastError();
                //// Create a safe message
                //string safeMsg = "A problem has occurred in the web site. ";
                //// Show Inner Exception fields for local access
                //if (ex.InnerException != null)
                //{
                //    innerTrace.Text = ex.InnerException.StackTrace.Replace("\n\r", "<br />");
                //    InnerErrorPanel.Visible = Request.IsLocal;
                //    innerMessage.Text = ex.InnerException.Message.Replace("\n\r", "<br />");
                //}
                //// Show Trace for local access
                //if (Request.IsLocal)
                //    exTrace.Visible = true;
                //else
                //    ex = new Exception(safeMsg, ex);
                //// Fill the page fields
                //exMessage.Text = ex.Message.Replace("\n\r", "<br />");
                //exTrace.Text = ex.StackTrace.Replace("\n\r", "<br />");
                //// Clear the error from the server
                //Server.ClearError();
                if (Request["aspxerrorpath"] != null)
                {
                    if (Request["aspxerrorpath"].ToString().EndsWith("Detalle.aspx"))
                    {
                        HyperLink1.Visible = false;
                        Session.Abandon();
                    }
                }
            }
        }
        protected void btnVerError_Click(object sender, EventArgs e)
        {
            pnlDetallesError.Visible = !pnlDetallesError.Visible;
        }
    }
}