<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Miembros.Detalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Miembro Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>Miembro<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Miembro"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.MiembroFachada"
                        UpdateMethod="Actualizar" OnInserted="ObjectDataSource1_Inserted">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <table class="CentrarElemento">
                        <tr>
                            <td>
                                <asp:FormView ID="frmPpal" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert"
                                    OnItemInserting="frmPpal_ItemInserting" OnItemUpdating="frmPpal_ItemUpdating"
                                    OnDataBound="frmPpal_DataBound" OnItemInserted="frmPpal_ItemInserted" OnItemUpdated="frmPpal_ItemUpdated">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="Etiquetas" Text="País"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPais" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                        ValidationGroup="Update" CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboPais"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Provincia" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboProvincia" runat="server" DataSourceID="ObjectDataSource2"
                                                        DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" ValidationGroup="Update"
                                                        CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboProvincia"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label3" runat="server" Text="Ciudad" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                                        DataTextField="Nombre" DataValueField="Id" ValidationGroup="Update" ChangeTextOnKeyBoardNavigation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboCiudad"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label4" runat="server" Text="Nombres" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtApellidos" runat="server" MaxLength="100" Text='<%# Bind("Nombres") %>'
                                                        Width="250px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombres"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Apellidos" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtNombres" runat="server" MaxLength="100"
                                                        Text='<%# Bind("Apellidos") %>' Width="250px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtApellidos" Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Tipo de documento" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboTipoDocumento" runat="server" DataSourceID="ObjectDataSource4" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TipoDeDocumento") %>'>
                                                    </telerik:RadComboBox>
                                                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeDocumentoFachada"></asp:ObjectDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDocumento" Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Etiquetas" Text="Identificación"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtNroDocumento" runat="server" Culture="es-CO" DataType="System.Int64" DbValue='<%# Bind("Identificacion") %>' MinValue="0" ValidationGroup="Update" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNroDocumento" Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label7" runat="server" Text="Fecha de nacimiento" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadDatePicker ID="dtFechaNacimiento" runat="server" Culture="en-US" DbSelectedDate='<%# Bind("FechaDeNacimiento") %>'>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="dtFechaNacimiento" Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" CssClass="Etiquetas" Text="Email"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtEmail" runat="server" MaxLength="256" Text='<%# Bind("Email") %>' ValidationGroup="Update" Width="250px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail" Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="* Correo no válido."  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Update"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                        ValidationGroup="Update" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="Etiquetas" Text="País"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPais" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                        ValidationGroup="Insert" CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboPais"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Provincia" CssClass="Etiquetas"></asp:Label>
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
                                                    <asp:Label ID="Label3" runat="server" Text="Ciudad" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                                        DataTextField="Nombre" DataValueField="Id" ValidationGroup="Insert" ChangeTextOnKeyBoardNavigation="False">
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
                                                    <asp:Label ID="Label4" runat="server" Text="Nombres" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtApellidos" runat="server" MaxLength="100" Text='<%# Bind("Nombres") %>'
                                                        Width="250px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombres"
                                                        Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Apellidos" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtNombres" runat="server" MaxLength="100"
                                                        Text='<%# Bind("Apellidos") %>' Width="250px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtApellidos" Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Tipo de documento" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboTipoDocumento" runat="server" DataSourceID="ObjectDataSource4" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TipoDeDocumento") %>'>
                                                    </telerik:RadComboBox>
                                                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeDocumentoFachada"></asp:ObjectDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDocumento" Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Etiquetas" Text="Identificación"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtNroDocumento" runat="server" Culture="es-CO" DataType="System.Int64" DbValue='<%# Bind("Identificacion") %>' MinValue="0" ValidationGroup="Insert" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNroDocumento" Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label7" runat="server" Text="Fecha de nacimiento" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadDatePicker ID="dtFechaNacimiento" runat="server" Culture="en-US" DbSelectedDate='<%# Bind("FechaDeNacimiento") %>'>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="dtFechaNacimiento" Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" CssClass="Etiquetas" Text="Email"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtEmail" runat="server" MaxLength="256" Text='<%# Bind("Email") %>' ValidationGroup="Insert" Width="250px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmail" Display="Dynamic"  ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="* Correo no válido."  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Insert"></asp:RegularExpressionValidator>
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
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:FormView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
