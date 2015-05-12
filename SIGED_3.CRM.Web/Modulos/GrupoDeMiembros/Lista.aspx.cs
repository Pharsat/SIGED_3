using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Web.MasterPage;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.GrupoDeMiembros
{
    public partial class Lista : System.Web.UI.Page
    {
        private long Id
        {
            get
            {
                if (ViewState["Id"] == null)
                {
                    ViewState["Id"] = SessionManager.Id_Miembro;
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
            ScriptManager objScriptManager = ScriptManager.GetCurrent(this.Page);
            if (this.Id != 0)
            {
                objScriptManager.RegisterPostBackControl(frmPpal.FindControl("UpdateButton"));
            }
            else
            {
                objScriptManager.RegisterPostBackControl(frmPpal.FindControl("InsertButton"));
            }
        }
        protected void frmPpal_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["Id_Provincia"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboProvincia")).SelectedValue);
            e.NewValues["Id_Ciudad"] = (Int64?)Int64.Parse(((RadComboBox)frmPpal.FindControl("cboCiudad")).SelectedValue);
            if (((RadAsyncUpload)frmPpal.FindControl("rauImagenGrupo")).UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[((RadAsyncUpload)frmPpal.FindControl("rauImagenGrupo")).UploadedFiles[0].InputStream.Length];
                ((RadAsyncUpload)frmPpal.FindControl("rauImagenGrupo")).UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                e.NewValues["ImagenGrupo"] = Bytes;
                e.NewValues["NombreImagen"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenGrupo")).UploadedFiles[0].GetName();
                e.NewValues["Extencion"] = ((RadAsyncUpload)frmPpal.FindControl("rauImagenGrupo")).UploadedFiles[0].ContentType;
                e.NewValues["Id_Miembro_Salva"] = SessionManager.Id_Miembro.Value;
            }
            else
            {
                e.NewValues["ImagenGrupo"] = null;
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
                SIGED_3.CRM.Model.Negocio.Entidades.GrupoDeMiembros objGrupoDeMiembros = (SIGED_3.CRM.Model.Negocio.Entidades.GrupoDeMiembros)frmPpal.DataItem;
                if (objGrupoDeMiembros.Id_Provincia != null)
                {
                    ((RadComboBox)frmPpal.FindControl("cboProvincia")).SelectedValue = objGrupoDeMiembros.Id_Provincia.ToString();
                    ((RadComboBox)frmPpal.FindControl("cboCiudad")).DataBind();
                    ((RadComboBox)frmPpal.FindControl("cboCiudad")).SelectedValue = objGrupoDeMiembros.Id_Ciudad.ToString();
                }
                ((RadBinaryImage)frmPpal.FindControl("rbiImagenGrupo")).DataValue = objGrupoDeMiembros.ImagenGrupo;
            }
        }
        protected void frmPpal_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            e.KeepInEditMode = true;
            (this.Master as Ppal_NoSearch).CargarImagenGrupo();
            ScriptManager.RegisterStartupScript((this.Master as Ppal_NoSearch).Expose_upLista, (this.Master as Ppal_NoSearch).Expose_upLista.GetType(), "CallMyFunction", "Mensaje('Su información ha sido actualizada.')", true);
        }
    }
}