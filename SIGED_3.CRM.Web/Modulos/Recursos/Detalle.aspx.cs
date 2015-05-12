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
namespace SIGED_3.CRM.Web.Modulos.Recursos
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
            new Genericos().ConfigurarPermisosDetalle(frmPpal, "InsertButton", "UpdateButton", (int)Modulo_Enum.Recursos, 1);
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
        protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.Id = (long)e.ReturnValue;
            ScriptManager.RegisterStartupScript((this.Master as Details).Expose_upDetalle, (this.Master as Details).Expose_upDetalle.GetType(), "CallMyFunction", "MensajeDos('guardado')", true);
        }
        protected void cboColores_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {

            if (e.Item.DataItem != null)
            {
                ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Remove("style");
                if (((SIGED_3.CRM.Model.Negocio.Entidades.Color)e.Item.DataItem).Color1 == "")
                {
                    ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                }
                else
                {
                    ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.Color)e.Item.DataItem).Color1 + ";");
                }
            }
        }
    }
}