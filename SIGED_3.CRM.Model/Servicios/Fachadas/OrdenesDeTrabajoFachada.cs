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
    public class OrdenesDeTrabajoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<OrdenesDeTrabajo> Seleccionar_All()
        {
            OrdenesDeTrabajoLN objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            return objOrdenesDeTrabajo.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public OrdenesDeTrabajo Seleccionar_Id(long Id)
        {
            OrdenesDeTrabajoLN objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            return objOrdenesDeTrabajo.Seleccionar_Id(Id);
        }
        public List<LP_OrdenesDeTrabajoResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            OrdenesDeTrabajoLN objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            return objOrdenesDeTrabajo.Seleccionar_LP(estado, id_Cliente, consecutivo, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoLN _objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            _objOrdenesDeTrabajo.Guardar(objOrdenesDeTrabajo);
        }
        /// <summary>
        /// Guarda el objeto OrdenesDeTrabajo y obtiene su Id
        /// </summary>
        /// <param name="objOrdenesDeTrabajo">Licnete a guardar</param>
        public long Guardar_2(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoLN _objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            return _objOrdenesDeTrabajo.Guardar_2(objOrdenesDeTrabajo);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoLN _objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            _objOrdenesDeTrabajo.Eliminar(objOrdenesDeTrabajo);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            OrdenesDeTrabajoLN _objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            _objOrdenesDeTrabajo.Actualizar(objOrdenesDeTrabajo);
        }
        public void IncluirAOrdenPedidosDetalles(long Id_Pedido, long Id_OrdenDeTrabajo)
        {
            OrdenesDeTrabajoLN _objOrdenesDeTrabajo = new OrdenesDeTrabajoLN();
            _objOrdenesDeTrabajo.IncluirAOrdenPedidosDetalles(Id_Pedido, Id_OrdenDeTrabajo);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla pedidos
        /// </summary>
        /// <returns>Lista de registros tipo pedidos que no hallan sido ordenados en su totalidad</returns>
        public List<OrdenesDeTrabajo> Seleccionar_All_NoRecibidos()
        {
            OrdenesDeTrabajoLN _objOrdenDeTrabajo = new OrdenesDeTrabajoLN();
            return _objOrdenDeTrabajo.Seleccionar_All_NoRecibidos();
        }
        public List<R_OrdenesDeTrabajoResult> RelatorioDeOrdenesDeTrabajo(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            OrdenesDeTrabajoLN _objOrden = new OrdenesDeTrabajoLN();
            return _objOrden.RelatorioDeOrdenesDeTrabajo(Consecutivo, id_GrupoDeMiembros);
        }
    }
}