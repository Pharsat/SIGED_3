using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class PedidoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Pedido> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pedido.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Pedido Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pedido.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                id_Cliente = id_Cliente == 0 ? null : id_Cliente;
                return dc.LP_Pedidos(estado, id_GrupoDeMiembros, id_Cliente, tipoPrenda, consecutivo, desdeFP, hastaFP, desdeFR, hastaFR, desdeFD, hastaFD).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Pedido objPedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Pedido.InsertOnSubmit(objPedido);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Pedido y obtiene su Id
        /// </summary>
        /// <param name="objPedido">Licnete a guardar</param>
        public long Guardar_2(Pedido objPedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Pedido.InsertOnSubmit(objPedido);
                dc.SubmitChanges();
                return dc.Pedido.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Pedido objPedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pedido _objPedido = dc.Pedido.Single(p => p.Id == objPedido.Id);
                dc.Pedido.DeleteOnSubmit(_objPedido);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Pedido objPedido)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Pedido _objPedido = dc.Pedido.Single(p => p.Id == objPedido.Id);
                _objPedido.Id = objPedido.Id;
                _objPedido.Id_GrupoDeMiembros = objPedido.Id_GrupoDeMiembros;
                _objPedido.Id_Cliente = objPedido.Id_Cliente;
                _objPedido.Id_Miembro = objPedido.Id_Miembro;
                _objPedido.Consecutivo = objPedido.Consecutivo;
                _objPedido.FechaDerealizacion = objPedido.FechaDerealizacion;
                _objPedido.FechaDePedido = objPedido.FechaDePedido;
                _objPedido.FechaADespachar = objPedido.FechaADespachar;
                _objPedido.TipoPrecioVenta = objPedido.TipoPrecioVenta;
                _objPedido.Estado = objPedido.Estado;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla pedidos
        /// </summary>
        /// <returns>Lista de registros tipo pedidos que no hallan sido ordenados en su totalidad</returns>
        public List<Pedido> Seleccionar_All_NoOrdenados()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Pedido.Where(p => p.Estado != (long)EstadosDelProceso_Enum.TERMI && p.Id_GrupoDeMiembros == SessionManager.Id_GrupoDeMiembros && dc.Pedido_Detalle.Where(pd => (pd.Cantidad - (dc.OrdenesDeTrabajo_Recursos.Any(odtr => odtr.Id_Pedido_Detalle == pd.Id) ? (dc.OrdenesDeTrabajo_Recursos.Where(odtr => odtr.Id_Pedido_Detalle == pd.Id).Sum(odtr => odtr.Cantidad)) : 0)) > 0).Select(pd => pd.Id_Pedido).Distinct().Contains(p.Id)).ToList();
            }
        }
        public List<R_PedidosResult> RelatorioDePedidos(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Pedidos(Consecutivo, id_GrupoDeMiembros).ToList();
            }
        }
        public List<R_PlanDeComprasResult> RelatorioDePlanDeCompras(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_PlanDeCompras(Consecutivo, id_GrupoDeMiembros).ToList();
            }
        }
    }
}