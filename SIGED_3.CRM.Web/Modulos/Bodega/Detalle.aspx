﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true"
    CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Bodega.Detalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Bodega Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>Bodega<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Bodega"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.BodegaFachada"
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
                                                        Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
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
                                                        Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
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
                                                        Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="NombreTextBox" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>'
                                                        Width="125px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox"
                                                        Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Dirección" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="DireccionTextBox" runat="server" Height="80px" MaxLength="200"
                                                        Text='<%# Bind("Direccion") %>' TextMode="MultiLine" Width="250px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" Text="Telefono 1" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="Telefono_1TextBox" runat="server" MaxLength="20" Text='<%# Bind("Telefono_1") %>'
                                                        Width="125px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label7" runat="server" Text="Telefono 2" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="Telefono_2TextBox" runat="server" MaxLength="20" Text='<%# Bind("Telefono_2") %>'
                                                        Width="125px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                        Text="Habilitado" ValidationGroup="Update" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado"
                                                        Text="Deshabilitado" Checked='<%# Bind("EstadoInv") %>' />
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
                                                    <asp:Label ID="Label1" runat="server" Text="País"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPais" runat="server" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                        AutoPostBack="True" ValidationGroup="Insert" CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                        ValidationGroup="Insert" ControlToValidate="cboPais"></asp:RequiredFieldValidator>
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
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
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
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
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
                                                    <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="NombreTextBox" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Dirección"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="DireccionTextBox" runat="server" Height="80px" MaxLength="200"
                                                        Text='<%# Bind("Direccion") %>' TextMode="MultiLine" Width="250px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" Text="Telefono 1"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="Telefono_1TextBox" runat="server" MaxLength="20" Text='<%# Bind("Telefono_1") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label7" runat="server" Text="Telefono 2"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="Telefono_2TextBox" runat="server" MaxLength="20" Text='<%# Bind("Telefono_2") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
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
