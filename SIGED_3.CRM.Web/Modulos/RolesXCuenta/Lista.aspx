<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal_NoSearch.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.RolesXCuenta.Lista" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Roles X Usuario :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Roles por Usuario
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="CuentasXRolesXMiembro" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.CuentasFachada">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtPersona" Name="nombreDeUsuario" PropertyName="Text" Type="String" />
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
                                <asp:Label ID="Label6" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtPersona" runat="server" MaxLength="200" Width="200px">
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
                    <asp:ImageButton ID="btnLigarARol" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Button-Reload-icon.png" Style="padding-left: 20px;" Width="24px" OnClick="btnLigarARol_Click" />
                    <telerik:RadComboBox ID="cboRoles" runat="server" Style="padding-left: 20px;" DataSourceID="ObjectDataSource2" DataTextField="Rol" DataValueField="Id">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Lista_RolesPermitidos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RolesFachada"></asp:ObjectDataSource>
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
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id_Cuenta") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false"/>
                                        <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" SortExpression="NombreCompleto" />
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
