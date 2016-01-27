using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Web.MasterPage;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.OrdenesDeTrabajo
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
            e.Values["Id_Solicitante"] = SessionManager.Id_Miembro;
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
            e.NewValues["Id_Solicitante"] = SessionManager.Id_Miembro;
        }
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            if (frmPpal.CurrentMode == FormViewMode.Insert)
            {
                FormView objForma = (FormView)sender;
                ((Label)objForma.FindControl("lblSolicitante")).Text = new MiembroFachada().Seleccionar_Id(SessionManager.Id_Miembro.Value).NombreCompleto;
            }
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Ordenesdetrabajo, 1);
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
        protected void frmOrdenesDeTrabajo_Detalles_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_OrdenDeTrabajo"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            e.Values["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }
        protected void frmOrdenesDeTrabajo_Detalles_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 2;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 1;
        }
        protected void frmOrdenesDeTrabajo_Detalles_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 2;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 1;
        }
        protected void gvOrdenesDeTrabajo_Detalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmOrdenesDeTrabajo_Detalles")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource5")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvOrdenesDeTrabajo_Detalles")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmOrdenesDeTrabajo_Detalles")).DataBind();
        }
        protected void gvOrdenesDeTrabajo_Detalles_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_OrdenesDeTrabajo_Recursos_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvOrdenesDeTrabajo_Detalles")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.OrdenesDeTrabajo_Recursos objPedidoContacto = new SIGED_3.CRM.Model.Negocio.Entidades.OrdenesDeTrabajo_Recursos();
                    objPedidoContacto.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new OrdenesDeTrabajo_RecursosFachada().Eliminar(objPedidoContacto);
                }
            }
            ((GridView)frmPpal.FindControl("gvOrdenesDeTrabajo_Detalles")).DataBind();
            ((FormView)frmPpal.FindControl("frmOrdenesDeTrabajo_Detalles")).ChangeMode(FormViewMode.Insert);
        }
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }
        protected void cboColores_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Remove("style");
                if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.LC_FichasTecnicasColoresResult"))
                {
                    if (((SIGED_3.CRM.Model.Negocio.Entidades.LC_FichasTecnicasColoresResult)e.Item.DataItem).Color == "")
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                    }
                    else
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.LC_FichasTecnicasColoresResult)e.Item.DataItem).Color + ";");
                    }
                }
                else if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_MezcladosResult"))
                {
                    if (((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_MezcladosResult)e.Item.DataItem).Color == "")
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                    }
                    else
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_MezcladosResult)e.Item.DataItem).Color + ";");
                    }
                }
            }
        }
        protected void frmOrdenesDeTrabajo_Detalles_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos = (SIGED_3.CRM.Model.Negocio.Entidades.OrdenesDeTrabajo_Recursos)((FormView)sender).DataItem;
                if (objOrdenesDeTrabajo_Recursos.Id_Recurso.HasValue)
                {
                    ((RadComboBox)((FormView)sender).FindControl("cboRecursos")).SelectedValue = objOrdenesDeTrabajo_Recursos.Id_Recurso.ToString();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).DataBind();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue = objOrdenesDeTrabajo_Recursos.Id_UnidadDeMedida.ToString();
                }
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton5", "ImageButton5", (int)Modulo_Enum.Ordenesdetrabajo, 2);
        }
        protected void frmOrdenesDeTrabajo_Detalles_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }
        protected void btnAñadirDetallesAPedidos_Click(object sender, ImageClickEventArgs e)
        {
            long IdPedido = long.Parse(((RadComboBox)frmPpal.FindControl("cboPedidos")).SelectedValue);
            long IdOrdenDeTrabajo = long.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            new OrdenesDeTrabajoFachada().IncluirAOrdenPedidosDetalles(IdPedido, IdOrdenDeTrabajo);
            ((RadComboBox)frmPpal.FindControl("cboPedidos")).DataBind();
            ((GridView)frmPpal.FindControl("gvOrdenesDeTrabajo_Detalles")).DataBind();
        }
    }
}