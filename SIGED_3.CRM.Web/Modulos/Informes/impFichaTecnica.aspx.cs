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
    public partial class impFichaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long Id_Ficha = long.Parse(Request["Id"].ToString());
                rptViewer.Visible = true;
                rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\impFichaTecnica.rdlc";
                ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
                ReportDataSource ObjReport_2 = new ReportDataSource("dtsFichaTecnica", new FichaTecnicaFachada().Impresion_FichaTecnica(Id_Ficha));
                ReportDataSource ObjReport_3 = new ReportDataSource("dtsFichaTecnicaColores", new FichaTecnicaFachada().Impresion_FichaTecnica_Colores(Id_Ficha));
                ReportDataSource ObjReport_4 = new ReportDataSource("dtsFichaTecnicaMarquillas", new FichaTecnicaFachada().Impresion_FichaTecnica_Marquillas(Id_Ficha));
                ReportDataSource ObjReport_5 = new ReportDataSource("dtsFichaTecnicaPasosDeConfeccion", new FichaTecnicaFachada().Impresion_PasosDeConfeccion(Id_Ficha));
                ReportDataSource ObjReport_6 = new ReportDataSource("dtsFichaTecnicaProcesosDetallados", new FichaTecnicaFachada().Impresion_ProcesosDetallados(Id_Ficha));
                ReportDataSource ObjReport_7 = new ReportDataSource("dtsFichaTecnicaTallas", new FichaTecnicaFachada().Impresion_FichaTecnica_Tallas(Id_Ficha));
                ReportDataSource ObjReport_8 = new ReportDataSource("dtsFichaTecnicaHilos", new FichaTecnicaFachada().Impresion_FichaTecnica_Hilos(Id_Ficha));
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(ObjReport_1);
                rptViewer.LocalReport.DataSources.Add(ObjReport_2);
                rptViewer.LocalReport.DataSources.Add(ObjReport_3);
                rptViewer.LocalReport.DataSources.Add(ObjReport_4);
                rptViewer.LocalReport.DataSources.Add(ObjReport_5);
                rptViewer.LocalReport.DataSources.Add(ObjReport_6);
                rptViewer.LocalReport.DataSources.Add(ObjReport_7);
                rptViewer.LocalReport.DataSources.Add(ObjReport_8);
                rptViewer.LocalReport.Refresh();
            }
        }
    }
}