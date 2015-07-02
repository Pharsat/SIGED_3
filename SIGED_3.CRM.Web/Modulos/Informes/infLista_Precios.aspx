<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Reports.Master" AutoEventWireup="true" CodeBehind="infLista_Precios.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Informes.infLista_Precios" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table class="CentrarElemento">
                    <tr>
                        <td style="text-align: center;">
                            <asp:ImageButton ID="btnGenerar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/custom-reports-icon.png" OnClick="btnGenerar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="rptViewer" runat="server" Height="1133px" Width="944px" BackColor="White">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
