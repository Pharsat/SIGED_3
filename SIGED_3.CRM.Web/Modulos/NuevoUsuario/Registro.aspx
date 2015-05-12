<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.NuevoUsuario.Registro" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.: Registro de Usurio :.</title>
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
                                        <asp:Label ID="Label14" runat="server" Text="Código de activación:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtCodigoActivacion" runat="server" MaxLength="10">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigoActivacion"
                                            Display="Dynamic" ValidationGroup="Codigo"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: center;">
                                        <asp:ImageButton ID="btnValidarCodigo" runat="server" ImageUrl="~/Recursos/Diseno/Imagenes/VerificacionCodigo.gif"
                                            ValidationGroup="Codigo" OnClick="btnValidarCodigo_Click" Height="30px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <table style="margin-left: auto; margin-right: auto;">
                                <tr>
                                    <td style="text-align: center;" colspan="2">
                                        <asp:Label ID="Label2" runat="server" Text="Información del Grupo"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtNombreGrupo" runat="server" ValidationGroup="Registro"
                                            MaxLength="100" Width="200px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreGrupo" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label3" runat="server" Text="Pais:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadComboBox ID="cboPais" runat="server" DataSourceID="ObjectDataSource1"
                                            DataTextField="Nombre" DataValueField="Id" Width="160px" AutoPostBack="True"
                                            ValidationGroup="Registro" CausesValidation="False">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboPais" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label5" runat="server" Text="Provincia:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadComboBox ID="cboProvincia" runat="server" DataSourceID="ObjectDataSource2"
                                            DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" ValidationGroup="Registro" CausesValidation="False">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboProvincia" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="Seleccionar_PorPais" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProvinciaFachada">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cboPais" Name="Id_Pais" PropertyName="SelectedValue"
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label4" runat="server" Text="Ciudad:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                            DataTextField="Nombre" DataValueField="Id" ValidationGroup="Registro" CausesValidation="False">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboCiudad" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="Seleccionar_PorProvincia" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.CiudadFachada">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="cboProvincia" Name="Id_Provincia" PropertyName="SelectedValue"
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="60px" TextMode="MultiLine"
                                            Width="300px" ValidationGroup="Registro">
                                        </telerik:RadTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;" colspan="2">
                                        <asp:Label ID="Label7" runat="server" Text="Información del Miembro Responsable"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label8" runat="server" Text="Tipo de documento:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadComboBox ID="cboTipoDeDocumento" runat="server" DataSourceID="ObjectDataSource4"
                                            DataTextField="Nombre" DataValueField="Id" ValidationGroup="Registro">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDeDocumento" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeDocumentoFachada"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label9" runat="server" Text="Nro de documento:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadNumericTextBox ID="txtNroDocumento" runat="server" DataType="System.Int32"
                                            MinValue="0" ValidationGroup="Registro">
                                            <NumberFormat DecimalDigits="0" />
                                        </telerik:RadNumericTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNroDocumento" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label10" runat="server" Text="Nombre(s):"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtNombres" runat="server" Width="300px" ValidationGroup="Registro">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombres" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label11" runat="server" Text="Apellido(s):"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtApellidos" runat="server" Width="300px" ValidationGroup="Registro">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtApellidos" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label12" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadDatePicker ID="dtFechaNacimiento" runat="server" MinDate="1900-01-01">
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="dtFechaNacimiento" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label13" runat="server" Text="Email:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtEmail" runat="server" Width="300px" ValidationGroup="Registro">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="* Correo no válido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Registro"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label15" runat="server" Text="Usuario:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtUsuario" runat="server" MaxLength="20" ValidationGroup="Registro"
                                            Width="125px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtUsuario" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label16" runat="server" Text="Contraseña:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtContrasena" runat="server" MaxLength="20" TextMode="Password"
                                            ValidationGroup="Registro" Width="125px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtContrasena" Display="Dynamic" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label17" runat="server" Text="Confirma Contraseña:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <telerik:RadTextBox ID="txtConfirmarContrasena" runat="server" MaxLength="20" TextMode="Password"
                                            ValidationGroup="Registro" Width="125px">
                                        </telerik:RadTextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContrasena" ControlToValidate="txtConfirmarContrasena" Display="Dynamic" ErrorMessage="* Contraseñas no coinciden." ValidationGroup="Registro"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;"></td>
                                    <td style="text-align: left;">
                                        <asp:CheckBox ID="chkAcepto" runat="server"
                                            Text="Acepto los términos y condiciones de uso." />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;" colspan="2">
                                        <table class="CentrarElemento">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnRegistrar" runat="server" ValidationGroup="Registro" ImageUrl="~/Recursos/Diseno/Imagenes/Registrar.gif"
                                                        OnClick="btnRegistrar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <asp:HyperLink ID="HyperLink1" runat="server"
                                NavigateUrl="~/Modulos/Login.aspx">Ir a la página de Login.</asp:HyperLink>
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
