<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Reports.Master" AutoEventWireup="true" CodeBehind="infPlanDeCompras.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Informes.infPlanDeCompras" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table class="CentrarElemento">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Consecutivo"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtConsecutivo" runat="server" DataType="System.Int64" MinValue="0">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
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
