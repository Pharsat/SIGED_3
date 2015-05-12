<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true"
    CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Proveedor.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Proveedor Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Proveedor<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Proveedor"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProveedorFachada" UpdateMethod="Actualizar"
                        DeleteMethod="Eliminar" OnInserted="ObjectDataSource1_Inserted">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:FormView ID="frmPpal" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert"
                                    OnItemInserting="frmPpal_ItemInserting" OnItemUpdating="frmPpal_ItemUpdating"
                                    OnDataBound="frmPpal_DataBound" OnItemInserted="frmPpal_ItemInserted" OnItemUpdated="frmPpal_ItemUpdated">
                                    <EditItemTemplate>
                                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="rmpEditar" SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" PageViewID="rpvProveedor" Text="Proveedor" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvContactos" Text="Contactos">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpEditar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvProveedor" runat="server">
                                                <br />
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label9" runat="server" Text="Tipo de documento"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboTipoDeDocumento" runat="server" DataSourceID="ObjectDataSource4"
                                                                DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TiposDeDocumento") %>'>
                                                            </telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDeDocumento"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeDocumentoFachada"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label1" runat="server" Text="País"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboPais" runat="server" AutoPostBack="True" CausesValidation="False"
                                                                DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                                ValidationGroup="Edit">
                                                            </telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboPais"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label2" runat="server" Text="Provincia"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboProvincia" runat="server" DataSourceID="ObjectDataSource2"
                                                                DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" ValidationGroup="Edit"
                                                                CausesValidation="False">
                                                            </telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboProvincia"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
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
                                                            <asp:Label ID="Label3" runat="server" Text="Ciudad"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                                                DataTextField="Nombre" DataValueField="Id" ValidationGroup="Edit">
                                                            </telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboCiudad"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
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
                                                            <asp:Label ID="Label4" runat="server" Text="Identificación"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtIdentificacion" runat="server" MaxLength="100" Text='<%# Bind("Identficacion") %>'
                                                                Width="200px" ValidationGroup="Edit">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIdentificacion"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtNombre" runat="server" MaxLength="100" Text='<%# Bind("Nombre") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNombre"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label12" runat="server" Text="Razón social"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtRazonSocial" runat="server" MaxLength="100" Text='<%# Bind("RazonSocial") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label6" runat="server" Text="Telefono 1"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTel1" runat="server" MaxLength="50" Text='<%# Bind("Telefono_1") %>'
                                                                Width="125px" ValidationGroup="Edit">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label7" runat="server" Text="Telefono 2"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTel2" runat="server" MaxLength="50" Text='<%# Bind("Telefono_2") %>'
                                                                Width="125px" ValidationGroup="Edit">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label10" runat="server" Text="Dirección"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtDireccion" runat="server" Height="80px" MaxLength="500"
                                                                Text='<%# Bind("Direccion") %>' TextMode="MultiLine" ValidationGroup="Edit" Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtEmail" runat="server" MaxLength="200" Text='<%# Bind("Email") %>'
                                                                ValidationGroup="Edit" Width="250px">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                                Display="Dynamic"  ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                                Display="Dynamic" ErrorMessage="* correo inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="Edit"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label8" runat="server" Text="Estado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                                Text="Habilitado" ValidationGroup="Edit" />
                                                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado"
                                                                Text="Deshabilitado" Checked='<%# Bind("EstadoInv") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label14" runat="server" Text="Proveedor principal"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:RadioButton ID="rdProveedorPpal" runat="server" Checked='<%# Bind("ProveedorPrincipal") %>'
                                                                GroupName="ProveedorPrincipal" Text="Si" ValidationGroup="Edit" />
                                                            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="ProveedorPrincipal"
                                                                Text="No" Checked='<%# Bind("ProveedorPpalInv") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;" colspan="2">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                ValidationGroup="Edit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvContactos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmProveedor_Contacto" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmProveedor_Contacto_ItemInserted" OnItemInserting="frmProveedor_Contacto_ItemInserting"
                                                                OnItemUpdated="frmProveedor_Contacto_ItemUpdated" CssClass="CentrarElemento" OnDataBound="frmProveedor_Contacto_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Proveedor" runat="server" Value='<%# Bind("Id_Proveedor") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Nombres"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtNombres" runat="server" MaxLength="100" Text='<%# Bind("Nombres") %>'
                                                                                    Width="150px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Apellidos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtApellidos" runat="server" MaxLength="100" Text='<%# Bind("Apellidos") %>'
                                                                                    Width="150px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Teléfono"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTelefono" runat="server" MaxLength="50" Text='<%# Bind("Telefono") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Fax"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtFax" runat="server" MaxLength="50" Text='<%# Bind("Fax") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Móvil"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtMovil" runat="server" MaxLength="50" Text='<%# Bind("Movil") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado2"
                                                                                    Text="Habilitado" />
                                                                                <asp:RadioButton ID="RadioButton2" runat="server" Checked='<%# Bind("EstadoInv") %>'
                                                                                    GroupName="Estado2" Text="Deshabilitado" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label12" runat="server" Text="Dirección"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDireccion" runat="server" Height="50px" MaxLength="200"
                                                                                    Text='<%# Bind("Direccion") %>' TextMode="MultiLine" Width="200px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label13" runat="server" Text="Sede"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtSede" runat="server" MaxLength="100" Text='<%# Bind("Sede") %>'
                                                                                    Width="150px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Proveedor" runat="server" Value='<%# Bind("Id_Proveedor") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Nombres"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtNombres" runat="server" MaxLength="100" Width="150px"
                                                                                    Text='<%# Bind("Nombres") %>'>
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Apellidos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtApellidos" runat="server" MaxLength="100" Width="150px"
                                                                                    Text='<%# Bind("Apellidos") %>'>
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Teléfono"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTelefono" runat="server" MaxLength="50" Text='<%# Bind("Telefono") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Fax"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtFax" runat="server" MaxLength="50" Text='<%# Bind("Fax") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Móvil"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtMovil" runat="server" MaxLength="50" Text='<%# Bind("Movil") %>'
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                                                    Text="Habilitado" />
                                                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado" Text="Deshabilitado"
                                                                                    Checked='<%# Bind("EstadoInv") %>' />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label12" runat="server" Text="Dirección"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDireccion" runat="server" Height="50px" MaxLength="200"
                                                                                    TextMode="MultiLine" Width="200px" Text='<%# Bind("Direccion") %>'>
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label13" runat="server" Text="Sede"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtSede" runat="server" MaxLength="100" Width="150px" Text='<%# Bind("Sede") %>'>
                                                                                </telerik:RadTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Proveedor_Contacto"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Proveedor_ContactoFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="0" Name="Id" Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvProveedor_Contactos" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" DataKeyNames="Id" OnSelectedIndexChanged="gvProveedor_Contactos_SelectedIndexChanged"
                                                                OnRowCreated="gvProveedor_Contactos_RowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarTodasLasFilas" runat="server" onclick="checkAll(this);" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarFila" runat="server" onclick="Check_Click(this);" />
                                                                            <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png"
                                                                                CommandName="Select" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_Proveedor" HeaderText="Id_Proveedor" SortExpression="Id_Proveedor"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                                                                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                                                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                                                                    <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
                                                                    <asp:BoundField DataField="Movil" HeaderText="Movil" SortExpression="Movil" />
                                                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                                                                    <asp:BoundField DataField="Sede" HeaderText="Sede" SortExpression="Sede" />
                                                                    <asp:TemplateField HeaderText="Estado">
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="imgEstado" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado"
                                                                        Visible="False" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_Proveedor" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Proveedor_ContactoFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_Proveedor" PropertyName="Value"
                                                                        Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Tipo de documento"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboTipoDeDocumento" runat="server" DataSourceID="ObjectDataSource4"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TiposDeDocumento") %>'>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDeDocumento"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeDocumentoFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" Text="País"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPais" runat="server" AutoPostBack="True" CausesValidation="False"
                                                        DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                        ValidationGroup="Insert">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboPais"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Provincia"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboProvincia" runat="server" DataSourceID="ObjectDataSource2"
                                                        DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" ValidationGroup="Insert"
                                                        CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboProvincia"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label3" runat="server" Text="Ciudad"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                                        DataTextField="Nombre" DataValueField="Id" ValidationGroup="Insert">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboCiudad"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label4" runat="server" Text="Identificación"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtIdentificacion" runat="server" MaxLength="100" Text='<%# Bind("Identficacion") %>'
                                                        Width="200px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIdentificacion"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtNombre" runat="server" MaxLength="100" Text='<%# Bind("Nombre") %>'
                                                        ValidationGroup="Insert" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNombre"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label12" runat="server" Text="Razón social"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtRazonSocial" runat="server" MaxLength="100" Text='<%# Bind("RazonSocial") %>'
                                                        ValidationGroup="Insert" Width="200px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" Text="Telefono 1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtTel1" runat="server" MaxLength="50" Text='<%# Bind("Telefono_1") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label7" runat="server" Text="Telefono 2"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtTel2" runat="server" MaxLength="50" Text='<%# Bind("Telefono_2") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" Text="Dirección"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtDireccion" runat="server" Height="80px" MaxLength="500"
                                                        Text='<%# Bind("Direccion") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                        Width="250px">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtEmail" runat="server" MaxLength="200" Text='<%# Bind("Email") %>'
                                                        ValidationGroup="Insert" Width="250px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                        Display="Dynamic" ErrorMessage="* correo inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="Insert"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                        Text="Habilitado" ValidationGroup="Insert" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado"
                                                        Text="Deshabilitado" Checked='<%# Bind("EstadoInv") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label14" runat="server" Text="Proveedor principal"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdProveedorPpal" runat="server"
                                                        Checked='<%# Bind("ProveedorPrincipal") %>' GroupName="ProveedorPrincipal"
                                                        Text="Si" ValidationGroup="Edit" />
                                                    <asp:RadioButton ID="RadioButton3" runat="server"
                                                        Checked='<%# Bind("ProveedorPpalInv") %>' GroupName="ProveedorPrincipal"
                                                        Text="No" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                        ValidationGroup="Insert" />
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                </asp:FormView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
