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
    public partial class infCostos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            rptViewer.Visible = true;
            rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infCostos.rdlc";
            ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
            ReportDataSource ObjReport_2 = new ReportDataSource("dtsRecursos", new CostoFachada().InformeCostos_Recursos(SessionManager.Id_GrupoDeMiembros, long.Parse(cboRecursos.SelectedValue)));
            ReportDataSource ObjReport_3 = new ReportDataSource("dtsProcesos", new CostoFachada().InformeCostos_Procesos(SessionManager.Id_GrupoDeMiembros, long.Parse(cboRecursos.SelectedValue)));
            ReportDataSource ObjReport_4 = new ReportDataSource("dtsValorizacion", new CostoFachada().InformeCostos_Valorizacion(SessionManager.Id_GrupoDeMiembros, long.Parse(cboRecursos.SelectedValue)));
            ReportDataSource ObjReport_5 = new ReportDataSource("dtsCabecera", new CostoFachada().InformeCostos_Cabecera(SessionManager.Id_GrupoDeMiembros, long.Parse(cboRecursos.SelectedValue)));
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(ObjReport_1);
            rptViewer.LocalReport.DataSources.Add(ObjReport_2);
            rptViewer.LocalReport.DataSources.Add(ObjReport_3);
            rptViewer.LocalReport.DataSources.Add(ObjReport_4);
            rptViewer.LocalReport.DataSources.Add(ObjReport_5);
            rptViewer.LocalReport.Refresh();
        }
        protected void cboColores_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Remove("style");
                if (e.Item.DataItem.GetType().ToString().Equals("SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_ConCostoResult"))
                {
                    if (((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_ConCostoResult)e.Item.DataItem).Color == "")
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                    }
                    else
                    {
                        ((HtmlGenericControl)e.Item.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((SIGED_3.CRM.Model.Negocio.Entidades.LC_Recursos_ConCostoResult)e.Item.DataItem).Color + ";");
                    }
                }
            }
        }
    }
}