<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Movimiento.Lista" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Movimientos :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Movimientos
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.EntradaOSalidaFachada">
                            <SelectParameters>
                                <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int32" />
                                <asp:ControlParameter ControlID="txtRecurso" Name="nombre50" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="dpDesde" Name="desde" PropertyName="SelectedDate"
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="dpHasta" Name="hasta" PropertyName="SelectedDate"
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="txtCodigoDeLaPrenda" Name="codigo" PropertyName="Text" Type="String" />
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
                                <asp:Label ID="Label3" runat="server" Text="Nombre de recurso"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtRecurso" runat="server" MaxLength="50">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Codigo de la prenda"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtCodigoDeLaPrenda" runat="server" MaxLength="50">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
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
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                                        <asp:TemplateField HeaderText="Movimiento">
                                            <ItemTemplate>
                                                <asp:Image ID="imgMovimiento" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Recurso" HeaderText="Recurso" SortExpression="Recurso" />
                                        <asp:BoundField DataField="Cantiidad" HeaderText="Cantiidad" SortExpression="Cantiidad" />
                                        <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" SortExpression="Observaciones" />
                                        <asp:BoundField DataField="Fecha2" HeaderText="Fecha2" SortExpression="Fecha2" Visible="false" />
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
