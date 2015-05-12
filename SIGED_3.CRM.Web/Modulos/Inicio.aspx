<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal_NoSearch.Master" AutoEventWireup="true"
    CodeBehind="Inicio.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="MsoNormal">
        <asp:GridView ID="gvNoticias" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="FechaPublicacion" DataFormatString="{0:d}" HeaderText="Fecha" SortExpression="FechaPublicacion" />
                <asp:TemplateField HeaderText="Miembro" SortExpression="NombreMiembro">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NombreMiembro") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNombrePersona" runat="server" Text='<%# Bind("NombreMiembro") %>'></asp:Label>
                        <br />
                        <asp:Label ID="lblRol" runat="server" ForeColor="Black" Text='<%# Bind("Rol") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publicación" SortExpression="Publicacion">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Publicacion") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPublicacion" runat="server" ForeColor="Black" Text='<%# Bind("Publicacion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Seleccionar_LP" TypeName="SIGED_3.CRM.Model.Servicios.Fachadas.PublicacionesFachada"></asp:ObjectDataSource>
    </p>
</asp:Content>
