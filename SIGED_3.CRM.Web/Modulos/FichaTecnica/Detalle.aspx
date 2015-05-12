<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Details_NoUpdatePanel.Master" AutoEventWireup="true"
    CodeBehind="Detalle.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.FichaTecnica.Detalle" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Ficha Técnica Detalle :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos">
        <table>
            <thead>
                <tr>
                    <th>Ficha Técnica<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnicaFachada" OnInserted="ObjectDataSource1_Inserted" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica" InsertMethod="Guardar_2" UpdateMethod="Actualizar">
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
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Eval("Id_GrupoDeMiembros") %>' />
                                        <asp:HiddenField ID="hdfId_Imagen" runat="server" Value='<%# Bind("Id_Imagen") %>' />
                                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="rmpInsertar" SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" PageViewID="rpvFichaTecnica" Selected="True" Text="Cabecera">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvProcesosDetallados" Text="Procesos detallados">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvMarquilla" Text="Ubicación de Marquillas">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvColores" Text="Colores de la prenda">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvHilos" Text="Hilos">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvTallas" Text="Tallas">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvInstruccionesConstruccion" Text="Instrucciones de confección" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvAyudasTecnicas" Text="Ayudas técnicas" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvInstruccionesCostura" Text="Instrucciones de costura" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvEspecificacionPlancha" Text="Especificación de plancha" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvEspecificacionMaquina" Text="Especificación de máquina" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvPasos" Text="Ruta Operacional">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpInsertar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvFichaTecnica" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label14" runat="server" Text="Referencia"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTipoDePrenda" runat="server" MaxLength="50" Text='<%# Bind("Codigo") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="txtTipoDePrenda" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label15" runat="server" Text="Nombre de la prenda"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCodigo" runat="server" MaxLength="100" Text='<%# Bind("TipoPrenda") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="txtCodigo" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label16" runat="server" Text="Fecha de creación"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadDatePicker ID="dpFechaCreacion" runat="server" DbSelectedDate='<%# Bind("FechaActualizacion") %>'>
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dpFechaCreacion"
                                                                ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label17" runat="server" Text="Material principal"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTela" runat="server" MaxLength="100" Text='<%# Bind("Tela") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtDecripcion" runat="server" MaxLength="200" Text='<%# Bind("Descripccion") %>'
                                                                ValidationGroup="Edit" Width="250px" Height="80px" TextMode="MultiLine">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label18" runat="server" Text="Material secundario"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTelaComplemento" runat="server" MaxLength="100" Text='<%# Bind("TelaComplemento") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label19" runat="server" Text="Imagen"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadBinaryImage ID="rbiImagenPrenda" runat="server" Height="300px" Width="250px"
                                                                ResizeMode="Fit" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;"></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadAsyncUpload ID="rauImagenPrenda" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                            </telerik:RadAsyncUpload>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">&nbsp;</td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="Label79" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                ValidationGroup="Edit" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvInstruccionesConstruccion" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label20" runat="server" Text="Coser cerrado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCoserCerrado" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICCoserCerrado") %>' TextMode="MultiLine" ValidationGroup="Edit"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label21" runat="server" Text="Coser pespunteado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCoserPespunteado" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICCoserPesPunteado") %>' TextMode="MultiLine" ValidationGroup="Edit"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label22" runat="server" Text="Tipo de puntas de la recubridora"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntasRecubridora" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICTipoRecubridora") %>' TextMode="MultiLine" ValidationGroup="Edit"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label23" runat="server" Text="Aguja número"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtAgujaNumero" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICAgujaNro") %>' TextMode="MultiLine" ValidationGroup="Edit"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label67" runat="server" Text="Piezas fusionadas"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPiezasFucionadas" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICPiezasFusionadas") %>' TextMode="MultiLine" ValidationGroup="Edit"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label12" runat="server" Text="Puntadas por pulgada, cerrado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntadasPulgaCerrada" runat="server" MaxLength="50" Text='<%# Bind("ICPuntadasPorPulgadaCerrado") %>'
                                                                ValidationGroup="Edit" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label13" runat="server" Text="Puntadas por pulgada, pespunteado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntadasPulgaPespunteado" runat="server" MaxLength="50"
                                                                Text='<%# Bind("ICPuntadasPorPulgadaPespunteado") %>' ValidationGroup="Edit"
                                                                Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label24" runat="server" Text="Cuales"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCuales" runat="server" Height="80px" MaxLength="200" Text='<%# Bind("ICCuales") %>'
                                                                TextMode="MultiLine" ValidationGroup="Edit" Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvAyudasTecnicas" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label27" runat="server" Text="Pies"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPies" runat="server" MaxLength="100" Text='<%# Bind("ATPies") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label28" runat="server" Text="Folderes"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtFolderes" runat="server" MaxLength="100" Text='<%# Bind("ATFolders") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label29" runat="server" Text="Plantillas"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPlantillas" runat="server" MaxLength="100" Text='<%# Bind("ATPlantillas") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvInstruccionesCostura" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label31" runat="server" Text="Costura cubierta"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaCubierta" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasAbiertas") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label32" runat="server" Text="Costura con pespunte"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaConPespunte" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasConPespunte") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label33" runat="server" Text="Costura cerrada"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaCerrada" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasCerradas") %>'
                                                                ValidationGroup="Edit" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvMarquilla" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_Marquilla" runat="server" CssClass="CentrarElemento"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource11" DefaultMode="Insert" OnItemInserted="frmFichaTecnica_Marquilla_ItemInserted"
                                                                OnItemInserting="frmFichaTecnica_Marquilla_ItemInserting" OnItemUpdated="frmFichaTecnica_Marquilla_ItemUpdated"
                                                                OnItemUpdating="frmFichaTecnica_Marquilla_ItemUpdating" OnDataBound="frmFichaTecnica_Marquilla_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <asp:HiddenField ID="hdfId_Imagen" runat="server" Value='<%# Bind("Id_Imagen") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label60" runat="server" Text="Tipo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>' ValidationGroup="Edit_1"
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                                    ControlToValidate="txtTipo" Display="Dynamic" ValidationGroup="Edit_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label61" runat="server" Text="Ubicación"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtUbicación" runat="server" Text='<%# Bind("Ubicacion") %>'
                                                                                    ValidationGroup="Edit_1" Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                                    ControlToValidate="txtUbicación" Display="Dynamic" ValidationGroup="Edit_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label62" runat="server" Text="Altura"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtAltura" runat="server" Text='<%# Bind("Altura") %>' ValidationGroup="Edit_1"
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                                    ControlToValidate="txtAltura" Display="Dynamic" ValidationGroup="Edit_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label63" runat="server" Text="Imagen"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadBinaryImage ID="rbiImagenMarquilla" runat="server" Height="100px" ResizeMode="Fit"
                                                                                    Width="180px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;"></td>
                                                                            <td>
                                                                                <telerik:RadAsyncUpload ID="rauImagenMarquilla" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                                    MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                                                </telerik:RadAsyncUpload>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton15" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_1" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton16" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <asp:HiddenField ID="hdfId_Imagen" runat="server" Value='<%# Bind("Id_Imagen") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label60" runat="server" Text="Tipo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>' ValidationGroup="Insert_1"
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                                    ControlToValidate="txtTipo" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label61" runat="server" Text="Ubicación"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtUbicación" runat="server" Text='<%# Bind("Ubicacion") %>'
                                                                                    ValidationGroup="Insert_1" Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                                    ControlToValidate="txtUbicación" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label62" runat="server" Text="Altura"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtAltura" runat="server" Text='<%# Bind("Altura") %>' ValidationGroup="Insert_1"
                                                                                    Width="125px">
                                                                                </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                                    ControlToValidate="txtAltura" Display="Dynamic" ValidationGroup="Insert_1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label63" runat="server" Text="Imagen"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadBinaryImage ID="rbiImagenMarquilla" runat="server" Height="100px" ResizeMode="Fit"
                                                                                    Width="180px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;"></td>
                                                                            <td>
                                                                                <telerik:RadAsyncUpload ID="rauImagenMarquilla" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                                    MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                                                </telerik:RadAsyncUpload>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton15" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_1" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton16" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource11" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Marquilla"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_MarquillaFachada"
                                                                UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="0" Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Marquilla" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Marquilla_Click" OnClientClick="return EliminarRegistro();"
                                                                Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_Marquilla" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource12" OnRowCreated="gvFichaTecnica_Marquilla_RowCreated"
                                                                OnSelectedIndexChanged="gvFichaTecnica_Marquilla_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarTodasLasFilas" runat="server" onclick="checkAll(this);" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSeleccionarFila" runat="server" onclick="Check_Click(this);" /><asp:HiddenField
                                                                                ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton17" runat="server" CausesValidation="False" CommandName="Select"
                                                                                ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                                                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" SortExpression="Ubicacion" />
                                                                    <asp:BoundField DataField="Altura" HeaderText="Altura" SortExpression="Altura" />
                                                                    <asp:TemplateField HeaderText="Imagen">
                                                                        <ItemTemplate>
                                                                            <telerik:RadBinaryImage ID="rbiImagenMarquilla" runat="server" Height="100px" ResizeMode="Fit"
                                                                                Width="180px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource12" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_MarquillaFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvEspecificacionPlancha" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label39" runat="server" Text="Plancha"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPlancha" runat="server" MaxLength="50" Text='<%# Bind("PLPlancha") %>'
                                                                ValidationGroup="Edit" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label40" runat="server" Text="Vaporización"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtVaporizacion" runat="server" MaxLength="50" Text='<%# Bind("PLVaporizacion") %>'
                                                                ValidationGroup="Edit" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvEspecificacionMaquina" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label44" runat="server" Text="Recubridora"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkRecubridora" runat="server" Checked='<%# Bind("EMRecubridora") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label43" runat="server" Text="Plana"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkPlana" runat="server" Checked='<%# Bind("EMPLana") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label45" runat="server" Text="Filete sencillo"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteSencillo" runat="server" Checked='<%# Bind("EMFileteSencillo") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label46" runat="server" Text="Filetes especiales"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteEspecial" runat="server" Checked='<%# Bind("EMEspeciales") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label47" runat="server" Text="Tipo de ajuste"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTipoAjuste" runat="server" MaxLength="50" Text='<%# Bind("EMTipoAjuste") %>'
                                                                ValidationGroup="Edit" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label42" runat="server" Text="Ancho"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtAncho" runat="server" MaxLength="50" Text='<%# Bind("EMAncho") %>'
                                                                ValidationGroup="Edit" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label48" runat="server" Text="Filete con seguridad"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteSeguridad" runat="server" Checked='<%# Bind("EMFileteConseguridad") %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvColores" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_Color" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource5"
                                                                DefaultMode="Insert" OnItemInserted="frmFichaTecnica_Color_ItemInserted" OnItemInserting="frmFichaTecnica_Color_ItemInserting"
                                                                OnItemUpdated="frmFichaTecnica_Color_ItemUpdated" CssClass="CentrarElemento" OnDataBound="frmFichaTecnica_Color_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Color"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboColores" runat="server" DataSourceID="ObjectDataSource1"
                                                                                    DataTextField="Nombre" DataValueField="Id" OnItemDataBound="cboColores_ItemDataBound"
                                                                                    SelectedValue='<%# Bind("Id_Color") %>' ValidationGroup="Edit_2" Width="250px" HighlightTemplatedItems="true">
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
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboColores"
                                                                                    Display="Dynamic" ValidationGroup="Edit_2"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                                    SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ColorFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_2" />
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
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label6" runat="server" Text="Color"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboColores" runat="server" DataSourceID="ObjectDataSource1"
                                                                                    DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Color") %>'
                                                                                    OnItemDataBound="cboColores_ItemDataBound" ValidationGroup="Insert_2" Width="250px"
                                                                                    HighlightTemplatedItems="True">
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
                                                                                                    <asp:Label ID="Label49" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 120px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboColores"
                                                                                    Display="Dynamic" ValidationGroup="Insert_2"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                                    SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ColorFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_2" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Color"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ColorFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Color" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Color_Click" OnClientClick="return EliminarRegistro();"
                                                                Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_Color" runat="server" AutoGenerateColumns="False"
                                                                DataSourceID="ObjectDataSource6" DataKeyNames="Id" OnSelectedIndexChanged="gvFichaTecnica_Color_SelectedIndexChanged"
                                                                OnRowCreated="gvFichaTecnica_Color_RowCreated">
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
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                                                    <asp:TemplateField HeaderText="Color" SortExpression="Color">
                                                                        <ItemTemplate>
                                                                            <div id="gcColor" runat="server">
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ColorFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvHilos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_Hilo" runat="server" CssClass="CentrarElemento"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource9" DefaultMode="Insert" OnItemInserted="frmFichaTecnica_Hilo_ItemInserted"
                                                                OnItemInserting="frmFichaTecnica_Hilo_ItemInserting" OnItemUpdated="frmFichaTecnica_Hilo_ItemUpdated" OnDataBound="frmFichaTecnica_Hilo_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label56" runat="server" Text="Tipo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>' ValidationGroup="Edit_3"
                                                                                    Width="125px" MaxLength="50">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTipo"
                                                                                    Display="Dynamic" ValidationGroup="Edit_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label57" runat="server" Text="Calibre"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtCalibre" runat="server" Text='<%# Bind("Calibre") %>'
                                                                                    ValidationGroup="Edit_3" Width="125px" MaxLength="50">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCalibre"
                                                                                    Display="Dynamic" ValidationGroup="Edit_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton10" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_3" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton11" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label56" runat="server" Text="Tipo"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTipo" runat="server" Text='<%# Bind("Tipo") %>' ValidationGroup="Insert_3"
                                                                                    Width="125px" MaxLength="50">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTipo"
                                                                                    Display="Dynamic" ValidationGroup="Insert_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label57" runat="server" Text="Calibre"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtCalibre" runat="server" Text='<%# Bind("Calibre") %>'
                                                                                    ValidationGroup="Insert_3" Width="125px" MaxLength="50">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCalibre"
                                                                                    Display="Dynamic" ValidationGroup="Insert_3"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton10" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_3" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton11" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource9" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Hilo"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_HiloFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Hilo" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Hilo_Click" OnClientClick="return EliminarRegistro();" Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_Hilo" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource10" OnRowCreated="gvFichaTecnica_Hilo_RowCreated"
                                                                OnSelectedIndexChanged="gvFichaTecnica_Hilo_SelectedIndexChanged">
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
                                                                            <asp:ImageButton ID="ImageButton12" runat="server" CausesValidation="False" CommandName="Select"
                                                                                ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                                                                    <asp:BoundField DataField="Calibre" HeaderText="Calibre" SortExpression="Calibre" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource10" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_HiloFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvTallas" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_Talla" runat="server" CssClass="CentrarElemento"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource15" DefaultMode="Insert" OnItemInserted="frmFichaTecnica_Talla_ItemInserted"
                                                                OnItemInserting="frmFichaTecnica_Talla_ItemInserting" OnItemUpdated="frmFichaTecnica_Talla_ItemUpdated" OnDataBound="frmFichaTecnica_Talla_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label70" runat="server" Text="Talla"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTalla" runat="server" MaxLength="50" Text='<%# Bind("Talla") %>'
                                                                                    ValidationGroup="Edit_4" Width="60px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTalla"
                                                                                    Display="Dynamic" ValidationGroup="Edit_4"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton25" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_4" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton26" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label70" runat="server" Text="Talla"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtTalla" runat="server" MaxLength="50" Text='<%# Bind("Talla") %>'
                                                                                    ValidationGroup="Insert_4" Width="60px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTalla"
                                                                                    Display="Dynamic" ValidationGroup="Insert_4"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton25" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_4" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton26" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource15" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_Talla"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_TallaFachada" UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_Talla" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_Talla_Click" OnClientClick="return EliminarRegistro();"
                                                                Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_Talla" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource16" OnRowCreated="gvFichaTecnica_Talla_RowCreated"
                                                                OnSelectedIndexChanged="gvFichaTecnica_Talla_SelectedIndexChanged">
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
                                                                            <asp:ImageButton ID="ImageButton27" runat="server" CausesValidation="False" CommandName="Select"
                                                                                ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource16" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_TallaFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvPasos" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_PasosDeConfeccion" runat="server" CssClass="CentrarElemento"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource13" DefaultMode="Insert" OnItemInserted="frmFichaTecnica_PasosDeConfeccion_ItemInserted"
                                                                OnItemInserting="frmFichaTecnica_PasosDeConfeccion_ItemInserting" OnItemUpdated="frmFichaTecnica_PasosDeConfeccion_ItemUpdated" OnDataBound="frmFichaTecnica_PasosDeConfeccion_DataBound">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label66" runat="server" Text="Paso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtNumeracion" runat="server" DataType="System.Int32" DbValue='<%# Bind("Numeracion") %>' MinValue="1" ValidationGroup="Edit_5" Width="125px">
                                                                                    <NumberFormat DecimalDigits="0" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtNumeracion" Display="Dynamic" ValidationGroup="Edit_5"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label64" runat="server" Text="Proceso / Máquina"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Edit_5" Width="500px">
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
                                                                                            </tr>
                                                                                        </table>
                                                                                    </HeaderTemplate>
                                                                                    <FooterTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" Text="Nombre"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" Text="Tipo"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" Text="Color"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" Text="Unidad de medida"></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label80" runat="server" ForeColor="Black" Text='<%# Eval("Nombre") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label81" runat="server" ForeColor="Black" Text='<%# Eval("TipoDeRecurso") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label83" runat="server" ForeColor="Black" Text='<%# Eval("UnidadDeMedida") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label82" runat="server" ForeColor="Black" Text='<%# Eval("NombreColor") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 100px;">
                                                                                                    <div id="gcColor" runat="server">
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Edit_5"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Maquinaria" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada"></asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label65" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'
                                                                                    ValidationGroup="Edit_5" Width="300px" Height="100px" MaxLength="5000" TextMode="MultiLine">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDescripcion"
                                                                                    Display="Dynamic" ValidationGroup="Edit_5"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton18" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_5" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton19" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label66" runat="server" Text="Paso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadNumericTextBox ID="txtNumeracion" runat="server" DataType="System.Int32" DbValue='<%# Bind("Numeracion") %>' MinValue="1" ValidationGroup="Insert_5" Width="125px">
                                                                                    <NumberFormat DecimalDigits="0" />
                                                                                </telerik:RadNumericTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtNumeracion" Display="Dynamic" ValidationGroup="Insert_5"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label64" runat="server" Text="Proceso / Máquina"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Insert_5" Width="500px">
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
                                                                                                <td style="width: 100px;">&nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td style="width: 100px;">
                                                                                                    <asp:Label ID="Label88" runat="server" ForeColor="Black" Text='<%# Eval("Nombre") %>'></asp:Label>
                                                                                                </td>
                                                                                                <td style="width: 80px;">
                                                                                                    <asp:Label ID="Label89" runat="server" ForeColor="Black" Text='<%# Eval("TipoDeRecurso") %>'></asp:Label>
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
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboRecursos" Display="Dynamic" ValidationGroup="Insert_5"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Maquinaria" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada"></asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label65" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'
                                                                                    ValidationGroup="Insert_5" Width="300px" Height="100px" MaxLength="5000" TextMode="MultiLine">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDescripcion"
                                                                                    Display="Dynamic" ValidationGroup="Insert_5"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton18" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_5" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton19" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_PasosDeConfeccion"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_PasosDeConfeccionFachada"
                                                                UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_PasosDeConfeccion" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_PasosDeConfeccion_Click" OnClientClick="return EliminarRegistro();"
                                                                Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_PasosDeConfeccion" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource14" OnRowCreated="gvFichaTecnica_PasosDeConfeccion_RowCreated"
                                                                OnSelectedIndexChanged="gvFichaTecnica_PasosDeConfeccion_SelectedIndexChanged">
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
                                                                            <asp:ImageButton ID="ImageButton22" runat="server" CausesValidation="False" CommandName="Select"
                                                                                ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="NombreRecurso" HeaderText="Recurso" SortExpression="NombreRecurso" />
                                                                    <asp:BoundField DataField="Descrion_HTML" HeaderText="Descripción" SortExpression="Descrion_HTML" />
                                                                    <asp:BoundField DataField="Numeracion" HeaderText="Numeración" SortExpression="Numeracion" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource14" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_PasosDeConfeccionFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvProcesosDetallados" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:FormView ID="frmFichaTecnica_ProcesosDetallados" runat="server" CssClass="CentrarElemento"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource17" DefaultMode="Insert" OnDataBound="frmFichaTecnica_ProcesosDetallados_DataBound"
                                                                OnItemInserted="frmFichaTecnica_ProcesosDetallados_ItemInserted" OnItemInserting="frmFichaTecnica_ProcesosDetallados_ItemInserting"
                                                                OnItemUpdated="frmFichaTecnica_ProcesosDetallados_ItemUpdated" OnItemUpdating="frmFichaTecnica_ProcesosDetallados_ItemUpdating">
                                                                <EditItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <asp:HiddenField ID="hdfId_Imagen" runat="server"
                                                                        Value='<%# Bind("Id_Imagen") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label75" runat="server" Text="Proceso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboProcesos" runat="server" DataSourceID="ObjectDataSource1"
                                                                                    DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Bind("Id_Proceso") %>'
                                                                                    ValidationGroup="Edit_6" Width="250px">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="cboProcesos"
                                                                                    Display="Dynamic" ValidationGroup="Edit_6"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                                    SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProcesoDeFabricacionFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label76" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="100px" MaxLength="500"
                                                                                    Text='<%# Bind("Descripcion") %>' TextMode="MultiLine" ValidationGroup="Edit_6"
                                                                                    Width="250px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtDescripcion"
                                                                                    Display="Dynamic" ValidationGroup="Edit_6"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label78" runat="server" Text="Imagen"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadBinaryImage ID="rbiImagenProceso" runat="server" Height="100px" ResizeMode="Fit"
                                                                                    Width="180px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;"></td>
                                                                            <td>
                                                                                <telerik:RadAsyncUpload ID="rauImagenProceso" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                                    MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                                                </telerik:RadAsyncUpload>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton30" runat="server" CommandName="Update" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Edit_6" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton31" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <InsertItemTemplate>
                                                                    <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                                                    <asp:HiddenField ID="hdfId_FichaTecnica" runat="server" Value='<%# Bind("Id_FichaTecnica") %>' />
                                                                    <asp:HiddenField ID="hdfId_Imagen" runat="server"
                                                                        Value='<%# Bind("Id_Imagen") %>' />
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label75" runat="server" Text="Proceso"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadComboBox ID="cboProcesos" runat="server" DataSourceID="ObjectDataSource1"
                                                                                    DataTextField="Descripcion" DataValueField="Id" SelectedValue='<%# Bind("Id_Proceso") %>'
                                                                                    Width="250px" ValidationGroup="Insert_6">
                                                                                </telerik:RadComboBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="cboProcesos"
                                                                                    Display="Dynamic" ValidationGroup="Insert_6"></asp:RequiredFieldValidator>
                                                                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                                    SelectMethod="Seleccionar_By_IdGrupoMiembros" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProcesoDeFabricacionFachada">
                                                                                    <SelectParameters>
                                                                                        <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label76" runat="server" Text="Descripción"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadTextBox ID="txtDescripcion" runat="server" Height="100px" MaxLength="500"
                                                                                    Text='<%# Bind("Descripcion") %>' TextMode="MultiLine" ValidationGroup="Insert_6"
                                                                                    Width="250px">
                                                                                </telerik:RadTextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtDescripcion"
                                                                                    Display="Dynamic" ValidationGroup="Insert_6"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">
                                                                                <asp:Label ID="Label78" runat="server" Text="Imagen"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <telerik:RadBinaryImage ID="rbiImagenProceso" runat="server" Height="100px" ResizeMode="Fit"
                                                                                    Width="180px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;"></td>
                                                                            <td>
                                                                                <telerik:RadAsyncUpload ID="rauImagenProceso" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                                    MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                                                </telerik:RadAsyncUpload>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: right;">&nbsp;</td>
                                                                            <td>
                                                                                <asp:Label ID="Label50" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="CentrarElemento">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton30" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                                    ValidationGroup="Insert_6" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="ImageButton31" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    ImageUrl="~/Recursos/Diseno/Iconos/Cancelar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </InsertItemTemplate>
                                                            </asp:FormView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource17" runat="server" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica_ProcesosDetallados"
                                                                InsertMethod="Guardar" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_Id"
                                                                TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ProcesosDetalladosFachada"
                                                                UpdateMethod="Actualizar">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="Id" Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="btnEliminar_ProcesosDetallados" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Eliminar.png"
                                                                OnClick="btnEliminar_ProcesosDetallados_Click" OnClientClick="return EliminarRegistro();"
                                                                Style="padding-left: 20px;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFichaTecnica_ProcesosDetallados" runat="server" AutoGenerateColumns="False"
                                                                DataKeyNames="Id" DataSourceID="ObjectDataSource18" OnRowCreated="gvFichaTecnica_ProcesosDetallados_RowCreated"
                                                                OnSelectedIndexChanged="gvFichaTecnica_ProcesosDetallados_SelectedIndexChanged">
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
                                                                            <asp:ImageButton ID="ImageButton32" runat="server" CausesValidation="False" CommandName="Select"
                                                                                ImageUrl="~/Recursos/Diseno/Iconos/Editar.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                                                    <asp:BoundField DataField="Id_FichaTecnica" HeaderText="Id_FichaTecnica" SortExpression="Id_FichaTecnica"
                                                                        Visible="False" />
                                                                    <asp:BoundField DataField="Proceso" HeaderText="Proceso de fabricación" SortExpression="Proceso" />
                                                                    <asp:BoundField DataField="DescripcionHTML" HeaderText="Descripción" SortExpression="DescripcionHTML" />
                                                                    <asp:TemplateField HeaderText="Imagen">
                                                                        <ItemTemplate>
                                                                            <telerik:RadBinaryImage ID="rbiImagenProceso" runat="server" Height="100px" ResizeMode="Fit"
                                                                                Width="180px" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ObjectDataSource18" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                SelectMethod="Seleccionar_By_FichaTecnica" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.FichaTecnica_ProcesosDetalladosFachada">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdfId" Name="Id_FichaTecnica" PropertyName="Value"
                                                                        Type="Int64" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <asp:HiddenField ID="hdfId_GrupoDeMiembros" runat="server" Value='<%# Eval("Id_GrupoDeMiembros") %>' />
                                        <asp:HiddenField ID="hdfId_Imagen" runat="server" Value='<%# Bind("Id_Imagen") %>' />
                                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="rmpInsertar" SelectedIndex="0">
                                            <Tabs>
                                                <telerik:RadTab runat="server" PageViewID="rpvFichaTecnica" Selected="True" Text="Cabecera">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvInstruccionesConstruccion" Text="Instrucciones de confección" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvAyudasTecnicas" Text="Ayudas técnicas" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvInstruccionesCostura" Text="Instrucciones de costura" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvEspecificacionPlancha" Text="Especificación de plancha" Visible="False">
                                                </telerik:RadTab>
                                                <telerik:RadTab runat="server" PageViewID="rpvEspecificacionMaquina" Text="Especificación de máquina" Visible="False">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpInsertar" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="rpvFichaTecnica" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label14" runat="server" Text="Referencia"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTipoDePrenda" runat="server" MaxLength="50" Text='<%# Bind("Codigo") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="txtTipoDePrenda" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label15" runat="server" Text="Nombre de la prenda"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCodigo" runat="server" MaxLength="100" Text='<%# Bind("TipoPrenda") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="txtCodigo" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label16" runat="server" Text="Fecha de creación"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadDatePicker ID="dpFechaCreacion" runat="server" DbSelectedDate='<%# Bind("FechaActualizacion") %>'>
                                                            </telerik:RadDatePicker>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dpFechaCreacion" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label17" runat="server" Text="Material principal"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTela" runat="server" MaxLength="100" Text='<%# Bind("Tela") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label18" runat="server" Text="Material secundario"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTelaComplemento" runat="server" MaxLength="100" Text='<%# Bind("TelaComplemento") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtDecripcion" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("Descripccion") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label19" runat="server" Text="Imagen"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadBinaryImage ID="rbiImagenPrenda" runat="server" Height="300px" Width="250px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;"></td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadAsyncUpload ID="rauImagenPrenda" runat="server" AllowedFileExtensions="jpg,jpeg,gif"
                                                                MaxFileInputsCount="1" MaxFileSize="524288" MultipleFileSelection="Disabled" Width="220px">
                                                            </telerik:RadAsyncUpload>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">&nbsp;</td>
                                                        <td style="text-align: left;">
                                                            <asp:Label ID="Label50" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center;">
                                                            <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" ImageUrl="~/Recursos/Diseno/Iconos/Ok.png"
                                                                ValidationGroup="Insert" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvInstruccionesConstruccion" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label20" runat="server" Text="Coser cerrado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCoserCerrado" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICCoserCerrado") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label21" runat="server" Text="Coser pespunteado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCoserPespunteado" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICCoserPesPunteado") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label22" runat="server" Text="Tipo de puntas de la recubridora"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntasRecubridora" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICTipoRecubridora") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label23" runat="server" Text="Aguja número"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtAgujaNumero" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICAgujaNro") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label49" runat="server" Text="Piezas fusionadas"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPiezasFucionadas" runat="server" Height="80px" MaxLength="200"
                                                                Text='<%# Bind("ICPiezasFusionadas") %>' TextMode="MultiLine" ValidationGroup="Insert"
                                                                Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label12" runat="server" Text="Puntadas por pulgada, cerrado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntadasPulgaCerrada" runat="server" MaxLength="50" Text='<%# Bind("ICPuntadasPorPulgadaCerrado") %>'
                                                                ValidationGroup="Insert" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label13" runat="server" Text="Puntadas por pulgada, pespunteado"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPuntadasPulgaPespunteado" runat="server" MaxLength="50"
                                                                Text='<%# Bind("ICPuntadasPorPulgadaPespunteado") %>' ValidationGroup="Insert"
                                                                Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label24" runat="server" Text="Cuales"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCuales" runat="server" Height="80px" MaxLength="200" Text='<%# Bind("ICCuales") %>'
                                                                TextMode="MultiLine" ValidationGroup="Insert" Width="250px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvAyudasTecnicas" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label27" runat="server" Text="Pies"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPies" runat="server" MaxLength="100" Text='<%# Bind("ATPies") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label28" runat="server" Text="Folderes"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtFolderes" runat="server" MaxLength="100" Text='<%# Bind("ATFolders") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label29" runat="server" Text="Plantillas"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPlantillas" runat="server" MaxLength="100" Text='<%# Bind("ATPlantillas") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvInstruccionesCostura" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label31" runat="server" Text="Costura cubierta"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaCubierta" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasAbiertas") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label32" runat="server" Text="Costura con pespunte"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaConPespunte" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasConPespunte") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label33" runat="server" Text="Costura cerrada"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtCosturaCerrada" runat="server" MaxLength="100" Text='<%# Bind("ICOCosturasCerradas") %>'
                                                                ValidationGroup="Insert" Width="200px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvEspecificacionPlancha" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label39" runat="server" Text="Plancha"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtPlancha" runat="server" MaxLength="50" Text='<%# Bind("PLPlancha") %>'
                                                                ValidationGroup="Insert" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label40" runat="server" Text="Vaporización"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtVaporizacion" runat="server" MaxLength="50" Text='<%# Bind("PLVaporizacion") %>'
                                                                ValidationGroup="Insert" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="rpvEspecificacionMaquina" runat="server">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label44" runat="server" Text="Recubridora"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkRecubridora" runat="server" Checked='<%# Bind("EMRecubridora") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label43" runat="server" Text="Plana"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkPlana" runat="server" Checked='<%# Bind("EMPLana") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label45" runat="server" Text="Filete sencillo"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteSencillo" runat="server" Checked='<%# Bind("EMFileteSencillo") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label46" runat="server" Text="Filetes especiales"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteEspecial" runat="server" Checked='<%# Bind("EMEspeciales") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label47" runat="server" Text="Tipo de ajuste"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtTipoAjuste" runat="server" MaxLength="50" Text='<%# Bind("EMTipoAjuste") %>'
                                                                ValidationGroup="Insert" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label42" runat="server" Text="Ancho"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadTextBox ID="txtAncho" runat="server" MaxLength="50" Text='<%# Bind("EMAncho") %>'
                                                                ValidationGroup="Insert" Width="125px">
                                                            </telerik:RadTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right;">
                                                            <asp:Label ID="Label48" runat="server" Text="Filete con seguridad"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox ID="chkFileteSeguridad" runat="server" Checked='<%# Bind("EMFileteConseguridad") %>' />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
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
