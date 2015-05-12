using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class OrdenesDeTrabajo_Recursos
    {
        public string PedidoLigado
        {
            get
            {
                if (Id_Pedido_Detalle.HasValue)
                {
                    return new PedidoOAD().Seleccionar_Id(new Pedido_DetalleOAD().Seleccionar_Id(Id_Pedido_Detalle.Value).Id_Pedido.Value).Consecutivo.ToString();
                }
                else
                {
                    return "No vinculado";
                }
            }
        }
        public string ObservacionesDelDetalle
        {
            get
            {
                if (Id_Pedido_Detalle.HasValue)
                {
                    return new Pedido_DetalleOAD().Seleccionar_Id(Id_Pedido_Detalle.Value).Observaciones;
                }
                else
                {
                    return "No vinculado";
                }
            }
        }
    }
}
