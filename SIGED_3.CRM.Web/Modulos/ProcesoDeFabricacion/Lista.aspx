<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.ProcesoDeFabricacion.Lista" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Proceso de fabricación Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>
                        Proceso de fabricación
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProcesoDeFabricacionFachada">
                            <SelectParameters>
                                <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="rdEstado" Name="Estado" PropertyName="Checked" Type="Boolean" />
                                <asp:ControlParameter ControlID="txtDescripcion" Name="descripcion" PropertyName="Text" Type="String" />
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
                                <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtDescripcion" runat="server" MaxLength="500" Width="200px"
                                    Height="60px" TextMode="MultiLine">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                        IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                        MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                        PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                        TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
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
                    <asp:ImageButton ID="btnNuevo" runat="server" Style="padding-left: 20px;" ImageUrl="~/Recursos/Diseno/Iconos/Agregar.png" />
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
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEditar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                        <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Unidad de medida" SortExpression="Nombre" />
                                        <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado"
                                            Visible="False" />
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Image ID="imgEstado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField DataField="Estado" HeaderText="Estado" SortExpression="Estado"
                                            Visible="False" />
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
