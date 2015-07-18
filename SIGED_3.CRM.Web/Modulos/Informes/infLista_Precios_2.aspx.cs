﻿using System;
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
    public partial class infLista_Precios_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            if (cboPrecios.SelectedIndex > -1)
            {
                rptViewer.Visible = true;
                rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infLista_Precios_2.rdlc";
                ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
                ReportDataSource ObjReport_2 = new ReportDataSource("dtsLista", new CostoFachada().Impresion_Lista_Precios_2(SessionManager.Id_GrupoDeMiembros, short.Parse(cboPrecios.SelectedValue)));
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(ObjReport_1);
                rptViewer.LocalReport.DataSources.Add(ObjReport_2);
                rptViewer.LocalReport.Refresh();
            }
        }
    }
}