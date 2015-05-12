using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class Venta_DetalleFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta_Detalle> Seleccionar_All()
        {
            Venta_DetalleLN objVenta_Detalle = new Venta_DetalleLN();
            return objVenta_Detalle.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta_Detalle Seleccionar_Id(long Id)
        {
            Venta_DetalleLN objVenta_Detalle = new Venta_DetalleLN();
            return objVenta_Detalle.Seleccionar_Id(Id);
        }
        public List<LS_Venta_DetalleResult> Seleccionar_By_Venta_LP(long Id_Venta)
        {
            Venta_DetalleLN objVenta_Detalle = new Venta_DetalleLN();
            return objVenta_Detalle.Seleccionar_By_Venta_LP(Id_Venta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta_Detalle objVenta_Detalle)
        {
            Venta_DetalleLN _objVenta_Detalle = new Venta_DetalleLN();
            _objVenta_Detalle.Guardar(objVenta_Detalle);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Venta_Detalle objVenta_Detalle)
        {
            Venta_DetalleLN _objVenta_Detalle = new Venta_DetalleLN();
            _objVenta_Detalle.Eliminar(objVenta_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta_Detalle objVenta_Detalle)
        {
            Venta_DetalleLN _objVenta_Detalle = new Venta_DetalleLN();
            _objVenta_Detalle.Actualizar(objVenta_Detalle);
        }
    }
}