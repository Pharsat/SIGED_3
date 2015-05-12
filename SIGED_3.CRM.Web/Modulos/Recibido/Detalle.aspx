<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Recibido.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Recibidos Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Recibidos<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Recibidos"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecibidosFachada" UpdateMethod="Actualizar" OnInserted="ObjectDataSource1_Inserted">
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
                                    OnDataBound="frmPpal_DataBound" OnItemInserted="frmPpal_ItemInserted" OnItemUpdated="frmPpal_ItemUpdated" Style="margin-right: 1px">
                                    <EditItemTemplate>
                                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="rmpEditar" SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" PageViewID="rpvOrdenesDeTrabajo" Text="Recibidos" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvDetalles" Text="Detalles">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvRecibirOrden" Text="Recibir una Orden">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpEditar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvOrdenesDeTrabajo" runat="server">
                                                <br />
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                <asp:HiddenField ID="hdfId_Estado" runat="server" Value='<%# Bind("Id_Estado") %>' />
                                                <asp:HiddenField ID="hdfConsecutivo" runat="server" Value='<%# Bind("Consecutivo") %>' />
                                                <table class="CentrarElemento">
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label17" runat="server" Text="Consecutivo"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Eval("Consecutivo") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label15" runat="server" Text="Solicitante"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblReceptor" runat="server" Text='<%# Eval("Miembro_Texto") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label18" runat="server" Text="Fecha de Recibido"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadDatePicker ID="dtFechaDeRecibido" runat="server"  DbSelectedDate='<%# Bind("FechaRecibido") %>' MinDate="1900-01-01">
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dtFechaDeRecibido" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label21" runat="server" Text="Estado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblEstadoDelOrdenesDeTrabajo" runat="server" Text='<%# Eval("Estado_Texto") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvDetalles" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmRecibidos_Detalles" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmRecibidos_Detalles_ItemInserted" OnItemInserting="frmRecibidos_Detalles_ItemInserting"
                                                                OnItemUpdated="frmRecibidos_Detalles_ItemUpdated" CssClass="CentrarElemento" OnItemUpdating="frmRecibidos_Detalles_ItemUpdating" OnDataBound="frmRecibidos_Detalles_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Recibidos" runat="server" Value='<%# Bind("Id_Recibido") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Update" Width="600px" AutoPostBack="True" CausesValidation="False" Enabled="False">
                                                                                    <HeaderTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label84" runat="server" Text="Talla"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </HeaderTemplate>
                                                                                    <FooterTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label93" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label85" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label86" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label87" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label88" runat="server" Text="Talla"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label94" runat="server" ForeColor="Black" Text='<%# Eval("NombreRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label89" runat="server" ForeColor="Black" Text='<%# Eval("TipoRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label90" runat="server" ForeColor="Black" Text='<%# Eval("UnidadDeMedida") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label91" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label92" runat="server" ForeColor="Black" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label95" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" Enabled="False" SelectedValue='<%# Bind("Id_UnidadDeMedida") %>' ValidationGroup="Update">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Tipo" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="cboRecursos" Name="Id_Cosa" PropertyName="SelectedValue" Type="Int64" />
                                                                                        <asp:Parameter DefaultValue="r" Name="TipoCosa" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Orden ligada a este detalle"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOrdenLigada" runat="server" Text='<%# Eval("OrdenLigada") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Cantidad a producir"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' ValidationGroup="Update" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Recibido" runat="server" Value='<%# Bind("Id_Recibido") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Insert" Width="600px" AutoPostBack="True" CausesValidation="False">
                                                                                    <HeaderTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label84" runat="server" Text="Talla"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </HeaderTemplate>
                                                                                    <FooterTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label93" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label85" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label86" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label87" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label88" runat="server" Text="Talla"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label94" runat="server" ForeColor="Black" Text='<%# Eval("NombreRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label89" runat="server" ForeColor="Black" Text='<%# Eval("TipoRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label90" runat="server" ForeColor="Black" Text='<%# Eval("UnidadDeMedida") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label91" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label92" runat="server" ForeColor="Black" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" ValidationGroup="Insert">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Tipo" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="cboRecursos" Name="Id_Cosa" PropertyName="SelectedValue" Type="Int64" />
                                                                                        <asp:Parameter DefaultValue="r" Name="TipoCosa" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Cantidad"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' ValidationGroup="Insert" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Recibidos_RecursosFachada" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Recibidos_Recursos" InsertMethod="Guardar" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Recibidos_Recursos_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvRecibidos_Detalles" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" OnSelectedIndexChanged="gvRecibidos_Detalles_SelectedIndexChanged"
                                                                OnRowCreated="gvRecibidos_Detalles_RowCreated">
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
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Recurso" SortExpression="Nombre" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                    <asp:BoundField DataField="NombreColor" HeaderText="Color" SortExpression="NombreColor" />
                                                                    <asp:BoundField DataField="NombreUnidadDeMedida" HeaderText="Unidad de Medida" SortExpression="NombreUnidadDeMedida" />
                                                                    <asp:BoundField DataField="NombreTipoDeRecurso" HeaderText="Tipo" SortExpression="NombreTipoDeRecurso" />
                                                                    <asp:BoundField DataField="CantidadRecibida" HeaderText="Recibido" SortExpression="CantidadRecibida" />
                                                                    <asp:BoundField DataField="CantidadPedida" HeaderText="Ordenado" SortExpression="CantidadPedida" />
                                                                    <asp:BoundField DataField="CantidadFaltantePorRecibir" HeaderText="Restante a Recibir" SortExpression="CantidadFaltantePorRecibir" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_Recibido_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Recibidos_RecursosFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_Orden" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvRecibirOrden" runat="server">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Ordenes de Trabajo"></asp:Label></td>
                                                        <td>
                                                            <telerik:RadComboBox ID="cboOrdenesDeTrabajo" runat="server" DataSourceID="ObjectDataSource7" DataTextField="Consecutivo" DataValueField="Id" ValidationGroup="PedidoAAnadir"></telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboOrdenesDeTrabajo" Display="Dynamic" ValidationGroup="PedidoAAnadir"></asp:RequiredFieldValidator>
                                                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_NoRecibidos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.OrdenesDeTrabajoFachada"></asp:ObjectDataSource>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnAñadirDetallesAPedidos" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Agregar.png" OnClick="btnAñadirDetallesAPedidos_Click" ValidationGroup="PedidoAAnadir" />
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
                                                    <asp:Label ID="Label10" runat="server" Text="Consecutivo"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Eval("Consecutivo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Solicitante"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblReceptor" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label11" runat="server" Text="Fecha de recepción"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadDatePicker ID="dtFechaDeRecepción" runat="server" MinDate="1900-01-01"  DbSelectedDate='<%# Bind("FechaRecibido") %>'>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dtFechaDeRecepción" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;" colspan="2">
                                                    <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                        ValidationGroup="Insert" />
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
