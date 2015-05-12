<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericErrorPage.aspx.cs" Inherits="SIGED_3.CRM.Web.GenericErrorPage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.: Un error en el sistema :.</title>
    <script type="text/javascript" src='<%# ResolveUrl("~/scripts/jquery-1.10.2.min.js")%>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/scripts/ScriptsGenerales.js")%>'></script>
</head>
<body style="padding: 0px; margin: 0px; border: 0px; width: 100%; height: 100%; font-family: Calibri; background-image: none; background-color: White;">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div style="width: 1000px; margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/LOGOTIPO SIGED.jpg" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="margin-left: auto; margin-right: auto;">
                        <tr>
                            <td style="text-align: center;">
                                <asp:Label ID="Label1" runat="server" Text="Huy, hemos cometido un error.&lt;br /&gt;Lo sentimos, el error ha sido reportado y haremos todo lo posible por solucionarlo."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/Device-Network-icon.png" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modulos/Login.aspx">Ir a la página de Login.</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:LinkButton ID="btnVerError" runat="server" OnClick="btnVerError_Click" Visible="False">Ver detalles de error</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:Panel ID="pnlDetallesError" runat="server" Width="800px" Visible="false">
                                    <table>
                                        <tr>
                                            <td style="text-align: left; width: 150px; vertical-align: top;">
                                                <asp:Label ID="Label2" runat="server" Text="InnerTrace"></asp:Label>
                                            </td>
                                            <td style="text-align: left; color: black; width: 650px;">
                                                <asp:Label ID="innerTrace" runat="server" ForeColor="Black"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px; vertical-align: top;">
                                                <asp:Label ID="Label3" runat="server" Text="InnerErrorPanel"></asp:Label>
                                            </td>
                                            <td style="text-align: left; color: black; width: 650px;">
                                                <asp:Label ID="InnerErrorPanel" runat="server" ForeColor="Black"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px; vertical-align: top;">
                                                <asp:Label ID="Label4" runat="server" Text="innerMessage"></asp:Label>
                                            </td>
                                            <td style="text-align: left; color: black; width: 650px;">
                                                <asp:Label ID="innerMessage" runat="server" ForeColor="Black"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px; vertical-align: top;">
                                                <asp:Label ID="Label5" runat="server" Text="exTrace"></asp:Label>
                                            </td>
                                            <td style="text-align: left; color: black; width: 650px;">
                                                <asp:Label ID="exTrace" runat="server" ForeColor="Black"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 150px; vertical-align: top;">
                                                <asp:Label ID="Label6" runat="server" Text="exMessage"></asp:Label>
                                            </td>
                                            <td style="text-align: left; color: black; width: 650px;">
                                                <asp:Label ID="exMessage" runat="server" ForeColor="Black"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
