using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Web.MasterPage;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using System.Web.UI.HtmlControls;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.FichaTecnica
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
            if (((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.Values["ImagenPrenda"] = Bytes;
                e.Values["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.Values["NombreImagen"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].GetName();
                e.Values["Extencion"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.Values["ImagenPrenda"] = null;
            }
            long? Num = null;
            e.Values["Id_Imagen"] = Num;
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_GrupoDeMiembros"] = SessionManager.Id_GrupoDeMiembros;
            if (((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.NewValues["ImagenPrenda"] = Bytes;
                e.NewValues["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.NewValues["NombreImagen"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].GetName();
                e.NewValues["Extencion"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenPrenda")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.NewValues["ImagenPrenda"] = null;
            }
            if (e.OldValues["Id_Imagen"].ToString() == String.Empty)
            {
                long? Num = null;
                e.NewValues["Id_Imagen"] = Num;
            }
        }
        protected void frmPpal_DataBound(object sender, EventArgs e)
        {
            if (frmPpal.CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica objFichaTecnica = (SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica)frmPpal.DataItem;
                ((RadBinaryImage)frmPpal.FindControl("rbiImagenPrenda")).DataValue = objFichaTecnica.ImagenPrenda;
                new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.FichaTecnica, 1);
            }
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
            ScriptManager.RegisterStartupScript((this.Master as Details_NoUpdatePanel), (this.Master as Details_NoUpdatePanel).GetType(), "CallMyFunction", "closeWin('actualizado')", true);
        }
        protected void frmFichaTecnica_Color_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmFichaTecnica_Color_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_Color_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Color")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).SelectedIndex = -1;
        }
        protected void gvFichaTecnica_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Color")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource5")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Color")).DataBind();
        }
        protected void gvFichaTecnica_Color_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Remove("style");
                if (((FichaTecnica_Color)e.Row.DataItem).Color1 == "")
                {
                    ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                }
                else
                {
                    ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((FichaTecnica_Color)e.Row.DataItem).Color1 + ";");
                }
            }
        }
        protected void btnEliminar_Color_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Color objFichaTecnicaColor = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Color();
                    objFichaTecnicaColor.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_ColorFachada().Eliminar(objFichaTecnicaColor);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Color")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Color")).ChangeMode(FormViewMode.Insert);
        }
        protected void frmFichaTecnica_Hilo_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmFichaTecnica_Hilo_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_Hilo_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Hilo")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).SelectedIndex = -1;
        }
        protected void gvFichaTecnica_Hilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Hilo")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource9")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Hilo")).DataBind();
        }
        protected void gvFichaTecnica_Hilo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_Hilo_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Hilo objFichaTecnicaHilo = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Hilo();
                    objFichaTecnicaHilo.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_HiloFachada().Eliminar(objFichaTecnicaHilo);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Hilo")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Hilo")).ChangeMode(FormViewMode.Insert);
        }
        protected void frmFichaTecnica_Marquilla_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            if (((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.Values["ImagenMarquilla"] = Bytes;
                e.Values["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.Values["NombreImagen"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].GetName();
                e.Values["Extencion"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.Values["ImagenMarquilla"] = null;
            }
            long? Num = null;
            e.Values["Id_Imagen"] = Num;
        }
        protected void frmFichaTecnica_Marquilla_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_Marquilla_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            if (((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.NewValues["ImagenMarquilla"] = Bytes;
                e.NewValues["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.NewValues["NombreImagen"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].GetName();
                e.NewValues["Extencion"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenMarquilla")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.NewValues["ImagenMarquilla"] = null;
            }
            if (e.OldValues["Id_Imagen"].ToString() == String.Empty)
            {
                long? Num = null;
                e.NewValues["Id_Imagen"] = Num;
            }
        }
        protected void frmFichaTecnica_Marquilla_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Marquilla")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).SelectedIndex = -1;
        }
        protected void gvFichaTecnica_Marquilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Marquilla")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource11")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Marquilla")).DataBind();
        }
        protected void gvFichaTecnica_Marquilla_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla objFichaTecnica_Marquilla = (SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla)e.Row.DataItem;
                ((RadBinaryImage)e.Row.FindControl("rbiImagenMarquilla")).DataValue = objFichaTecnica_Marquilla.ImagenMarquilla;
            }
        }
        protected void frmFichaTecnica_Marquilla_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla objFichaTecnica_Marquilla = (SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla)((FormView)sender).DataItem;
                ((RadBinaryImage)((FormView)sender).FindControl("rbiImagenMarquilla")).DataValue = objFichaTecnica_Marquilla.ImagenMarquilla;
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton15", "ImageButton15", (int)Modulo_Enum.FichaTecnica, 2);
        }
        protected void btnEliminar_Marquilla_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla objFichaTecnicaMarquilla = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla();
                    objFichaTecnicaMarquilla.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_MarquillaFachada().Eliminar(objFichaTecnicaMarquilla);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Marquilla")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Marquilla")).ChangeMode(FormViewMode.Insert);
        }
        protected void frmFichaTecnica_PasosDeConfeccion_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmFichaTecnica_PasosDeConfeccion_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_PasosDeConfeccion_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_PasosDeConfeccion")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).SelectedIndex = -1;
        }
        protected void gvFichaTecnica_PasosDeConfeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_PasosDeConfeccion")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource13")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_PasosDeConfeccion")).DataBind();
        }
        protected void frmFichaTecnica_PasosDeConfeccion_DataBound(object sender, EventArgs e)
        {
            FichaTecnica_PasosDeConfeccionFachada objFachada = new FichaTecnica_PasosDeConfeccionFachada();
            int NumeroMax = objFachada.Seleccionar_ProximoNumeracion(int.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value));
            ((RadNumericTextBox)((FormView)sender).FindControl("txtNumeracion")).Value = NumeroMax;
            ((RadNumericTextBox)((FormView)sender).FindControl("txtNumeracion")).MaxValue = NumeroMax;
            ((RadNumericTextBox)((FormView)sender).FindControl("txtNumeracion")).MinValue = 1;
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton18", "ImageButton18", (int)Modulo_Enum.FichaTecnica, 2);
        }
        protected void gvFichaTecnica_PasosDeConfeccion_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                //FichaTecnica_PasosDeConfeccion objPasos = (FichaTecnica_PasosDeConfeccion)e.Row.DataItem;
                //((Label)e.Row.FindControl("lblDescripcion")).Text = objPasos.Descripcion.Replace("\r\n", "<br />");
            }
        }
        protected void btnEliminar_PasosDeConfeccion_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_PasosDeConfeccion objFichaTecnicaPasosDeConfeccion = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_PasosDeConfeccion();
                    objFichaTecnicaPasosDeConfeccion.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_PasosDeConfeccionFachada().Eliminar(objFichaTecnicaPasosDeConfeccion);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_PasosDeConfeccion")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_PasosDeConfeccion")).ChangeMode(FormViewMode.Insert);
        }
        protected void frmFichaTecnica_ProcesosDetallados_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
            if (((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.Values["ImagenProceso"] = Bytes;
                e.Values["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.Values["NombreImagen"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].GetName();
                e.Values["Extencion"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.Values["ImagenProceso"] = null;
            }
            long? Num = null;
            e.Values["Id_Imagen"] = Num;
        }
        protected void frmFichaTecnica_ProcesosDetallados_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_ProcesosDetallados_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_ProcesosDetallados")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_ProcesosDetallados_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            if (((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.NewValues["ImagenProceso"] = Bytes;
                e.NewValues["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
                e.NewValues["NombreImagen"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].GetName();
                e.NewValues["Extencion"] = ((RadAsyncUpload)((Control)sender).FindControl("rauImagenProceso")).UploadedFiles[0].ContentType;
            }
            else
            {
                e.NewValues["ImagenProceso"] = null;
            }
            if (e.OldValues["Id_Imagen"].ToString() == String.Empty)
            {
                long? Num = null;
                e.NewValues["Id_Imagen"] = Num;
            }
        }
        protected void frmFichaTecnica_ProcesosDetallados_DataBound(object sender, EventArgs e)
        {
            if (((FormView)sender).CurrentMode == FormViewMode.Edit)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados objFichaTecnica_Proceso = (SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados)((FormView)sender).DataItem;
                ((RadBinaryImage)((FormView)sender).FindControl("rbiImagenProceso")).DataValue = objFichaTecnica_Proceso.ImagenProceso;
            }
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton30", "ImageButton30", (int)Modulo_Enum.FichaTecnica, 2);
        }
        protected void gvFichaTecnica_ProcesosDetallados_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_ProcesosDetallados")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource17")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_ProcesosDetallados")).DataBind();
        }
        protected void gvFichaTecnica_ProcesosDetallados_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados objFichaTecnica_Proceso = (SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados)e.Row.DataItem;
                ((RadBinaryImage)e.Row.FindControl("rbiImagenProceso")).DataValue = objFichaTecnica_Proceso.ImagenProceso;
            }
        }
        protected void btnEliminar_ProcesosDetallados_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados objFichaTecnicaProcesosDetallados = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados();
                    objFichaTecnicaProcesosDetallados.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_ProcesosDetalladosFachada().Eliminar(objFichaTecnicaProcesosDetallados);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_ProcesosDetallados")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_ProcesosDetallados")).ChangeMode(FormViewMode.Insert);
        }
        protected void frmFichaTecnica_Talla_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values["Id"] = 0;
            e.Values["Id_FichaTecnica"] = (Int64?)Int64.Parse(((HiddenField)frmPpal.FindControl("hdfId")).Value);
        }
        protected void frmFichaTecnica_Talla_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).SelectedIndex = -1;
        }
        protected void frmFichaTecnica_Talla_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Talla")).ChangeMode(FormViewMode.Insert);
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).DataBind();
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).SelectedIndex = -1;
        }
        protected void gvFichaTecnica_Talla_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Talla")).ChangeMode(FormViewMode.Edit);
            ((ObjectDataSource)frmPpal.FindControl("ObjectDataSource15")).SelectParameters["Id"].DefaultValue = ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).SelectedValue.ToString();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Talla")).DataBind();
        }
        protected void gvFichaTecnica_Talla_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
            }
        }
        protected void btnEliminar_Talla_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Talla objFichaTecnicaTalla = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Talla();
                    objFichaTecnicaTalla.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnica_TallaFachada().Eliminar(objFichaTecnicaTalla);
                }
            }
            ((GridView)frmPpal.FindControl("gvFichaTecnica_Talla")).DataBind();
            ((FormView)frmPpal.FindControl("frmFichaTecnica_Talla")).ChangeMode(FormViewMode.Insert);
        }
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            ScriptManager.RegisterStartupScript((this.Master as Details_NoUpdatePanel), (this.Master as Details_NoUpdatePanel).GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }
        protected void cboColores_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Remove("style");
                if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.Color"))
                {
                    if (((SIGED_3.CRM.Model.Negocio.Entidades.Color)e.Item.DataItem).Color1 == "")
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                    }
                    else
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.Color)e.Item.DataItem).Color1 + ";");
                    }
                }
                else if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_NoProductoTerminadoResult"))
                {
                    if (((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_NoProductoTerminadoResult)e.Item.DataItem).Color == "")
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                    }
                    else
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_NoProductoTerminadoResult)e.Item.DataItem).Color + ";");
                    }
                }
            }
        }
        protected void frmFichaTecnica_Color_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton5", "ImageButton5", (int)Modulo_Enum.FichaTecnica, 2);
        }
        protected void frmFichaTecnica_Hilo_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton10", "ImageButton10", (int)Modulo_Enum.FichaTecnica, 2);
        }
        protected void frmFichaTecnica_Talla_DataBound(object sender, EventArgs e)
        {
            new Genericos().ConfigurarPermisosDetalle(((FormView)sender), "ImageButton25", "ImageButton25", (int)Modulo_Enum.FichaTecnica, 2);
        }
    }
}