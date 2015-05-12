<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Pedido.Lista" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Pedido Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Pedidos
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PedidoFachada">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cboEstado" Name="estado" PropertyName="SelectedValue" Type="Int64" />
                                <asp:SessionParameter DefaultValue="" Name="id_GrupoDeMiembros" SessionField="IdGM"
                                    Type="Int64" />
                                <asp:ControlParameter ControlID="cboClientes" Name="id_Cliente" PropertyName="SelectedValue" Type="Int64" DefaultValue="" />
                                <asp:ControlParameter ControlID="txtTipoDePrenda" Name="tipoPrenda" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="txtConsecutivo" Name="consecutivo" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="dtDesdePedido" Name="desdeFP" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="dtHastaPedido" Name="hastaFP" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="dtDesdeRegistro" Name="desdeFR" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="dtHastaRegistro" Name="hastaFR" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="dtDesdeDespachar" Name="desdeFD" PropertyName="SelectedDate" Type="DateTime" />
                                <asp:ControlParameter ControlID="dtHastaDespachar" Name="hastaFD" PropertyName="SelectedDate" Type="DateTime" />
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
                                <asp:Label ID="Label2" runat="server" Text="Nombre de la prenda"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtTipoDePrenda" runat="server" MaxLength="50" Width="200px">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                        IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                        MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                        PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                        TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Consecutivo"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadNumericTextBox ID="txtConsecutivo" runat="server" DataType="System.Int32"
                                    MaxValue="9999999999" MinValue="1000000000" ValidationGroup="Codigo">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadComboBox ID="cboClientes" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" Width="200px" OnDataBound="cboClientes_DataBound"></telerik:RadComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ClienteFachada">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                        <asp:Parameter Name="Id_Cliente" Type="Int64" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" Text="Fecha de registro"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="dtDesdeRegistro" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dtHastaRegistro" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" Text="Fecha de pedido"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="dtDesdePedido" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dtHastaPedido" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" Text="Fecha a despachar"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="dtDesdeDespachar" runat="server" MinDate="1900-01-01">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="dtHastaDespachar" runat="server" MinDate="1900-01-01">
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
                                        <asp:BoundField DataField="FechaDerealizacion" HeaderText="Fecha de Realización" SortExpression="FechaDerealizacion" />
                                        <asp:BoundField DataField="FechaDePedido" HeaderText="Fecha de Pedido" SortExpression="FechaDePedido" />
                                        <asp:BoundField DataField="FechaADespachar" HeaderText="Fecha a despachar" SortExpression="FechaADespachar" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="NombreRegistrador" HeaderText="Registrador" SortExpression="NombreRegistrador" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
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
