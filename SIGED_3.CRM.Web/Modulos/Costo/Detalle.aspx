<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Costo.Detalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Costo Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Costo<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Costo"
                        InsertMethod="Guardar_2" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.CostoFachada" UpdateMethod="Actualizar" OnInserted="ObjectDataSource1_Inserted">
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
                                                <telerik:RadTab runat="server" PageViewID="rpvCostos" Text="Costo" Selected="True">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvProcesos" Text="Procesos">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvRecursos" Text="Recursos">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvMargenes" Text="Margenes de Costos">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpEditar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvCostos" runat="server">
                                                <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Bind("Id_GrupoDeMiembros") %>' />
                                                <asp:HiddenField ID="hdfId_Recurso" runat="server" Value='<%# Bind("Id_Recurso") %>' />
                                                <table class="CentrarElemento">
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label18" runat="server" Text="Ficha técnica | Color"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadComboBox ID="cboFichaTecnicaColor" runat="server" DataSourceID="ObjectDataSource1" DataTextField="NombrePrenda" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Insert" Width="600px">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label14" runat="server" Text="Código"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 150px;">
                                                                                <asp:Label ID="Label15" runat="server" Text="Nombre de la Prenda"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label16" runat="server" Text="Color"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;"></td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Talla" runat="server" Text="Talla"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <FooterTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label102" runat="server" Text="Código"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 150px;">
                                                                                <asp:Label ID="Label103" runat="server" Text="Nombre de la Prenda"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label104" runat="server" Text="Color"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;"></td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label105" runat="server" Text="Talla"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </FooterTemplate>
                                                                <ItemTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label106" runat="server" ForeColor="Black" Text='<%# Eval("CodigoPrenda") %>'></asp:Label>
                                                                            </td>
                                                                            <td style="width: 150px;">
                                                                                <asp:Label ID="Label107" runat="server" ForeColor="Black" Text='<%# Eval("NombrePrenda") %>'></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label108" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                            </td>
                                                                            <td style="width: 100px;">
                                                                                <div id="gcColor" runat="server">
                                                                                </div>
                                                                            </td>
                                                                            <td style="width: 100px;">
                                                                                <asp:Label ID="Label101" runat="server" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </telerik:RadComboBox>
                                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_FichasColoresParaCostos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ColorFachada">
                                                                <SelectParameters>
                                                                    <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                    <asp:ControlParameter ControlID="hdfId_Recurso" Name="id_RecursoActual" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboFichaTecnicaColor" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label25" runat="server" Text="Fecha de última actualización"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadDatePicker ID="dtFechaUltimaActualizacion" runat="server" DbSelectedDate='<%# Bind("FechaDeCreacion") %>' MinDate="1900-01-01" Culture="en-US">
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="dtFechaUltimaActualizacion" Display="Dynamic" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label26" runat="server" Text="Costo de materiales"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblCostoDeMateriales" runat="server" Text='<%# Eval("CostoDeRecursos", "{0:N}") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label27" runat="server" Text="Costo de procesos"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblCostoDeProcesos" runat="server" Text='<%# Eval("CostoDeProcesos", "{0:N}") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label28" runat="server" Text="Costo de producción"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblPrecioDeProduccion" runat="server" Text='<%# Eval("CostoDeProduccion", "{0:N}") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label29" runat="server" Text="Precio de venta calculado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="lblCostoConValorizacion" runat="server" Text='<%# Eval("CostoConValirizacion", "{0:N}") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label30" runat="server" Text="Precio de venta especial"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadNumericTextBox ID="txtPrecioVentaEspecial" runat="server" DataType="System.Decimal" DbValue='<%# Bind("PrecioVentaFinal") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px" Culture="en-US">
                                                            </telerik:RadNumericTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationGroup="Update" ControlToValidate="txtPrecioVentaEspecial"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label31" runat="server" Text="Precio público"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadNumericTextBox ID="txtPrecioPublico" runat="server" DataType="System.Decimal" DbValue='<%# Bind("PrecioPublico") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px">
                                                            </telerik:RadNumericTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationGroup="Update" ControlToValidate="txtPrecioPublico"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label17" runat="server" Text="Precio de distribuidor"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadNumericTextBox ID="txtPrecioDistribuidor" runat="server" DataType="System.Decimal" DbValue='<%# Bind("PrecioDistrbuidor") %>' MinValue="0" ValidationGroup="Update" Value="0" Width="125px" Culture="en-US">
                                                            </telerik:RadNumericTextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ValidationGroup="Update" ControlToValidate="txtPrecioDistribuidor"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvRecursos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmCosto_Recurso" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmCosto_Recurso_ItemInserted" OnItemInserting="frmCosto_Recurso_ItemInserting"
                                                                OnItemUpdated="frmCosto_Recurso_ItemUpdated" CssClass="CentrarElemento" OnDataBound="frmCosto_Recurso_DataBound" OnItemUpdating="frmCosto_Recurso_ItemUpdating">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Update_2" Width="600px" AutoPostBack="True">
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
                                                                                                <td style="width: 100px;"></td>
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
                                                                                                <td style="width: 100px;"></td>
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
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Update_2"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" ValidationGroup="Update_2">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Update_2"></asp:RequiredFieldValidator>
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
                                                                                <asp:Label ID="Label8" runat="server" Text="Consumo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtConsumo" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Consumo") %>' MinValue="0" ValidationGroup="Update_2" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtConsumo" Display="Dynamic" ValidationGroup="Update_2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Valor unitario"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValorUnitario" runat="server" DataType="System.Decimal" DbValue='<%# Bind("ValoUnitario") %>' MinValue="0" ValidationGroup="Update_2" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtValorUnitario" Display="Dynamic" ValidationGroup="Update_2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update_2" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Recurso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Insert_2" Width="600px" AutoPostBack="True">
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
                                                                                                <td style="width: 100px;"></td>
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
                                                                                                    <asp:Label ID="Label84" runat="server" Text="Nombre"></asp:Label>
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
                                                                                                <td style="width: 100px;"></td>
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
                                                                                                    <asp:Label ID="Label88" runat="server" ForeColor="Black" Text='<%# Eval("NombreRecurso") %>'></asp:Label>
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
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Insert_2"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label7" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Nombre" DataValueField="Id" ValidationGroup="Insert_2">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Insert_2"></asp:RequiredFieldValidator>
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
                                                                                <asp:Label ID="Label8" runat="server" Text="Consumo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtConsumo" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Consumo") %>' MinValue="0" ValidationGroup="Insert_2" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtConsumo" Display="Dynamic" ValidationGroup="Insert_2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label9" runat="server" Text="Valor unitario"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValorUnitario" runat="server" DataType="System.Decimal" DbValue='<%# Bind("ValoUnitario") %>' MinValue="0" ValidationGroup="Insert_2" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtValorUnitario" Display="Dynamic" ValidationGroup="Insert_2"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert_2" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Costo_Recurso"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_RecursoFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Costos_Recursos" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Costo_Recurso_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvCosto_Recursos" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" DataKeyNames="Id" OnSelectedIndexChanged="gvCosto_Recursos_SelectedIndexChanged"
                                                                OnRowCreated="gvCosto_Recursos_RowCreated" Style="margin-right: 1px">
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
                                                                    <asp:BoundField DataField="Material" HeaderText="Material" SortExpression="Material" />
                                                                    <asp:BoundField DataField="UnidadDeMedida" HeaderText="Unidad de Medida" SortExpression="UnidadDeMedida" />
                                                                    <asp:BoundField DataField="Consumo" HeaderText="Consumo" SortExpression="Consumo" DataFormatString="{0:N}" />
                                                                    <asp:BoundField DataField="ValoUnitario" HeaderText="Valor Unitario" SortExpression="ValoUnitario" DataFormatString="{0:N}" />
                                                                    <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" DataFormatString="{0:N}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_Id" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_RecursoFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="id_Costo" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvProcesos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmCosto_Proceso" runat="server" CssClass="CentrarElemento" DataKeyNames="Id" DataSourceID="ObjectDataSource11" DefaultMode="Insert" OnItemInserted="frmCosto_Proceso_ItemInserted" OnItemInserting="frmCosto_Proceso_ItemInserting" OnItemUpdated="frmCosto_Proceso_ItemUpdated" OnDataBound="frmCosto_Proceso_DataBound" OnItemUpdating="frmCosto_Proceso_ItemUpdating">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label109" runat="server" Text="Procesos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboProcesos" runat="server" DataSourceID="ObjectDataSource7" DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Bind("Id_Proceso") %>' ValidationGroup="Update_1" Width="250px" AutoPostBack="True">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboProcesos" Display="Dynamic" ValidationGroup="Update_1"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProcesoDeFabricacionFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label125" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource8" DataTextField="Nombre" DataValueField="Id" ValidationGroup="Update_1">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Update_1"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Tipo" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="cboProcesos" Name="Id_Cosa" PropertyName="SelectedValue" Type="Int64" />
                                                                                        <asp:Parameter DefaultValue="p" Name="TipoCosa" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label126" runat="server" Text="Cantidad"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' MinValue="0" ValidationGroup="Update_1" Value="0" Width="125px">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Update_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label127" runat="server" Text="Valor unitario"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValor" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Valor") %>' MinValue="0" ValidationGroup="Update_1" Value="0" Width="125px">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtValor" Display="Dynamic" ValidationGroup="Update_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton8" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update_1" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton9" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label109" runat="server" Text="Procesos"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboProcesos" runat="server" DataSourceID="ObjectDataSource7" DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Bind("Id_Proceso") %>' ValidationGroup="Insert_1" Width="250px" AutoPostBack="True">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboProcesos" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProcesoDeFabricacionFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label125" runat="server" Text="Unidad de medida"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboUnidadDeMedida" runat="server" DataSourceID="ObjectDataSource8" DataTextField="Nombre" DataValueField="Id" ValidationGroup="Insert_1">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cboUnidadDeMedida" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Tipo" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.UnidadDeMedidaFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="cboProcesos" Name="Id_Cosa" PropertyName="SelectedValue" Type="Int64" />
                                                                                        <asp:Parameter DefaultValue="p" Name="TipoCosa" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label126" runat="server" Text="Cantidad"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtCantidad" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Cantidad") %>' MinValue="0" ValidationGroup="Insert_1" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtCantidad" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label127" runat="server" Text="Valor unitario"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtValor" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Valor") %>' MinValue="0" ValidationGroup="Insert_1" Value="0" Width="125px" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtValor" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton8" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert_1" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton9" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Costo_ProcesoDeFabricacion" InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_ProcesoDeFabricacionFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Costos_Proceso" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png" OnClick="btnEliminar_Costo_Proceso_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvCosto_Procesos" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource12" OnRowCreated="gvCosto_Procesos_RowCreated" OnSelectedIndexChanged="gvCosto_Procesos_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarTodasLasFilas0" runat="server" onclick="checkAll(this);" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarFila" runat="server" onclick="Check_Click(this);" />
                                                                            <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton12" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                                                    <asp:BoundField DataField="UnidadDeMedida" HeaderText="Unidad de Medida" SortExpression="UnidadDeMedida" />
                                                                    <asp:BoundField DataField="Cantidad" DataFormatString="{0:N}" HeaderText="Cantidad" SortExpression="Cantidad" />
                                                                    <asp:BoundField DataField="Valor" DataFormatString="{0:N}" HeaderText="Valor" SortExpression="Valor" />
                                                                    <asp:BoundField DataField="Total" DataFormatString="{0:N}" HeaderText="Total" SortExpression="Total" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource12" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_Id" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_ProcesoDeFabricacionFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="id_Costo" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvMargenes" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmCosto_Margen" runat="server" CssClass="CentrarElemento" DataKeyNames="Id" DataSourceID="ObjectDataSource17" DefaultMode="Insert" OnItemInserted="frmCosto_Margen_ItemInserted" OnItemInserting="frmCosto_Margen_ItemInserting" OnItemUpdated="frmCosto_Margen_ItemUpdated" OnDataBound="frmCosto_Margen_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label132" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" MaxLength="100" Text='<%# Bind("Descripcion") %>' ValidationGroup="Update_3" Width="200px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ValidationGroup="Update_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label133" runat="server" Text="Porcentaje"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtPorcentaje" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Porcentaje") %>' MinValue="0" ValidationGroup="Update_3" Value="0" Width="40px" Type="Percent">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtPorcentaje" Display="Dynamic" ValidationGroup="Update_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label134" runat="server" Text="Posición"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtPosicion" runat="server" DataType="System.Int32" DbValue='<%# Bind("Posicion") %>' MinValue="0" ValidationGroup="Update_3" Value="0" Width="30px">
                                                                                    <NumberFormat DecimalDigits="0" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPosicion" Display="Dynamic" ValidationGroup="Update_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton15" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Update_3" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton16" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_Costo" runat="server" Value='<%# Bind("Id_Costo") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label132" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" MaxLength="100" Text='<%# Bind("Descripcion") %>' ValidationGroup="Insert_3" Width="200px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ValidationGroup="Insert_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label133" runat="server" Text="Porcentaje"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtPorcentaje" runat="server" DataType="System.Decimal" DbValue='<%# Bind("Porcentaje") %>' MinValue="0" ValidationGroup="Insert_3" Value="0" Width="40px" Type="Percent" Culture="en-US">
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtPorcentaje" Display="Dynamic" ValidationGroup="Insert_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label134" runat="server" Text="Posición"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtPosicion" runat="server" DataType="System.Int32" DbValue='<%# Bind("Posicion") %>' MinValue="0" ValidationGroup="Insert_3" Value="0" Width="30px" Culture="en-US">
                                                                                    <NumberFormat DecimalDigits="0" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPosicion" Display="Dynamic" ValidationGroup="Insert_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton15" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png" ValidationGroup="Insert_3" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton16" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource17" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.Costo_Valorizacion" InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_ValorizacionFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Costos_Margen" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png" OnClick="btnEliminar_Costo_Margen_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvCosto_Margenes" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ObjectDataSource18" OnRowCreated="gvCosto_Margens_RowCreated" OnSelectedIndexChanged="gvCosto_Margenes_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarTodasLasFilas1" runat="server" onclick="checkAll(this);" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarFila" runat="server" onclick="Check_Click(this);" />
                                                                            <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton17" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                                                                    <asp:BoundField DataField="Porcentaje" DataFormatString="{0:N}%" HeaderText="Porcentaje" SortExpression="Porcentaje" />
                                                                    <asp:BoundField DataField="Posicion" HeaderText="Posición" SortExpression="Posicion" />
                                                                    <asp:BoundField DataField="ValorHastaElMomento" DataFormatString="{0:N}" HeaderText="Acumulado" SortExpression="ValorHastaElMomento" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource18" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_By_Id" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.Costo_ValorizacionFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="id_Costo" PropertyName="Value" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Eval("Id") %>' />
                                        <asp:HiddenField ID="hdfId_Recurso" runat="server" Value='<%# Eval("Id_Recurso") %>' />
                                        <table class="CentrarElemento">
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label9" runat="server" Text="Ficha técnica | Color"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboFichaTecnicaColor" runat="server" DataSourceID="ObjectDataSource1"
                                                        DataTextField="NombrePrenda" DataValueField="Id" SelectedValue='<%# Bind("Id_Recurso") %>' Width="600px" OnItemDataBound="cboColores_ItemDataBound" ValidationGroup="Insert" Filter="Contains" HighlightTemplatedItems="True">
                                                        <HeaderTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label14" runat="server" Text="Código"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="Label15" runat="server" Text="Nombre de la Prenda"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label16" runat="server" Text="Color"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;"></td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Talla" runat="server" Text="Talla"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <FooterTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label14" runat="server" Text="Código"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="Label15" runat="server" Text="Nombre de la Prenda"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label16" runat="server" Text="Color"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;"></td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label17" runat="server" Text="Talla"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label14" runat="server" ForeColor="Black" Text='<%# Eval("CodigoPrenda") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 150px;">
                                                                        <asp:Label ID="Label15" runat="server" ForeColor="Black" Text='<%# Eval("NombrePrenda") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label16" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="width: 100px;">
                                                                        <div id="gcColor" runat="server">
                                                                        </div>
                                                                    </td>
                                                                    <td style="width: 100px;">
                                                                        <asp:Label ID="Label101" runat="server" Text='<%# Eval("Talla") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </telerik:RadComboBox>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_FichasColoresParaCostos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ColorFachada">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                            <asp:ControlParameter ControlID="hdfId_Recurso" Name="id_RecursoActual" PropertyName="Value" Type="Int64" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cboFichaTecnicaColor"
                                                        Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label10" runat="server" Text="Fecha de última actualización"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadDatePicker ID="dtFechaUltimaActualizacion" runat="server" MinDate="1900-01-01" DbSelectedDate='<%# Bind("FechaDeCreacion") %>'>
                                                    </telerik:RadDatePicker>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="dtFechaUltimaActualizacion" Display="Dynamic" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label11" runat="server" Text="Costo de materiales"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblCostoDeMateriales" runat="server" Text='<%# Eval("CostoDeRecursos", "{0:N}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label12" runat="server" Text="Costo de procesos"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblCostoDeProcesos" runat="server" Text='<%# Eval("CostoDeProcesos", "{0:N}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label13" runat="server" Text="Costo de producción"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblPrecioDeProduccion" runat="server" Text='<%# Eval("CostoDeProduccion", "{0:N}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label14" runat="server" Text="Precio de venta calculado"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblCostoConValorizacion" runat="server" Text='<%# Eval("CostoConValirizacion", "{0:N}") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label15" runat="server" Text="Precio de venta especial"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox runat="server" ID="txtPrecioVentaEspecial" DataType="System.Decimal" DbValue='<%# Bind("PrecioVentaFinal") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px"></telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationGroup="Insert" ControlToValidate="txtPrecioVentaEspecial"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label16" runat="server" Text="Precio público"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtPrecioPublico" runat="server" DataType="System.Decimal" DbValue='<%# Bind("PrecioPublico") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationGroup="Insert" ControlToValidate="txtPrecioPublico"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label17" runat="server" Text="Precio de distribuidor"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadNumericTextBox ID="txtPrecioDistribuidor" runat="server" DataType="System.Decimal" DbValue='<%# Bind("PrecioDistrbuidor") %>' MinValue="0" ValidationGroup="Insert" Value="0" Width="125px">
                                                    </telerik:RadNumericTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ValidationGroup="Insert" ControlToValidate="txtPrecioDistribuidor"></asp:RequiredFieldValidator>
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
