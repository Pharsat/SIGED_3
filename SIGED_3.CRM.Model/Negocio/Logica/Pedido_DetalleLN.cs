using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Pedido_DetalleLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pedido_Detalle> Seleccionar_All()
        {
            Pedido_DetalleOAD objPedido_Detalle = new Pedido_DetalleOAD();
            return objPedido_Detalle.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pedido_Detalle Seleccionar_Id(long Id)
        {
            Pedido_DetalleOAD objPedido_Detalle = new Pedido_DetalleOAD();
            return objPedido_Detalle.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Obtiene todos los contactos de un Pedido
        /// </summary>
        /// <param name="Id_Pedido">Identificativo del Pedido</param>
        /// <returns>Lista de los contactos del Pedido</returns>
        public List<Pedido_Detalle> Seleccionar_By_Pedido(long Id_Pedido)
        {
            Pedido_DetalleOAD objPedido_Detalle = new Pedido_DetalleOAD();
            return objPedido_Detalle.Seleccionar_By_Pedido(Id_Pedido);
        }
        /// <summary>
        /// Trae todos los pedido detalle ya con su lista.
        /// </summary>
        /// <param name="Id_Pedido">id del pedido padre</param>
        /// <returns>lista de detalles de pedido</returns>
        public List<LS_Pedido_DetalleResult> Seleccionar_By_Pedido_LP(long Id_Pedido)
        {
            Pedido_DetalleOAD objPedido_Detalle = new Pedido_DetalleOAD();
            return objPedido_Detalle.Seleccionar_By_Pedido_LP(Id_Pedido);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pedido_Detalle objPedido_Detalle)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Pedido_DetalleOAD _objPedido_Detalle = new Pedido_DetalleOAD();
                    UnidadDeMedida objUnidadDeMedidaAConvertir = new UnidadDeMedidaLN().Seleccionar_Id(objPedido_Detalle.Id_UnidadDeMedida.Value);
                    UnidadDeMedida objUnidadDeMedidaOrigen = new UnidadDeMedidaLN().Seleccionar_Id(new RecursoLN().Seleccionar_Id(objPedido_Detalle.Id_Recurso.Value).Id_UnidadDeMedida.Value);
                    objPedido_Detalle.Cantidad = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objPedido_Detalle.Cantidad.Value, objUnidadDeMedidaOrigen);
                    objPedido_Detalle.ValorUnitario = new Genericos().ConvercionDeUnidadesValor(objUnidadDeMedidaAConvertir, objPedido_Detalle.ValorUnitario.Value, objUnidadDeMedidaOrigen);
                    Pedido objPedido = new PedidoLN().Seleccionar_Id(objPedido_Detalle.Id_Pedido.Value);
                    objPedido.Id_Miembro = SessionManager.Id_Miembro;
                    new PedidoLN().Actualizar(objPedido);
                    _objPedido_Detalle.Guardar(objPedido_Detalle);
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pedido_Detalle objPedido_Detalle)
        {
            Pedido_DetalleOAD _objPedido_Detalle = new Pedido_DetalleOAD();
            _objPedido_Detalle.Eliminar(objPedido_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pedido_Detalle objPedido_Detalle)
        {
            Pedido_DetalleOAD _objPedido_Detalle = new Pedido_DetalleOAD();
            _objPedido_Detalle.Actualizar(objPedido_Detalle);
        }
    }
}