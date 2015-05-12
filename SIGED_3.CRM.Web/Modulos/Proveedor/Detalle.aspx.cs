using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Util.Session;
using Telerik.Web.UI;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Web.MasterPage;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.Proveedor
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
            e.Values["Id_Provincia"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboProvincia")).SelectedValue);
            e.Values["Id_Ciudad"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboCiudad")).SelectedValue);
            e.Values["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_Provincia"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboProvincia")).SelectedValue);
            e.NewValues["Id_Ciudad"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboCiudad")).SelectedValue);
            e.NewValues["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
        }
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            if (frmPpal.CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.Proveedor objProveedor = (SIGED_3.CRM.Model.Negocio.Entidades.Proveedor)frmPpal.DataItem;
                if (objProveedor.Id_Provincia != null)
                {
                    ((RadComboBox)frmPpal.FindControl("cboProvincia")).SelectedValue = objProveedor.Id_Provincia.ToString();
                    ((RadComboBox)frmPpal.FindControl("cboCiudad")).DataBind();
                    ((RadComboBox)frmPpal.FindControl("cboCiudad")).SelectedValue = objProveedor.Id_Ciudad.ToString();
                }
            }
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Proveedores, 1);
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

            ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "closeWin('actualizado')", true);
        }
        protected void frmProveedor_Contacto_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_Proveedor"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmProveedor_Contacto_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).DataBind();
            ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).SelectedIndex = -1;
        }
        protected void frmProveedor_Contacto_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmProveedor_Contacto")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).DataBind();
            ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).SelectedIndex = -1;
        }
        protected void gvProveedor_Contactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmProveedor_Contacto")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource5")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmProveedor_Contacto")).DataBind();
        }
        protected void gvProveedor_Contactos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if ((bool)((Proveedor_Contacto)e.Row.DataItem).Estado)
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
            }
        }
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Proveedor_Contacto objProveedorContacto = new SIGED_3.CRM.Model.Negocio.Entidades.Proveedor_Contacto();
                    objProveedorContacto.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new Proveedor_ContactoFachada().Eliminar(objProveedorContacto);
                }
            }
            ((GridView)frmPpal.FindControl("gvProveedor_Contactos")).DataBind();
            ((FormView)frmPpal.FindControl("frmProveedor_Contacto")).ChangeMode(FormViewMode.Insert);
        }
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }

        protected void frmProveedor_Contacto_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton5", "ImageButton5", (int)Modulo_Enum.Proveedores, 2);
        }
    }
}