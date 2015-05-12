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
    public class Pedido_DetalleFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pedido_Detalle> Seleccionar_All()
        {
            Pedido_DetalleLN objPedido_Detalle = new Pedido_DetalleLN();
            return objPedido_Detalle.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pedido_Detalle Seleccionar_Id(long Id)
        {
            Pedido_DetalleLN objPedido_Detalle = new Pedido_DetalleLN();
            return objPedido_Detalle.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Obtiene todos los contactos de un Pedido
        /// </summary>
        /// <param name="Id_Pedido">Identificativo del Pedido</param>
        /// <returns>Lista de los contactos del Pedido</returns>
        public List<Pedido_Detalle> Seleccionar_By_Pedido(long Id_Pedido)
        {
            Pedido_DetalleLN objPedido_Detalle = new Pedido_DetalleLN();
            return objPedido_Detalle.Seleccionar_By_Pedido(Id_Pedido);
        }
        /// <summary>
        /// Trae todos los pedido detalle ya con su lista.
        /// </summary>
        /// <param name="Id_Pedido">id del pedido padre</param>
        /// <returns>lista de detalles de pedido</returns>
        public List<LS_Pedido_DetalleResult> Seleccionar_By_Pedido_LP(long Id_Pedido)
        {
            Pedido_DetalleLN objPedido_Detalle = new Pedido_DetalleLN();
            return objPedido_Detalle.Seleccionar_By_Pedido_LP(Id_Pedido);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pedido_Detalle objPedido_Detalle)
        {
            Pedido_DetalleLN _objPedido_Detalle = new Pedido_DetalleLN();
            _objPedido_Detalle.Guardar(objPedido_Detalle);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pedido_Detalle objPedido_Detalle)
        {
            Pedido_DetalleLN _objPedido_Detalle = new Pedido_DetalleLN();
            _objPedido_Detalle.Eliminar(objPedido_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pedido_Detalle objPedido_Detalle)
        {
            Pedido_DetalleLN _objPedido_Detalle = new Pedido_DetalleLN();
            _objPedido_Detalle.Actualizar(objPedido_Detalle);
        }
    }
}