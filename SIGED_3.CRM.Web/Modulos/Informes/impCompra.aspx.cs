using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;

namespace SIGED_3.CRM.Web.Modulos.Informes
{
    public partial class impCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long Id_Compra = long.Parse(Request["Id"].ToString());
                rptViewer.Visible = true;
                rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\impCompra.rdlc";
                ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
                ReportDataSource ObjReport_2 = new ReportDataSource("dtsCompra", new CompraFachada().Impresion_Compra(Id_Compra));
                ReportDataSource ObjReport_3 = new ReportDataSource("dtsCompraDetalle", new CompraFachada().Impresion_Compra_Detalle(Id_Compra));
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(ObjReport_1);
                rptViewer.LocalReport.DataSources.Add(ObjReport_2);
                rptViewer.LocalReport.DataSources.Add(ObjReport_3);
                rptViewer.LocalReport.Refresh();
            }
        }
    }
}