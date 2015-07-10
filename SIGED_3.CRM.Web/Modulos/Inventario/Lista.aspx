<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Inventario.Lista" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Inventario Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Inventario
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.InventarioFachada">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="rdEstado" Name="Estado" PropertyName="Checked" Type="Boolean" />
                                <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="txtTipoPrenda" Name="nombre100" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="cboBodegas" Name="id_Bodega" PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="txtCodigo" Name="codigo" PropertyName="Text" Type="String" />
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
                                <asp:RadioButton ID="rdEstado" runat="server" GroupName="Estado" Text="Habilitado"
                                    Checked="True" />
                                <br />
                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado" Text="Deshabilitado" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text="Referencia"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtCodigo" runat="server" MaxLength="50"
                                    ValidationGroup="Insert" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Nombre prenda"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtTipoPrenda" runat="server" MaxLength="100"
                                    ValidationGroup="Insert" Width="200px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" Text="Bodega"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadComboBox ID="cboBodegas" runat="server" DataSourceID="ObjectDataSource2" Width="300px" DataTextField="Nombre" DataValueField="Id" OnDataBound="cboBodegas_DataBound">
                                </telerik:RadComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.BodegaFachada">
                                    <SelectParameters>
                                        <asp:Parameter Name="Id_Bodega" Type="Int64" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
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
                    <asp:ImageButton ID="btnCambiarEstado" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Recargar.png"
                        OnClick="btnCambiarEstado_Click" Style="padding-left: 20px;" />
                    <asp:ImageButton ID="btnAumentarExistencia" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Aumentar.png"
                        OnClick="btnAumentarExistencia_Click" Style="padding-left: 20px;" Width="24px" />
                    <asp:ImageButton ID="btnDisminuirExistencia" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Reducir.png"
                        OnClick="btnDisminuirExistencia_Click" Style="padding-left: 20px;" />
                    <asp:ImageButton ID="btnDisminuirStock" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Minimo.png"
                        OnClick="btnDisminuirStock_Click" Style="padding-left: 20px;" />
                    <asp:ImageButton ID="btnAumentarStock" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Maximo.png"
                        OnClick="btnAumentarStock_Click" Style="padding-left: 20px;" />
                    <asp:ImageButton ID="btnRecargarInventario" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Incluir.png"
                        OnClick="btnGenerarProductos" Style="padding-left: 20px;" />
                    <telerik:RadNumericTextBox ID="txtCantidad" runat="server" Width="60px" Style="margin-left: 20px;" MinValue="0">
                    </telerik:RadNumericTextBox>
                    <asp:ImageButton ID="btnMoverABodegaLosSeleccionados" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/move-icon.png"
                        Style="padding-left: 20px;" OnClick="btnMoverABodegaLosSeleccionados_Click" />
                    <telerik:RadComboBox ID="cboBodegasAEnviar" runat="server" Width="200px" Style="padding-left: 20px;" DataSourceID="ObjectDataSource4" DataTextField="Nombre" DataValueField="Id">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.BodegaFachada">
                        <SelectParameters>
                            <asp:Parameter Name="Id_Bodega" Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="CentrarElemento">
                        <tr>
                            <td>
                                <asp:GridView ID="gvPrincipal" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                                    OnRowCreated="gvPrincipal_RowCreated">
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
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                                        <asp:BoundField DataField="Recurso" HeaderText="Recurso" SortExpression="Recurso" />
                                        <asp:BoundField DataField="Bodega" HeaderText="Bodega" SortExpression="Bodega" />
                                        <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" DataFormatString="{0:N0}" />
                                        <asp:BoundField DataField="Stock_Minimo" HeaderText="Stock Minimo" SortExpression="Stock_Minimo" DataFormatString="{0:N0}" />
                                        <asp:BoundField DataField="Stock_Maximo" HeaderText="Stock Maximo" SortExpression="Stock_Maximo" DataFormatString="{0:N0}" />
                                        <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="false" />
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Image ID="imgEstado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
