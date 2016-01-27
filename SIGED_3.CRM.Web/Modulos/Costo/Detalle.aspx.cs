using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Web.MasterPage;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.Costo
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
                    ((ImageButton)frmPpal.FindControl("btnNuevoProceso")).OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/ProcesoDeFabricacion/Detalle.aspx") + "');return false;";
                    new Genericos().ConfigurarPermisosLista(((ImageButton)frmPpal.FindControl("btnNuevoProceso")), null, null, null, (int)Modulo_Enum.Procesos);
                    ((ImageButton)frmPpal.FindControl("btnNuevoRecurso")).OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/ProcesoDeFabricacion/Detalle.aspx") + "');return false;";
                    new Genericos().ConfigurarPermisosLista(((ImageButton)frmPpal.FindControl("btnNuevoRecurso")), null, null, null, (int)Modulo_Enum.Recursos);
                    
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
            decimal? Valor = 0m;
            e.Values["CostoDeRecursos"] = Valor;
            e.Values["CostoDeProcesos"] = Valor;
            e.Values["CostoDeProduccion"] = Valor;
            e.Values["CostoConValirizacion"] = Valor;
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
        }
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Costos, 1);        
            
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
        protected void frmCosto_Recurso_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_Costo"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            e.Values["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }
        protected void frmCosto_Recurso_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 2;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 1;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void frmCosto_Recurso_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 2;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 1;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void gvCosto_Recursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmCosto_Recurso")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource5")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvCosto_Recursos")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmCosto_Recurso")).DataBind();
        }
        protected void gvCosto_Recursos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_Costo_Recurso_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvCosto_Recursos")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Costo_Recurso objCostoContacto = new SIGED_3.CRM.Model.Negocio.Entidades.Costo_Recurso();
                    objCostoContacto.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new Costo_RecursoFachada().Eliminar(objCostoContacto);
                }
            }
            ((GridView)frmPpal.FindControl("gvCosto_Recursos")).DataBind();
            ((FormView)frmPpal.FindControl("frmCosto_Recurso")).ChangeMode(FormViewMode.Insert);

            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 2;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 1;
        }
        protected void frmCosto_Proceso_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_Costo"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            e.Values["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }
        protected void frmCosto_Proceso_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 1;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 2;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void frmCosto_Proceso_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 1;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 2;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void gvCosto_Procesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmCosto_Proceso")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource11")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvCosto_Procesos")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmCosto_Proceso")).DataBind();
        }
        protected void gvCosto_Procesos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_Costo_Proceso_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvCosto_Procesos")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Costo_ProcesoDeFabricacion objCostoContacto = new SIGED_3.CRM.Model.Negocio.Entidades.Costo_ProcesoDeFabricacion();
                    objCostoContacto.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new Costo_ProcesoDeFabricacionFachada().Eliminar(objCostoContacto);
                }
            }
            ((GridView)frmPpal.FindControl("gvCosto_Procesos")).DataBind();
            ((FormView)frmPpal.FindControl("frmCosto_Proceso")).ChangeMode(FormViewMode.Insert);

            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 1;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 2;
        }
        protected void frmCosto_Margen_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_Costo"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmCosto_Margen_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 3;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 3;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void frmCosto_Margen_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 3;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 3;
            //ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "RecargarSinMensaje()", true);
        }
        protected void gvCosto_Margenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmCosto_Margen")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource17")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvCosto_Margenes")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmCosto_Margen")).DataBind();
        }
        protected void gvCosto_Margens_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_Costo_Margen_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvCosto_Margenes")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Costo_Valorizacion objCostoContacto = new SIGED_3.CRM.Model.Negocio.Entidades.Costo_Valorizacion();
                    objCostoContacto.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new Costo_ValorizacionFachada().Eliminar(objCostoContacto);
                }
            }
            ((GridView)frmPpal.FindControl("gvCosto_Margenes")).DataBind();
            ((FormView)frmPpal.FindControl("frmCosto_Margen")).ChangeMode(FormViewMode.Insert);

            ObjectDataSource1.SelectParameters["Id"].DefaultValue = this.Id.ToString();
            frmPpal.DataBind();
            ((RadTabStrip)frmPpal.FindControl("RadTabStrip1")).SelectedIndex = 3;
            ((RadMultiPage)frmPpal.FindControl("rmpEditar")).SelectedIndex = 3;
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
        protected void frmCosto_Recurso_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.Costo_Recurso objCosto_Recurso = (SIGED_3.CRM.Model.Negocio.Entidades.Costo_Recurso)((FormView)sender).DataItem;
                if (objCosto_Recurso.Id_Recurso.HasValue)
                {
                    ((RadComboBox)((FormView)sender).FindControl("cboRecursos")).SelectedValue = objCosto_Recurso.Id_Recurso.ToString();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).DataBind();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue = objCosto_Recurso.Id_UnidadDeMedida.ToString();
                }
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton5", "ImageButton5", (int)Modulo_Enum.Costos, 2);
        }
        protected void frmCosto_Proceso_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.Costo_ProcesoDeFabricacion objCosto_Costo_ProcesoDeFabricacion = (SIGED_3.CRM.Model.Negocio.Entidades.Costo_ProcesoDeFabricacion)((FormView)sender).DataItem;
                if (objCosto_Costo_ProcesoDeFabricacion.Id_Proceso.HasValue)
                {
                    ((RadComboBox)((FormView)sender).FindControl("cboProcesos")).SelectedValue = objCosto_Costo_ProcesoDeFabricacion.Id_Proceso.ToString();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).DataBind();
                    ((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue = objCosto_Costo_ProcesoDeFabricacion.Id_UnidadDeMedida.ToString();
                }
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton8", "ImageButton8", (int)Modulo_Enum.Costos, 2);
        }
        protected void frmCosto_Proceso_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }
        protected void frmCosto_Recurso_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_UnidadDeMedida"] = (Int64?)Int64.Parse(((RadComboBox)((FormView)sender).FindControl("cboUnidadDeMedida")).SelectedValue);
        }

        protected void frmCosto_Margen_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton15", "ImageButton15", (int)Modulo_Enum.Costos, 2);
        }
    }
}