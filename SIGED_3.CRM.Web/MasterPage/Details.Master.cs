using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;
using System.Web.UI.HtmlControls;
namespace SIGED_3.CRM.Web.MasterPage
{
    public partial class Details : System.Web.UI.MasterPage
    {
        public UpdatePanel Expose_upDetalle
        {
            get
            {
                return this.upDetalle;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                CargarImagenGrupo();
            }
        }
        public void CargarImagenGrupo()
        {
            GrupoDeMiembros objGrupo = new GrupoDeMiembrosFachada().Seleccionar_Id(SessionManager.Id_GrupoDeMiembros.Value);
            rbiImagenGrupo.DataValue = objGrupo.Id_Imagen.HasValue ? objGrupo.ImagenGrupo : null;
        }
    }
}