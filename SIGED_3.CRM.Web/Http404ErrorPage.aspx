<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Http404ErrorPage.aspx.cs" Inherits="SIGED_3.CRM.Web.Http404ErrorPage" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.: Acceso restringido :.</title>
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
                                <asp:Label ID="Label1" runat="server"
                                    Text="Lo sentimos pero lo que estas buscando no se encuentra aquí."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:Image ID="Image2" runat="server"
                                    ImageUrl="~/Recursos/Diseno/Imagenes/General-Private-icon.png" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modulos/Login.aspx">Ir a la página de Login.</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
