<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Recursos.Lista" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Recurso Lista :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table class="CentrarElemento">
            <thead>
                <tr>
                    <th>Recurso
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                            <SelectParameters>
                                <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM"
                                    Type="Int64" />
                                <asp:ControlParameter ControlID="rdEstado" Name="Estado" PropertyName="Checked" Type="Boolean" />
                                <asp:ControlParameter ControlID="txtNombre" Name="Nombre" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="cboTiposDeRecurso" Name="id_TipoDeRecurso" PropertyName="SelectedValue" Type="Int64" />
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
                                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadTextBox ID="txtNombre" runat="server" MaxLength="50" Width="125px">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text="Tipo de Recurso"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <telerik:RadComboBox ID="cboTiposDeRecurso" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id"></telerik:RadComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_QueNoSonProductoTerminado" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeRecursoFachada"></asp:ObjectDataSource>
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
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="NombreColor" HeaderText="Color" SortExpression="NombreColor" />
                                        <asp:BoundField DataField="NombreUnidadDeMedida" HeaderText="Unidad de medida" SortExpression="NombreUnidadDeMedida" />
                                        <asp:BoundField DataField="NombreTipoDeRecurso" HeaderText="Tipo de Recurso" SortExpression="NombreTipoDeRecurso" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" Visible="False" />
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
