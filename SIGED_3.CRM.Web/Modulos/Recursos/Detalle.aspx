<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Recursos.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Recursos Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>Recursos<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                        DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Recurso"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada" UpdateMethod="Actualizar"
                        OnInserted="ObjectDataSource1_Inserted">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <table class="CentrarElemento">
                        <tr>
                            <td>
                                <asp:FormView ID="frmPpal" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert"
                                    OnItemInserting="frmPpal_ItemInserting" OnItemUpdating="frmPpal_ItemUpdating"
                                    OnDataBound="frmPpal_DataBound" OnItemInserted="frmPpal_ItemInserted" OnItemUpdated="frmPpal_ItemUpdated">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <asp:HiddenField ID="hdfId_GrupoDeMirmbros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                        <asp:HiddenField ID="hdfTalla" runat="server" Value='<%# Bind("Talla") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label3" runat="server" Text="Unidad de Medida"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" ValidationGroup="Update"
                                                        SelectedValue='<%# Bind("Id_UnidadDeMedida") %>'>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboUnidadDeMedida"
                                                        Display="Dynamic"
                                                        ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Color"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboColores" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Color") %>' ValidationGroup="Update" Width="250px" HighlightTemplatedItems="true">
                                                        <HeaderTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label49" runat="server" Text="Nombre"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label50" runat="server" Text="Color"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label51" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <div id="gcColor" runat="server">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboColores" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ColorFachada">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" Text="Tipo de recurso"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboTipoDeRecurso" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TipoDeRecurso") %>' ValidationGroup="Update">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDeRecurso" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_QueNoSonProductoTerminado" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeRecursoFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtNombre" runat="server" MaxLength="50"
                                                        Text='<%# Bind("Nombre") %>' ValidationGroup="Update"
                                                        Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                        ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado"
                                                        Text="Habilitado" ValidationGroup="Update" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Estado" Text="Deshabilitado"
                                                        Checked='<%# Bind("EstadoInv") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                        ValidationGroup="Update" />
                                                </td>
                                            </tr>
                                        </table>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <asp:HiddenField ID="hdfId_GrupoDeMirmbros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                        <asp:HiddenField ID="hdfTalla" runat="server" Value='<%# Bind("Talla") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label3" runat="server" Text="Unidad de Medida"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_UnidadDeMedida") %>' ValidationGroup="Insert">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Color"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboColores" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Color") %>' ValidationGroup="Insert" Width="250px" HighlightTemplatedItems="true">
                                                        <HeaderTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label49" runat="server" Text="Nombre"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label50" runat="server" Text="Color"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label51" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <div id="gcColor" runat="server">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboColores" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ColorFachada">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" Text="Tipo de recurso"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboTipoDeRecurso" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_TipoDeRecurso") %>' ValidationGroup="Insert">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboTipoDeRecurso" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_QueNoSonProductoTerminado" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoDeRecursoFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="txtNombre" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>' ValidationGroup="Insert" Width="200px">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label8" runat="server" Text="Estado"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:RadioButton ID="rdEstado" runat="server" Checked='<%# Bind("Estado") %>' GroupName="Estado" Text="Habilitado" ValidationGroup="Insert" />
                                                    <asp:RadioButton ID="RadioButton2" runat="server" Checked='<%# Bind("EstadoInv") %>' GroupName="Estado" Text="Deshabilitado" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert" />
                                                </td>
                                            </tr>
                                        </table>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:FormView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
