using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class EstadosDelProcesoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla EstadosDelProceso
        /// </summary>
        /// <returns>Lista de registros tipo EstadosDelProceso</returns>
        public List<EstadosDelProceso> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.EstadosDelProceso.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla EstadosDelProceso
        /// </summary>
        /// <param name=Id>Identificador de la EstadosDelProceso</param>
        /// <returns>Objeto singular del tipo EstadosDelProceso</returns>
        public EstadosDelProceso Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.EstadosDelProceso
                            where p.Id == Id
                            select p;
                return query.Single();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo EstadosDelProceso en la base de datos.
        /// </summary>
        /// <param name=objEstadosDelProceso>Objeto EstadosDelProceso a guardar</param>
        public void Guardar(EstadosDelProceso objEstadosDelProceso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.EstadosDelProceso.InsertOnSubmit(objEstadosDelProceso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo EstadosDelProceso, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) EstadosDelProceso</param>
        public void Eliminar(EstadosDelProceso objEstadosDelProceso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                EstadosDelProceso _objEstadosDelProceso = dc.EstadosDelProceso.Single(p => p.Id == objEstadosDelProceso.Id);
                dc.EstadosDelProceso.DeleteOnSubmit(_objEstadosDelProceso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una EstadosDelProceso, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objEstadosDelProceso>Objeto del tipo EstadosDelProceso</param>
        public void Actualizar(EstadosDelProceso objEstadosDelProceso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                EstadosDelProceso _objEstadosDelProceso = dc.EstadosDelProceso.Single(p => p.Id == objEstadosDelProceso.Id);
                _objEstadosDelProceso.Id = objEstadosDelProceso.Id;
                _objEstadosDelProceso.Estado = objEstadosDelProceso.Estado;
                _objEstadosDelProceso.Descripcion = objEstadosDelProceso.Descripcion;
                dc.SubmitChanges();
            }
        }
    }
}