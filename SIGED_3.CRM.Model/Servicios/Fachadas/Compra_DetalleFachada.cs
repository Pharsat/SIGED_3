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
    public class Compra_DetalleFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra_Detalle> Seleccionar_All()
        {
            Compra_DetalleLN objCompra_Detalle = new Compra_DetalleLN();
            return objCompra_Detalle.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra_Detalle Seleccionar_Id(long Id)
        {
            Compra_DetalleLN objCompra_Detalle = new Compra_DetalleLN();
            return objCompra_Detalle.Seleccionar_Id(Id);
        }
        public List<LS_Compra_DetalleResult> Seleccionar_By_Compra_LP(long Id_Compra)
        {
            Compra_DetalleLN objCompra_Detalle = new Compra_DetalleLN();
            return objCompra_Detalle.Seleccionar_By_Compra_LP(Id_Compra);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra_Detalle objCompra_Detalle)
        {
            Compra_DetalleLN _objCompra_Detalle = new Compra_DetalleLN();
            _objCompra_Detalle.Guardar(objCompra_Detalle);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Compra_Detalle objCompra_Detalle)
        {
            Compra_DetalleLN _objCompra_Detalle = new Compra_DetalleLN();
            _objCompra_Detalle.Eliminar(objCompra_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra_Detalle objCompra_Detalle)
        {
            Compra_DetalleLN _objCompra_Detalle = new Compra_DetalleLN();
            _objCompra_Detalle.Actualizar(objCompra_Detalle);
        }
    }
}