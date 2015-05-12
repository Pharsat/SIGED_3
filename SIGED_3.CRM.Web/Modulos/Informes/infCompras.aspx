<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Reports.Master" AutoEventWireup="true" CodeBehind="infCompras.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Informes.infConpras" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <table class="CentrarElemento">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Desde"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="dtDesde" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Hasta"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="dtHasta" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Proveedor"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboProveedor" Runat="server" DataSourceID="ObjectDataSource1" DataTextField="Nombre" DataValueField="Id" Width="200px" OnDataBound="cboProveedor_DataBound">
                            </telerik:RadComboBox>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_All_Activos" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProveedorFachada">
                                <SelectParameters>
                                    <asp:SessionParameter Name="Id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                    <asp:Parameter Name="Id_Proveedor" Type="Int64" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Recurso"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cboRecursos" runat="server" DataSourceID="ObjectDataSource2" DataTextField="NombreRecurso" DataValueField="Id" Filter="Contains" HighlightTemplatedItems="True" OnItemDataBound="cboColores_ItemDataBound" SelectedValue='<%# Bind("Id_Recurso") %>' ValidationGroup="Insert_2" Width="600px" AutoPostBack="True" OnDataBound="cboRecursos_DataBound">
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
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LC_2" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.RecursoFachada">
                                <SelectParameters>
                                    <asp:SessionParameter Name="id_GrupoDeMiembros" SessionField="IdGM" Type="Int64" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:ImageButton ID="btnGenerar" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/custom-reports-icon.png" OnClick="btnGenerar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="rptViewer" runat="server" Height="1133px" Width="944px" BackColor="White">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
