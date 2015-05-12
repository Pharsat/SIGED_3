using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class OrdenesDeTrabajoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<OrdenesDeTrabajo> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.OrdenesDeTrabajo.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public OrdenesDeTrabajo Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.OrdenesDeTrabajo.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="id_Cliente"></param>
        /// <param name="consecutivo"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        public List<LP_OrdenesDeTrabajoResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                id_Cliente = id_Cliente == 0 ? null : id_Cliente;
                return dc.LP_OrdenesDeTrabajo(estado, id_Cliente, consecutivo, desde, hasta).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.OrdenesDeTrabajo.InsertOnSubmit(objOrdenesDeTrabajo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto OrdenesDeTrabajo y obtiene su Id
        /// </summary>
        /// <param name="objPedido">Licnete a guardar</param>
        public long Guardar_2(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.OrdenesDeTrabajo.InsertOnSubmit(objOrdenesDeTrabajo);
                dc.SubmitChanges();
                return dc.OrdenesDeTrabajo.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                OrdenesDeTrabajo _objOrdenesDeTrabajo = dc.OrdenesDeTrabajo.Single(p => p.Id == objOrdenesDeTrabajo.Id);
                dc.OrdenesDeTrabajo.DeleteOnSubmit(_objOrdenesDeTrabajo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(OrdenesDeTrabajo objOrdenesDeTrabajo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                OrdenesDeTrabajo _objOrdenesDeTrabajo = dc.OrdenesDeTrabajo.Single(p => p.Id == objOrdenesDeTrabajo.Id);
                _objOrdenesDeTrabajo.Id = objOrdenesDeTrabajo.Id;
                _objOrdenesDeTrabajo.Id_Solicitante = objOrdenesDeTrabajo.Id_Solicitante;
                _objOrdenesDeTrabajo.Id_GrupoDeMiembros = objOrdenesDeTrabajo.Id_GrupoDeMiembros;
                _objOrdenesDeTrabajo.Id_Estado = objOrdenesDeTrabajo.Id_Estado;
                _objOrdenesDeTrabajo.Consecutivo = objOrdenesDeTrabajo.Consecutivo;
                _objOrdenesDeTrabajo.FechaGeneracion = objOrdenesDeTrabajo.FechaGeneracion;
                _objOrdenesDeTrabajo.FechaInicio = objOrdenesDeTrabajo.FechaInicio;
                _objOrdenesDeTrabajo.FechaFinalizacion = objOrdenesDeTrabajo.FechaFinalizacion;
                dc.SubmitChanges();
            }
        }
        public List<OrdenesDeTrabajo> Seleccionar_All_NoRecibidos()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.OrdenesDeTrabajo.Where(p => p.Id_Estado != (long)EstadosDelProceso_Enum.OTTCO && p.Id_GrupoDeMiembros == SessionManager.Id_GrupoDeMiembros && dc.OrdenesDeTrabajo_Recursos.Where(pd => (pd.Cantidad - (dc.Recibidos_Recursos.Any(odtr => odtr.Id_OrdenesDeTrabajo_Recurso == pd.Id) ? (dc.Recibidos_Recursos.Where(odtr => odtr.Id_OrdenesDeTrabajo_Recurso == pd.Id).Sum(odtr => odtr.Cantidad)) : 0)) > 0).Select(pd => pd.Id_OrdenDeTrabajo).Distinct().Contains(p.Id)).ToList();
            }
        }
        public List<R_OrdenesDeTrabajoResult> RelatorioDeOrdenesDeTrabajo(long? Consecutivo, long? id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_OrdenesDeTrabajo(Consecutivo, id_GrupoDeMiembros).ToList();
            }
        }
    }
}