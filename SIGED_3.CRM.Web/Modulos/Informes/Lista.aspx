<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Ppal_NoSearch.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="SIGED_3.CRM.Web.Modulos.Informes.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="Label5" runat="server" Text="Maestro de informes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label4" runat="server" Text="Ir a"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Compras</td>
            <td>Informe de compras.</td>
            <td align="center">
                <asp:ImageButton ID="btnCompras" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" Height="24px" />
            </td>
        </tr>
        <tr>
            <td>Plan de Compras </td>
            <td>El plan de compras resume en el ámbito de Pedidos y Recursos, lo que se necesita para uno o varios pedidos que se encuentran actualmente activos.<br />
                Esto nos sirve para determinar que necesitamos para fabricar determinado número de Productos y así poder tomar decisiones asertivas en producción. </td>
            <td align="center">
                <asp:ImageButton ID="btnPlanCompras" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" Height="24px" />
            </td>
        </tr>
        <tr>
            <td>Pedidos </td>
            <td>Muestra un resumen de todos los pedidos activos en el sistema. Complementa con la información de aquellos ítems que ya se han despachado. </td>
            <td align="center">
                <asp:ImageButton ID="btnPedidos" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" OnClientClick="openWin('0');" />
            </td>
        </tr>
        <tr>
            <td>Ordenes de trabajo </td>
            <td>Muestra un resumen de todas las Ordenes de trabajo.</td>
            <td align="center">
                <asp:ImageButton ID="btnDespachos" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Costos </td>
            <td>Obtenga un listado de todas las fichas técnicas y su planilla de costos (Recursos, Procesos y Valorización) por color. </td>
            <td align="center">
                <asp:ImageButton ID="btnCostos" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Ventas </td>
            <td>Obtenga un listado de la 100 ultimas ventas en el sistema, actualmente trabaja sobre visualización móvil, es posible que requiera aumentar el tamaño de la página un poco para verlo. </td>
            <td align="center">
                <asp:ImageButton ID="btnVentas" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Lista de precios de productos </td>
            <td>Obtenga la lista de precios de sus productos, contiene los 3 precios actualmente definidos en el sistema de costos. </td>
            <td align="center">
                <asp:ImageButton ID="btnListaPrecios" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Lista de precios para el cliente. </td>
            <td>Obtenga un listado de sus productos junto con una columna de precio. Usted puede definir que precio quiere mostrar para todos los productos. </td>
            <td align="center">
                <asp:ImageButton ID="btnListaPreciosCliente" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Inventario </td>
            <td>Obtenga un informe de su lista de inventario, que tiene en donde lo tiene y cuanto tiene. </td>
            <td align="center">
                <asp:ImageButton ID="btnInventario" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
        <tr>
            <td>Utilidad </td>
            <td>Obtenga un informe de utilidades en un rango de fechas asignado, cuanto se ha vendido, que he vendido, cual fue mi utilidad, ademas del costo. </td>
            <td align="center">
                <asp:ImageButton ID="btnUtilidad" runat="server" ImageUrl="~/Recursos/Diseno/Iconos/Ir A.png" />
            </td>
        </tr>
    </table>
</asp:Content>
