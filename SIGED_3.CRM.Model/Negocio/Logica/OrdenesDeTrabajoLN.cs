using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class OrdenesDeTrabajoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<OrdenesDeTrabajo> Seleccionar_All()
        {
            OrdenesDeTrabajoOAD objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            return objOrdenesDeTrabajo.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public OrdenesDeTrabajo Seleccionar_Id(long Id)
        {
            OrdenesDeTrabajoOAD objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            return objOrdenesDeTrabajo.Seleccionar_Id(Id);
        }
        public List<LP_OrdenesDeTrabajoResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            OrdenesDeTrabajoOAD objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            if (id_Cliente.HasValue)
            {
                if (id_Cliente.Value.ToString() == (0).ToString())
                {
                    id_Cliente = null;
                }
            }
            return objOrdenesDeTrabajo.Seleccionar_LP(estado, id_Cliente, consecutivo, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoOAD _objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            _objOrdenesDeTrabajo.Guardar(objOrdenesDeTrabajo);
        }
        /// <summary>
        /// Guarda el objeto OrdenesDeTrabajo y obtiene su Id
        /// </summary>
        /// <param name="objOrdenesDeTrabajo">Licnete a guardar</param>
        public long Guardar_2(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            try
            {
                long Id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    OrdenesDeTrabajoOAD _objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
                    objOrdenesDeTrabajo.Consecutivo = new ConsecutivosLN().TomarConsecutivo((long)Modulo_Enum.Ordenesdetrabajo, objOrdenesDeTrabajo.Id_GrupoDeMiembros.Value);
                    objOrdenesDeTrabajo.Id_Estado = (long)EstadosDelProceso_Enum.REGIS;
                    objOrdenesDeTrabajo.Id_Solicitante = SessionManager.Id_Miembro.Value;
                    Id = _objOrdenesDeTrabajo.Guardar_2(objOrdenesDeTrabajo);
                    objTransacion.Complete();
                }
                return Id;
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
        public void Eliminar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoOAD _objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            _objOrdenesDeTrabajo.Eliminar(objOrdenesDeTrabajo);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoOAD _objOrdenesDeTrabajo = new OrdenesDeTrabajoOAD();
            _objOrdenesDeTrabajo.Actualizar(objOrdenesDeTrabajo);
        }
        public void IncluirAOrdenPedidosDetalles(long Id_Pedido, long Id_OrdenDeTrabajo)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    List<Pedido_Detalle> lstPedidoDetalle = new Pedido_DetalleOAD().Seleccionar_By_Pedido(Id_Pedido).ToList();
                    foreach (Pedido_Detalle objPedidoDetalle in lstPedidoDetalle)
                    {
                        new OrdenesDeTrabajo_RecursosOAD().IncluirAOrdenPedidosDetalles(objPedidoDetalle, Id_OrdenDeTrabajo);
                    }
                    objTransacion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<OrdenesDeTrabajo> Seleccionar_All_NoRecibidos()
        {
            OrdenesDeTrabajoOAD _objPedido = new OrdenesDeTrabajoOAD();
            return _objPedido.Seleccionar_All_NoRecibidos();
        }
        public List<R_OrdenesDeTrabajoResult> RelatorioDeOrdenesDeTrabajo(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            OrdenesDeTrabajoOAD _objOrden = new OrdenesDeTrabajoOAD();
            return _objOrden.RelatorioDeOrdenesDeTrabajo(Consecutivo, id_GrupoDeMiembros);
        }
    }
}