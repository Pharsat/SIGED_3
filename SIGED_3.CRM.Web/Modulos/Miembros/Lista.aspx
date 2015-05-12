<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Miembros.Lista" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Miembro Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Miembros
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="MiembrosDelGrupo" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.MiembroFachada"></asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>&nbsp;</td>
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
                                        <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo de Documento" SortExpression="TipoDocumento" />
                                        <asp:BoundField DataField="Identificacion" HeaderText="Identificación" SortExpression="Identificacion" />
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="Cumpleanos" HeaderText="Cumpleaños (Día/Mes)" SortExpression="Cumpleanos" />
                                        <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais" />
                                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" SortExpression="Provincia" />
                                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad" />
                                        <asp:TemplateField HeaderText="Solicitar cuentas">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgSolicitarCuenta" runat="server" OnClick="imgSolicitarCuenta_Click" CommandArgument='<%# Bind("Id") %>' />
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
