<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Reports.Master" AutoEventWireup="true" CodeBehind="impCompra.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Informes.impCompra" %>
<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="rptViewer" runat="server" Height="1133px" Width="944px" BackColor="White">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
