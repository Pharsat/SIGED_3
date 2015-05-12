using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class OrdenesDeTrabajo_RecursosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<OrdenesDeTrabajo_Recursos> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.OrdenesDeTrabajo_Recursos.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public OrdenesDeTrabajo_Recursos Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.OrdenesDeTrabajo_Recursos.Any(p => p.Id == Id))
                {
                    return dc.OrdenesDeTrabajo_Recursos.Single(p => p.Id == Id);
                }
                else
                {
                    return new OrdenesDeTrabajo_Recursos();
                }
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.OrdenesDeTrabajo_Recursos.InsertOnSubmit(objOrdenesDeTrabajo_Recursos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                OrdenesDeTrabajo_Recursos _objOrdenesDeTrabajo_Recursos = dc.OrdenesDeTrabajo_Recursos.Single(p => p.Id == objOrdenesDeTrabajo_Recursos.Id);
                dc.OrdenesDeTrabajo_Recursos.DeleteOnSubmit(_objOrdenesDeTrabajo_Recursos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                OrdenesDeTrabajo_Recursos _objOrdenesDeTrabajo_Recursos = dc.OrdenesDeTrabajo_Recursos.Single(p => p.Id == objOrdenesDeTrabajo_Recursos.Id);
                _objOrdenesDeTrabajo_Recursos.Id = objOrdenesDeTrabajo_Recursos.Id;
                _objOrdenesDeTrabajo_Recursos.Id_OrdenDeTrabajo = objOrdenesDeTrabajo_Recursos.Id_OrdenDeTrabajo;
                _objOrdenesDeTrabajo_Recursos.Id_Recurso = objOrdenesDeTrabajo_Recursos.Id_Recurso;
                _objOrdenesDeTrabajo_Recursos.Id_Pedido_Detalle = objOrdenesDeTrabajo_Recursos.Id_Pedido_Detalle;
                _objOrdenesDeTrabajo_Recursos.Id_UnidadDeMedida = objOrdenesDeTrabajo_Recursos.Id_UnidadDeMedida;
                _objOrdenesDeTrabajo_Recursos.Cantidad = objOrdenesDeTrabajo_Recursos.Cantidad;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Trae todos los ordern de trabajo detalle ya con su lista.
        /// </summary>
        /// <param name="Id_Pedido">id del pedido padre</param>
        /// <returns>lista de detalles de pedido</returns>
        public List<LS_OrdenesDeTrabajo_RecursoResult> Seleccionar_By_OrdenDeTrabajo_LP(long Id_Orden)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_OrdenesDeTrabajo_Recurso(Id_Orden).ToList();
            }
        }
        public void IncluirAOrdenPedidosDetalles(Pedido_Detalle objPedidoDetalle, long Id_OrdenDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                OrdenesDeTrabajo_Recursos _objOrdenesDeTrabajoRecurso = new OrdenesDeTrabajo_Recursos();
                _objOrdenesDeTrabajoRecurso.Id_OrdenDeTrabajo = Id_OrdenDeTrabajo;
                _objOrdenesDeTrabajoRecurso.Id_Pedido_Detalle = objPedidoDetalle.Id;
                _objOrdenesDeTrabajoRecurso.Id_Recurso = objPedidoDetalle.Id_Recurso;
                _objOrdenesDeTrabajoRecurso.Id_UnidadDeMedida = objPedidoDetalle.Id_UnidadDeMedida;
                _objOrdenesDeTrabajoRecurso.Cantidad = objPedidoDetalle.Cantidad - (dc.OrdenesDeTrabajo_Recursos.Any(odtr => odtr.Id_Pedido_Detalle == objPedidoDetalle.Id) ? dc.OrdenesDeTrabajo_Recursos.Where(odtr => odtr.Id_Pedido_Detalle == objPedidoDetalle.Id).Sum(odtr => odtr.Cantidad) : 0);
                if (_objOrdenesDeTrabajoRecurso.Cantidad.Value > 0)
                {
                    dc.OrdenesDeTrabajo_Recursos.InsertOnSubmit(_objOrdenesDeTrabajoRecurso);
                    dc.SubmitChanges();
                }
            }
        }
        /// <summary>
        /// Obtiene todos los contactos de un Pedido
        /// </summary>
        /// <param name="Id_Pedido">Identificativo del Pedido</param>
        /// <returns>Lista de los contactos del Pedido</returns>
        public List<OrdenesDeTrabajo_Recursos> Seleccionar_By_OrdenDeTrabajo(long Id_OrdenDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var Query = from p in dc.OrdenesDeTrabajo_Recursos
                            where p.Id_OrdenDeTrabajo == Id_OrdenDeTrabajo
                            select p;
                return Query.ToList();
            }
        }
    }
}