<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal_NoSearch.Master" AutoEventWireup="true"
    CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.GrupoDeMiembros.Lista" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>.: Grupo de Miembros :.</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FormulariosTextos" style="width: 100%">
        <table class="CentrarElemento" style="width: 100%">
            <thead>
                <tr>
                    <th>Grupo de Miembros<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="Seleccionar_Id"
                        TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.GrupoDeMiembrosFachada" DataObjectTypeName="SIGED_3.CRM.Model.Negocio.Entidades.GrupoDeMiembros"
                        UpdateMethod="Actualizar">
                        <SelectParameters>
                            <asp:SessionParameter Name="Id" SessionField="IdGM" Type="Int64" />
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
                                <asp:FormView ID="frmPpal" runat="server" DataSourceID="ObjectDataSource1"
                                    DefaultMode="Insert" OnItemUpdating="frmPpal_ItemUpdating"
                                    OnDataBound="frmPpal_DataBound" OnItemUpdated="frmPpal_ItemUpdated">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hdfId" runat="server" Value='<%# Bind("Id") %>' />
                                        <asp:HiddenField ID="hdfId_Imagen" runat="server" Value='<%# Bind("Id_Imagen") %>' />
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="Etiquetas" Text="País"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboPais" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                        DataTextField="Nombre" DataValueField="Id" SelectedValue='<%# Bind("Id_Pais") %>'
                                                        ValidationGroup="Update" CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cboPais"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_All" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PaisFachada"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" Text="Provincia" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboProvincia" runat="server" DataSourceID="ObjectDataSource2"
                                                        DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" ValidationGroup="Update"
                                                        CausesValidation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboProvincia"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_PorPais" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.ProvinciaFachada">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="cboPais" Name="Id_Pais" PropertyName="SelectedValue"
                                                                Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label3" runat="server" Text="Ciudad" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadComboBox ID="cboCiudad" runat="server" DataSourceID="ObjectDataSource3"
                                                        DataTextField="Nombre" DataValueField="Id" ValidationGroup="Update" ChangeTextOnKeyBoardNavigation="False">
                                                    </telerik:RadComboBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cboCiudad"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="Seleccionar_PorProvincia" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.CiudadFachada">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="cboProvincia" Name="Id_Provincia" PropertyName="SelectedValue"
                                                                Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="NombreTextBox" runat="server" MaxLength="50" Text='<%# Bind("Nombre") %>'
                                                        Width="125px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NombreTextBox"
                                                        Display="Dynamic"  ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label5" runat="server" Text="Descripción" CssClass="Etiquetas"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadTextBox ID="DecripcionTextBox" runat="server" Height="80px" MaxLength="200"
                                                        Text='<%# Bind("Descripcion") %>' TextMode="MultiLine" Width="250px" ValidationGroup="Update">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Etiquetas" Text="Imagen"></asp:Label>
                                                </td>
                                                <td style="text-align: left;">
                                                    <telerik:RadBinaryImage ID="rbiImagenGrupo" runat="server" Height="200px" Width="400px"
                                                        ResizeMode="Fit" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;"></td>
                                                <td style="text-align: left;">
                                                    <telerik:RadAsyncUpload ID="rauImagenGrupo" MultipleFileSelection="Disabled" runat="server"
                                                        AllowedFileExtensions="jpg,jpeg,gif" Width="220px" MaxFileInputsCount="1" MaxFileSize="524288">
                                                    </telerik:RadAsyncUpload>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right;"></td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label9" runat="server">Extensiones permitidas: jpg, jpeg, gif. Tamaño máximo: 500Kb.</asp:Label>
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
