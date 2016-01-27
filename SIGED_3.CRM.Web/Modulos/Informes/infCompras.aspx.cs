using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.Informes
{
    public partial class infConpras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void cboColores_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Remove("style");
                if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_MezcladosResult"))
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
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            rptViewer.Visible = true;
            rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infCompras.rdlc";
            ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
            ReportDataSource ObjReport_2 = new ReportDataSource("dtsCompras", new CompraFachada().Informe_Compras(SessionManager.Id_GrupoDeMiembros, dtDesde.SelectedDate, dtHasta.SelectedDate, long.Parse(cboProveedor.SelectedValue), long.Parse(cboRecursos.SelectedValue)));
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(ObjReport_1);
            rptViewer.LocalReport.DataSources.Add(ObjReport_2);
            rptViewer.LocalReport.Refresh();
        }
        protected void cboRecursos_DataBound(object sender, EventArgs e)
        {
            cboRecursos.Items.Add(new RadComboBoxItem("[Ninguno]", (0).ToString()));
        }
        protected void cboProveedor_DataBound(object sender, EventArgs e)
        {
            cboProveedor.Items.Add(new RadComboBoxItem("[Ninguno]", (0).ToString()));
        }
    }
}