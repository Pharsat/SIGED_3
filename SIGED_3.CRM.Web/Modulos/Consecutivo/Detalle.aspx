<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Consecutivo.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Consecutivo Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>Consecutivo<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Consecutivos"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ConsecutivosFachada"
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
                                        <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" Text="Modulo"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboModulos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Modulo") %>' ValidationGroup="Update" OnSelectedIndexChanged="cboModulos_SelectedIndexChanged" AutoPostBack="True">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboModulos" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Consecutbles" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ModuloFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Serie"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtSerie" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Serie") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSerie" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label3" runat="server" Text="Posición"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtPosicion" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Posicion") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPosicion" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Desde"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtDesde" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Desde") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesde" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Hasta"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtHasta" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Hasta") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHasta" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" />
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
                                                    <asp:Label ID="Label1" runat="server" Text="Modulo"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboModulos" runat="server" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Modulo") %>' ValidationGroup="Insert" AutoPostBack="True" OnSelectedIndexChanged="cboModulos_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationGroup="Insert" ControlToValidate="cboModulos"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All_Consecutbles" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ModuloFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Serie"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtSerie" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Serie") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSerie"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label3" runat="server" Text="Posición"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtPosicion" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Posicion") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPosicion"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Desde"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtDesde" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Desde") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesde"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Hasta"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtHasta" runat="server"  DataType="System.Int64" DbValue='<%# Bind("Hasta") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                        <NumberFormat DecimalDigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHasta" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
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
