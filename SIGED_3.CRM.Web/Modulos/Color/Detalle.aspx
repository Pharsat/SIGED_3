﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true"
    CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Color.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Color Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>
                        Color<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Color"
                            InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                            TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ColorFachada" UpdateMethod="Actualizar"
                            OnInserted="ObjectDataSource1_Inserted">
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
                                        <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="NombreTextBox" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>'
                                                        Width="125px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox"
                                                        Display="Dynamic"   ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" Text="Color" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadColorPicker ID="RadColorPicker1" runat="server">
                                                    </telerik:RadColorPicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                        Text="Habilitado" ValidationGroup="Update" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado" Text="Deshabilitado"
                                                        Checked='<%# Bind("EstadoInv") %>' />
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
                                        <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="NombreTextBox" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox"
                                                        Display="Dynamic"   ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" Text="Color" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadColorPicker ID="RadColorPicker1" runat="server">
                                                    </telerik:RadColorPicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                        Text="Habilitado" ValidationGroup="Insert" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado" Text="Deshabilitado"
                                                        Checked='<%# Bind("EstadoInv") %>' />
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
