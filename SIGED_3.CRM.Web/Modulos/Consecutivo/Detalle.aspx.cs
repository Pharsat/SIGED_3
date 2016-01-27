using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Web.MasterPage;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.Consecutivo
{
    public partial class Detalle : System.Web.UI.Page
    {
        private long Id
        {
            get
            {
                if (ViewState["Id"] == null && Request["Id"] != null)
                {
                    ViewState["Id"] = Request["Id"].ToString();
                }
                if (ViewState["Id"] == null && Request["Id"] == null)
                {
                    ViewState["Id"] = 0;
                }
                return int.Parse(ViewState["Id"].ToString());
            }
            set
            {
                ViewState["Id"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Id != 0)
                {
                    frmPpal.ChangeMode(FormViewMode.Edit);
                }
                else
                {
                    frmPpal.ChangeMode(FormViewMode.Insert);
                }
            }
        }
        protected void frmPpal_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
        }
        protected void frmPpal_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            frmPpal.DefaultMode = FormViewMode.Edit;
            frmPpal.ChangeMode(FormViewMode.Edit);
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
        }
        protected void frmPpal_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            frmPpal.DefaultMode = FormViewMode.Edit;
            frmPpal.ChangeMode(FormViewMode.Edit);
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();

            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "closeWin('actualizado')", true);
        }
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            RecargarConfiguracion();
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Consecutivos, 1);
        }
        private void RecargarConfiguracion()
        {
            long?[] Configuracion = new long?[] { };
            if (frmPpal.DataItem != null)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.Consecutivos objConsecutivo = (SIGED_3.CRM.Model.Negocio.Entidades.Consecutivos)frmPpal.DataItem;
                Configuracion = new ConsecutivosFachada().Determinar_Configuracion(objConsecutivo.Id_Modulo.Value, SessionManager.Id_GrupoDeMiembros.Value);
            }
            else
            {
                Configuracion = new ConsecutivosFachada().Determinar_Configuracion(long.Parse(((RadComboBox)frmPpal.FindControl("cboModulos")).SelectedValue), SessionManager.Id_GrupoDeMiembros.Value);
            }
            ((RadNumericTextBox)frmPpal.FindControl("txtSerie")).MinValue = (double)Configuracion[0];
            ((RadNumericTextBox)frmPpal.FindControl("txtSerie")).DbValue = Configuracion[0];
            ((RadNumericTextBox)frmPpal.FindControl("txtPosicion")).MinValue = (double)Configuracion[2];
            ((RadNumericTextBox)frmPpal.FindControl("txtPosicion")).DbValue = Configuracion[2];
            ((RadNumericTextBox)frmPpal.FindControl("txtDesde")).MinValue = (double)Configuracion[1];
            ((RadNumericTextBox)frmPpal.FindControl("txtDesde")).DbValue = Configuracion[1];
            ((RadNumericTextBox)frmPpal.FindControl("txtHasta")).MinValue = (double)Configuracion[3];
            ((RadNumericTextBox)frmPpal.FindControl("txtHasta")).DbValue = Configuracion[3];
        }
        protected void cboModulos_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RecargarConfiguracion();
        }
    }
}