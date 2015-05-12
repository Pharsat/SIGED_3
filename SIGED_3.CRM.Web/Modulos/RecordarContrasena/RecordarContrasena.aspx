<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordarContrasena.aspx.cs"
    Inherits="SIGED_3.CRM.Web.Modulos.RecordarContrasena.RecordarContrasena" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.: Recordar contraseña :.</title>
    <script src="../../scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/ScriptsGenerales.js" type="text/javascript"></script>
</head>
<body style="padding: 0px; margin: 0px; border: 0px; width: 100%; height: 100%; font-family: Calibri; background-image: none; background-color: white;">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div style="width: 1000px; margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/LOGOTIPO SIGED.jpg" />
            <asp:UpdatePanel ID="upDetalle" runat="server">
                <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="View1" runat="server">
                            <table style="margin-left: auto; margin-right: auto;">
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label14" runat="server" Text="Usuario:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtUsuario" runat="server" MaxLength="20" ValidationGroup="Codigo">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
                                            Display="Dynamic"  ValidationGroup="Codigo"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center;">
                                        <asp:ImageButton ID="btnValidarUsuario" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/RecordarContrasena.gif"
                                            ValidationGroup="Codigo" OnClick="btnValidarCodigo_Click" Height="30px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modulos/Login.aspx">Ir a la página de Login.</asp:HyperLink>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="upProgresoDetalle" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="upDetalle">
                <ProgressTemplate>
                    <div class="overlay" />
                    <div class="overlayContent">
                        Cargando...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
