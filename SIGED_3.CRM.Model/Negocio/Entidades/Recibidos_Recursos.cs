using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Entidades
{
    public partial class Recibidos_Recursos
    {
        public string OrdenLigada
        {
            get
            {
                if (Id_OrdenesDeTrabajo_Recurso.HasValue)
                {
                    return new OrdenesDeTrabajoOAD().Seleccionar_Id(new OrdenesDeTrabajo_RecursosOAD().Seleccionar_Id(Id_OrdenesDeTrabajo_Recurso.Value).Id_Recurso.Value).Consecutivo.ToString();
                }
                else
                {
                    return "No vinculado";
                }
            }
        }
        //public string ObservacionesDelDetalle
        //{
        //    get
        //    {
        //        if (Id_Pedido_Detalle.HasValue)
        //        {
        //            return new Pedido_DetalleOAD().Seleccionar_Id(Id_Pedido_Detalle.Value).Observaciones;
        //        }
        //        else
        //        {
        //            return "No vinculado";
        //        }
        //    }
        //}
    }
}
