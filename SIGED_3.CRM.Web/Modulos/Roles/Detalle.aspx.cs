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

namespace SIGED_3.CRM.Web.Modulos.Roles
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
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Roles, 1);
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
        protected void frmRoles_Contacto_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_Rol"] = (Int32?)Int32.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            e.Values["Id_Modulo"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboModulos")).SelectedValue);
        }
        protected void frmRoles_Contacto_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvRoles_Contactos")).DataBind();
            ((GridView)frmPpal.FindControl("gvRoles_Contactos")).SelectedIndex = -1;
        }
        protected void frmRoles_Contacto_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmRoles_Contacto")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvRoles_Contactos")).DataBind();
            ((GridView)frmPpal.FindControl("gvRoles_Contactos")).SelectedIndex = -1;
        }
        protected void gvRoles_Contactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmRoles_Contacto")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource5")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvRoles_Contactos")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmRoles_Contacto")).DataBind();
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvRoles_Contactos")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Permisos objPermiso = new SIGED_3.CRM.Model.Negocio.Entidades.Permisos();
                    objPermiso.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new PermisosFachada().Eliminar(objPermiso);
                }
            }
            ((GridView)frmPpal.FindControl("gvRoles_Contactos")).DataBind();
            ((FormView)frmPpal.FindControl("frmRoles_Contacto")).ChangeMode(FormViewMode.Insert);
        }
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }

        protected void frmRoles_Contacto_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Insert)
            {
                ((HiddenField)((FormView)sender).FindControl("hdfId_Roles")).Value = ((HiddenField)frmPpal.FindControl("hdfId")).Value;
                ((RadComboBox)((FormView)sender).FindControl("cboModulos")).DataBind();
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton5", "ImageButton5", (int)Modulo_Enum.Roles, 2);
        }
    }
}