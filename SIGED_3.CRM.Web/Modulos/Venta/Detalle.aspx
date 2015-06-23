<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Venta.Detalle" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Venta Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Venta<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Venta"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.VentaFachada" UpdateMethod="Actualizar" OnInserted="ObjectDataSource1_Inserted">
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
                                                <telerik:RadTab runat="server" PageViewID="rpvVenta" Text="Venta" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvDetalles" Text="Detalles">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpEditar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvVenta" runat="server">
                                                <br />
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                <asp:HiddenField ID="hdfConsecutivo" runat="server" Value='<%# Bind("Consecutivo") %>' />
                                                <asp:HiddenField ID="hdfIdCliente" runat="server" Value='<%# Eval("Id_Cliente") %>' />
                                                <table class="CentrarElemento">
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label16" runat="server" Text="Cliente"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboClientes" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Cliente") %>' Width="300px"></telerik:RadComboBox>
                                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ClienteFachada">
                                                                <SelectParameters>
                                                                    <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                    <asp:ControlParameter ControlID="hdfIdCliente" Name="Id_Cliente" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboClientes" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label17" runat="server" Text="Consecutivo"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblConsecutivo" runat="server" Text='<%# Eval("Consecutivo") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label15" runat="server" Text="Vendedor"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblVendedor" runat="server" Text='<%# Eval("Miembro_Texto") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label18" runat="server" Text="Fecha de realización"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadDatePicker ID="dtFechaDeRealizacion" runat="server"  DbSelectedDate='<%# Bind("FechaDerealizacion") %>' MinDate="1900-01-01"></telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dtFechaDeRealizacion" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label14" runat="server" Text="Precio escogido"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboPrecioEscogido" runat="server" DataSourceID="ObjectDataSource2" DataTextField="TipoPrecioEscogido1" DataValueField="Id" SelectedValue='<%# Bind("TipoPrecioVenta") %>' Width="125px"></telerik:RadComboBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cboPrecioEscogido" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoPrecioEscogidoFachada"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label96" runat="server" Text="Subtotal"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblSubtotal" runat="server" Text='<%# Eval("SubTotal", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label97" runat="server" Text="IVA"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadNumericTextBox ID="txtIva" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("IVA") %>' MinValue="0" Type="Percent" ValidationGroup="Update" Width="60px" Culture="en-US">
                                                                <NumberFormat DecimalDigits="2" />
                                                            </telerik:RadNumericTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label98" runat="server" Text="Retención"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadNumericTextBox ID="txtRetencion" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("Retencion") %>' MinValue="0" Type="Percent" ValidationGroup="Update" Width="60px" Culture="en-US">
                                                                <NumberFormat DecimalDigits="2" />
                                                            </telerik:RadNumericTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label99" runat="server" Text="Total"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total", "{0:N}") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label100" runat="server" Text="Total en letras"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblTotalLetras" runat="server" Text='<%# Eval("TotalEnLetras") %>'></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label95" runat="server" Text="Observaciones"></asp:Label></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtObservaciones" runat="server" Height="60px" MaxLength="500" Text='<%# Bind("Observaciones") %>' TextMode="MultiLine" Width="300px">
                                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar" IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating="" PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False" TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                                            </telerik:RadTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" /></td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvDetalles" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmVenta_Detalle" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmVenta_Detalle_ItemInserted" OnItemInserting="frmVenta_Detalle_ItemInserting"
                                                                OnItemUpdated="frmVenta_Detalle_ItemUpdated" CssClass="CentrarElemento" OnItemUpdating="frmVenta_Detalle_ItemUpdating" OnDataBound="frmVenta_Detalle_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Venta" runat="server" Value='<%# Bind("Id_Venta") %>' />
                                                                    <asp:HiddenField ID="hdfId_Bodega" runat="server" Value='<%# Bind("Id_Bodega") %>' />
                                                                    <table class="CentrarElemento"></table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" AutoPostBack="True" CausesValidation="False" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Producto") %>' ValidationGroup="Update" Width="600px" OnSelectedIndexChanged="cboRecursos_SelectedIndexChanged">
                                                                                    <HeaderTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
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
                                                                                                    <asp:Label ID="Label86" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label85" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label93" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label87" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
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
                                                                                                    <asp:Label ID="Label90" runat="server" ForeColor="Black" Text='<%# Eval("UnidadDeMedida") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label89" runat="server" ForeColor="Black" Text='<%# Eval("TipoRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label94" runat="server" ForeColor="Black" Text='<%# Eval("NombreRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label91" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label92" runat="server" ForeColor="Black" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Bodega"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboBodega" Runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" Enabled="False" SelectedValue='<%# Bind("Id_Bodega") %>'>
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.BodegaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="hdfId_Bodega" Name="Id_Bodega" PropertyName="Value" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Cantidad"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' ValidationGroup="Update" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Valor Unitario"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValorUnitario" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("ValorUnitario") %>' ValidationGroup="Update" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtValorUnitario" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtObservaciones" runat="server" Height="80px" MaxLength="1000" Text='<%# Bind("Descripccion") %>' TextMode="MultiLine" ValidationGroup="Update" Width="250px"></telerik:RadTextBox></td>
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
                                                                    <asp:HiddenField ID="hdfId_Venta" runat="server" Value='<%# Bind("Id_Venta") %>' />
                                                                    <table class="CentrarElemento"></table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" AutoPostBack="True" CausesValidation="False" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" OnSelectedIndexChanged="cboRecursos_SelectedIndexChanged" SelectedValue='<%# Bind("Id_Producto") %>' ValidationGroup="Insert" Width="600px">
                                                                                    <HeaderTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
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
                                                                                                    <asp:Label ID="Label86" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label85" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label93" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label87" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
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
                                                                                                    <asp:Label ID="Label90" runat="server" ForeColor="Black" Text='<%# Eval("UnidadDeMedida") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label89" runat="server" ForeColor="Black" Text='<%# Eval("TipoRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label94" runat="server" ForeColor="Black" Text='<%# Eval("NombreRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label91" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label92" runat="server" ForeColor="Black" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label11" runat="server" Text="Bodega"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboBodega" Runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Bodega") %>'>
                                                                                </telerik:RadComboBox>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.BodegaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:Parameter Name="Id_Bodega" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Cantidad"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' ValidationGroup="Insert" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label8" runat="server" Text="Valor Unitario"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValorUnitario" runat="server"  DataType="System.Decimal" DbValue='<%# Bind("ValorUnitario") %>' ValidationGroup="Insert" Width="125px">
                                                                                    <NumberFormat DecimalDigits="2" />
                                                                                </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtValorUnitario" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label></td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="80px" MaxLength="1000" Text='<%# Bind("Descripccion") %>' TextMode="MultiLine" ValidationGroup="Insert" Width="250px"></telerik:RadTextBox></td>
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
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Venta_DetalleFachada" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Venta_Detalle" InsertMethod="Guardar" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Venta_Detalle_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvVenta_Detalles" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" DataKeyNames="Id" OnSelectedIndexChanged="gvVenta_Detalles_SelectedIndexChanged"
                                                                OnRowCreated="gvVenta_Detalles_RowCreated">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarTodasLasFilas" runat="server" onclick="checkAll(this);" /></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarFila" runat="server" onclick="Check_Click(this);" /><asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png"
                                                                                CommandName="Select" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                                                    <asp:BoundField DataField="NombreColor" HeaderText="Color" SortExpression="NombreColor" />
                                                                    <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                                                    <asp:BoundField DataField="NombreUnidadDeMedida" HeaderText="Und. Med." SortExpression="NombreUnidadDeMedida" />
                                                                    <asp:BoundField DataField="NombreTipoDeRecurso" HeaderText="Tipo" SortExpression="NombreTipoDeRecurso" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:N}" />
                                                                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitario" SortExpression="ValorUnitario" DataFormatString="{0:N}" />
                                                                    <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" SortExpression="ValorTotal" DataFormatString="{0:N}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_Venta_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Venta_DetalleFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_Venta" PropertyName="Value" Type="Int64" />
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
                                                    <asp:Label ID="Label9" runat="server" Text="Cliente"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboClientes" runat="server" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Cliente") %>' Width="300px">
                                                    </telerik:RadComboBox>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ClienteFachada">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                            <asp:Parameter Name="Id_Cliente" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboClientes"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
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
                                                    <asp:Label ID="Label15" runat="server" Text="Vendedor"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblVendedor" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label11" runat="server" Text="Fecha"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadDatePicker ID="dtFecha" runat="server" MinDate="1900-01-01"  DbSelectedDate='<%# Bind("FechaDerealizacion") %>'>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dtFecha" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label14" runat="server" Text="Precio escogido"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPrecioEscogido" runat="server" DataSourceID="ObjectDataSource2" DataTextField="TipoPrecioEscogido1" DataValueField="Id" SelectedValue='<%# Bind("TipoPrecioVenta") %>' Width="125px">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cboPrecioEscogido" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.TipoPrecioEscogidoFachada"></asp:ObjectDataSource>
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
