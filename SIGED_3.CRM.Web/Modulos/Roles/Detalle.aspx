<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Roles.Detalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Roles Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Roles<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Roles"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RolesFachada" UpdateMethod="Actualizar"
                        DeleteMethod="Eliminar" OnInserted="ObjectDataSource1_Inserted">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:FormView ID="frmPpal" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert"
                                    OnItemInserting="frmPpal_ItemInserting" OnItemUpdating="frmPpal_ItemUpdating"
                                    OnDataBound="frmPpal_DataBound" OnItemInserted="frmPpal_ItemInserted" OnItemUpdated="frmPpal_ItemUpdated">
                                    <EditItemTemplate>
                                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="rmpEditar" SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" PageViewID="rpvRoles" Text="Roles" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvPermisos" Text="Permisos">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpEditar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvRoles" runat="server">
                                                <br />
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtRoles" runat="server" MaxLength="100" Text='<%# Bind("Rol") %>'
                                                                Width="125px" ValidationGroup="Edit">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRoles"
                                                                Display="Dynamic" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;" colspan="2">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                ValidationGroup="Edit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvPermisos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmRoles_Contacto" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmRoles_Contacto_ItemInserted" OnItemInserting="frmRoles_Contacto_ItemInserting"
                                                                OnItemUpdated="frmRoles_Contacto_ItemUpdated" CssClass="CentrarElemento" OnDataBound="frmRoles_Contacto_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Roles" runat="server" Value='<%# Bind("Id_Rol") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Modulo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboModulos" runat="server" SelectedValue='<%# Bind("Id_Modulo") %>' ValidationGroup="Update" Width="200px" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id">
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ModulosPermitidos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ModuloFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="hdfId_Roles" Name="id_Rol" PropertyName="Value" Type="Int32" />
                                                                                        <asp:SessionParameter Name="id_Cuenta" SessionField="IdC" Type="Int64" />
                                                                                        <asp:ControlParameter ControlID="cboModulos" Name="id_Modulo" PropertyName="SelectedValue" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboModulos" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Consultar la lista de datos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkConsultarLista" runat="server" Checked='<%# Bind("ConsultarLista") %>' ValidationGroup="Update" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Consultar el detalle de un registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkConsultarDetalle" runat="server" Checked='<%# Bind("ConsultarDetalle") %>' ValidationGroup="Update" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Actualizar un registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkActualizarRegistro" runat="server" Checked='<%# Bind("ActualizarDetalle") %>' ValidationGroup="Update" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Eliminar el registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEliminarRegistro" runat="server" Checked='<%# Bind("EliminarRegistro") %>' ValidationGroup="Update" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Crear un nuevo registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkCrearRegistro" runat="server" Checked='<%# Bind("CrearRegistro") %>' ValidationGroup="Update" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Roles" runat="server" />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Modulo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboModulos" runat="server" ValidationGroup="Insert" Width="200px" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id">
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ModulosPermitidos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ModuloFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="hdfId_Roles" Name="id_Rol" PropertyName="Value" Type="Int32" />
                                                                                        <asp:SessionParameter Name="id_Cuenta" SessionField="IdC" Type="Int64" />
                                                                                        <asp:Parameter Name="id_Modulo" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboModulos" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Consultar la lista de datos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkConsultarLista" runat="server" Checked='<%# Bind("ConsultarLista") %>' ValidationGroup="Insert" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Consultar el detalle de un registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkConsultarDetalle" runat="server" Checked='<%# Bind("ConsultarDetalle") %>' ValidationGroup="Insert" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Actualizar un registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkActualizarRegistro" runat="server" Checked='<%# Bind("ActualizarDetalle") %>' ValidationGroup="Insert" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Eliminar el registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEliminarRegistro" runat="server" Checked='<%# Bind("EliminarRegistro") %>' ValidationGroup="Insert" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Crear un nuevo registro"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkCrearRegistro" runat="server" Checked='<%# Bind("CrearRegistro") %>' ValidationGroup="Insert" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Permisos"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PermisosFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvRoles_Contactos" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" DataKeyNames="Id" OnSelectedIndexChanged="gvRoles_Contactos_SelectedIndexChanged">
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
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png"
                                                                                CommandName="Select" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Módulo" SortExpression="Módulo" />
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Actualizar" SortExpression="ActualizarDetalle">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ActualizarDetalle") %>' Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Consultar Un Registro" SortExpression="ConsultarDetalle">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("ConsultarDetalle") %>' Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Consultar Lista de Registros" SortExpression="ConsultarLista">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("ConsultarLista") %>' Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Crear" SortExpression="CrearRegistro">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox4" runat="server" Checked='<%# Bind("CrearRegistro") %>' Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Eliminar" SortExpression="EliminarRegistro">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox5" runat="server" Checked='<%# Bind("EliminarRegistro") %>' Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_Rol_LS" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PermisosFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_Rol" PropertyName="Value" Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <table class="CentrarElemento">
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Rol"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtRoles" runat="server" MaxLength="100" Text='<%# Bind("Rol") %>'
                                                        Width="125px" ValidationGroup="Insert">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRoles"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                        ValidationGroup="Insert" Height="24px" />
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
