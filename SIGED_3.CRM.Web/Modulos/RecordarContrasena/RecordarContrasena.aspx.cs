using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
namespace SIGED_3.CRM.Web.Modulos.RecordarContrasena
{
    public partial class RecordarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(View1);
            }
        }
        protected void btnValidarCodigo_Click(object sender, ImageClickEventArgs e)
        {
            new CuentasFachada().RecordarContrasena(txtUsuario.Text.Trim());
            MultiView1.SetActiveView(View2);
            ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Su nueva contraseña ha sido enviada a su email.')", true);
        }
    }
}