<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Login" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.: Login :.</title>
    <script type="text/javascript" src='<%# ResolveUrl("~/scripts/jquery-1.10.2.min.js")%>'></script>
    <script type="text/javascript" src='<%# ResolveUrl("~/scripts/ScriptsGenerales.js")%>'></script>
</head>
<body style="padding: 0px; margin: 0px; border: 0px; width: 100%; height: 100%; font-family: Calibri; background-image: none; background-color: White;">
    <form id="form1" runat="server" defaultbutton="btnEntrar">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" AllowCustomErrorsRedirect="true"></telerik:RadScriptManager>
        <div style="width: 1000px; margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/LOGOTIPO SIGED.jpg" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="margin-left: auto; margin-right: auto;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtUsuario" runat="server" ValidationGroup="Login" MaxLength="20">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
                                    Display="Dynamic" ForeColor="#FF3300" ValidationGroup="Login"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadTextBox ID="txtPass" runat="server" TextMode="Password" ValidationGroup="Login"
                                    MaxLength="20">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass"
                                    Display="Dynamic" ForeColor="#FF3300" ValidationGroup="Login"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="btnEntrar" runat="server" ValidationGroup="Login" OnClick="btnEntrar_Click"
                                                ImageUrl="~/Recursos/Diseno/Imagenes/Login.gif" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnNuevoUsuario" runat="server" ValidationGroup="Login" ImageUrl="~/Recursos/Diseno/Imagenes/QuieroEstar.gif"
                                                CausesValidation="False" OnClick="btnNuevoUsuario_Click" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnRecordarContrasena" runat="server" ValidationGroup="Login"
                                                ImageUrl="~/Recursos/Diseno/Imagenes/OlvideContrasena.gif" CausesValidation="False"
                                                OnClick="btnRecordarContrasena_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblError" runat="server" BackColor="Red" ForeColor="White" Text="&lt;br/&gt;&lt;br/&gt;[Login Incorrecto]"
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="color: #FFF; background-image: url('../../Recursos/Diseno/Imagenes/PIE DE PAG.png'); position: absolute; left: 0px; right: 0px; bottom: 0px; height: 84px; z-index: 0; background-position: center; background-repeat: no-repeat;">
        </div>
        <div style="color: #FFF; background-image: url('../../Recursos/Diseno/Imagenes/figurin.png'); background-position: right bottom; background-repeat: no-repeat; position: absolute; left: 100% -308px; right: 0px; bottom: 0px; height: 629px; z-index: 1; width: 308px">
        </div>
    </form>
</body>
</html>
