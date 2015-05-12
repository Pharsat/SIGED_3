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
    public class PedidoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pedido> Seleccionar_All()
        {
            PedidoLN objPedido = new PedidoLN();
            return objPedido.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pedido Seleccionar_Id(long Id)
        {
            PedidoLN objPedido = new PedidoLN();
            return objPedido.Seleccionar_Id(Id);
        }
        /// <summary>
        /// retorna la lista de pedidos del sistema
        /// </summary>
        /// <param name="estado">estado del pedido</param>
        /// <param name="id_GrupoDeMiembros">grupo de miembros del pedido</param>
        /// <param name="id_Cliente">cliente que hace el pedido</param>
        /// <param name="tipoPrenda">nombre prenda</param>
        /// <param name="consecutivo">consecutivo de la prenda</param>
        /// <param name="desdeFP">fecha pedido</param>
        /// <param name="hastaFP">fecha pedido</param>
        /// <param name="desdeFR">fecha realizacion</param>
        /// <param name="hastaFR">fecha realizacion</param>
        /// <param name="desdeFD">fecha despachar</param>
        /// <param name="hastaFD">fecha despachar</param>
        /// <returns>lista de pedidos del sistema</returns>
        public List<LP_PedidosResult> Seleccionar_LP(long? estado, long? id_GrupoDeMiembros, long? id_Cliente, string tipoPrenda, string consecutivo, DateTime? desdeFP, DateTime? hastaFP, DateTime? desdeFR, DateTime? hastaFR, DateTime? desdeFD, DateTime? hastaFD)
        {
            PedidoLN objPedido = new PedidoLN();
            return objPedido.Seleccionar_LP(estado, id_GrupoDeMiembros, id_Cliente, tipoPrenda, consecutivo, desdeFP, hastaFP, desdeFR, hastaFR, desdeFD, hastaFD);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pedido objPedido)
        {
            PedidoLN _objPedido = new PedidoLN();
            _objPedido.Guardar(objPedido);
        }
        /// <summary>
        /// Guarda el objeto Pedido y obtiene su Id
        /// </summary>
        /// <param name="objPedido">Licnete a guardar</param>
        public long Guardar_2(Pedido objPedido)
        {
            PedidoLN _objPedido = new PedidoLN();
            return _objPedido.Guardar_2(objPedido);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pedido objPedido)
        {
            PedidoLN _objPedido = new PedidoLN();
            _objPedido.Eliminar(objPedido);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pedido objPedido)
        {
            PedidoLN _objPedido = new PedidoLN();
            _objPedido.Actualizar(objPedido);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla pedidos
        /// </summary>
        /// <returns>Lista de registros tipo pedidos que no hallan sido ordenados en su totalidad</returns>
        public List<Pedido> Seleccionar_All_NoOrdenados()
        {
            PedidoLN _objPedido = new PedidoLN();
            return _objPedido.Seleccionar_All_NoOrdenados();
        }
        public List<R_PedidosResult> RelatorioDePedidos(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            PedidoLN _objPedido = new PedidoLN();
            return _objPedido.RelatorioDePedidos(Consecutivo, id_GrupoDeMiembros);
        }
        public List<R_PlanDeComprasResult> RelatorioDePlanDeCompras(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            PedidoLN _objPedido = new PedidoLN();
            return _objPedido.RelatorioDePlanDeCompras(Consecutivo, id_GrupoDeMiembros);
        }
    }
}