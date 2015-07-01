<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Venta.Lista" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Venta Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Ventas
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.VentaFachada">
                            <SelectParameters>
                                <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int32" />
                                <asp:ControlParameter ControlID="dpDesde" Name="desde" PropertyName="SelectedDate" Type="DateTime" />
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
                                         <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgImprimir" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Imprimir.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Consecutivo" HeaderText="Consecutivo" SortExpression="Consecutivo" />
                                        <asp:BoundField DataField="FechaDeRealizacion" HeaderText="Fecha" SortExpression="FechaDeRealizacion" />
                                        <asp:BoundField DataField="Facturador" HeaderText="Facturador" SortExpression="Facturador" />
                                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" SortExpression="SubTotal" />
                                        <asp:BoundField DataField="IVA" HeaderText="IVA" SortExpression="IVA" />
                                        <asp:BoundField DataField="Retencion" HeaderText="Retencion" SortExpression="Retencion" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
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
