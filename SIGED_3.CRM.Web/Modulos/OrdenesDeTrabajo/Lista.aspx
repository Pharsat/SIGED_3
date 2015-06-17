<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.OrdenesDeTrabajo.Lista" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Orden de Trabajo Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Ordenes de Trabajo
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.OrdenesDeTrabajoFachada">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboEstado" Name="estado" PropertyName="SelectedValue" Type="Int64" />
                                <asp:ControlParameter ControlID="cboClientes" Name="id_Cliente" PropertyName="SelectedValue"
                                    Type="Int64" />
                                <asp:ControlParameter ControlID="txtConsecutivo" Name="consecutivo" PropertyName="Text"
                                    Type="Int64" />
                                <asp:ControlParameter ControlID="dpDesde" Name="desde" PropertyName="SelectedDate"
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="dpHasta" Name="hasta" PropertyName="SelectedDate"
                                    Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <table class="CentrarElemento">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="Estado"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadComboBox ID="cboEstado" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Descripcion" DataValueField="Id" Width="200px"></telerik:RadComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.EstadosDelProcesoFachada"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadComboBox ID="cboClientes" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="Nombre" DataValueField="Id" OnDataBound="cboClientes_DataBound" Width="200px">
                                </telerik:RadComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ClienteFachada">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                        <asp:Parameter Name="Id_Cliente" Type="Int64" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Consecutivo"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadNumericTextBox ID="txtConsecutivo" runat="server">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Desde"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dpDesde" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Hasta"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dpHasta" runat="server">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Buscar.png"
                        OnClick="btnBuscar_Click" Style="padding-left: 20px;" />
                    <asp:ImageButton ID="btnEliminar" runat="server" Style="padding-left: 20px;" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                        OnClick="btnEliminar_Click" OnClientClick="return EliminarRegistro();" />
                    <asp:ImageButton ID="btnNuevo" runat="server" Style="padding-left: 20px;" ImageUrl="~/Recursos/Diseno/Iconos/Agregar.png"
                        OnClientClick="openWin('0');" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="CentrarElemento">
                        <tr>
                            <td>
                                <asp:GridView ID="gvPrincipal" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataSourceID="ObjectDataSource1" OnRowCreated="gvPrincipal_RowCreated">
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
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                                        <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" SortExpression="Consecutivo" />
                                        <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" SortExpression="Solicitante" />
                                        <asp:BoundField DataField="ConsecutivoPedido" HeaderText="Consec. de Pedido" SortExpression="ConsecutivoPedido" />
                                        <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" SortExpression="NombreCliente" />
                                        <asp:BoundField DataField="FechaGeneracion" HeaderText="Fecha de Realización" SortExpression="FechaGeneracion" />
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" SortExpression="FechaInicio" />
                                        <asp:BoundField DataField="FechaFinalizacion" HeaderText="Fecha de Finalización" SortExpression="FechaFinalizacion" />
                                        <asp:BoundField DataField="EstadoOrden" HeaderText="Estado" SortExpression="EstadoOrden" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
