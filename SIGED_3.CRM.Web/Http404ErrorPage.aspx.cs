using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace SIGED_3.CRM.Web
{
    public partial class Http404ErrorPage : System.Web.UI.Page
    {
        protected HttpException ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
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
    }
}