using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class TipoDeRecursoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<TipoDeRecurso> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoDeRecurso.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los tipos de recurso que no son procuto terminado
        /// </summary>
        /// <returns>Lista de tipos de recurso</returns>
        public List<TipoDeRecurso> Seleccionar_All_QueNoSonProductoTerminado()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoDeRecurso.Where(p => p.Id != (long)TipoDeRecurso_Enum.ProductoTerminado).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public TipoDeRecurso Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoDeRecurso.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(TipoDeRecurso objTipoDeRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.TipoDeRecurso.InsertOnSubmit(objTipoDeRecurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(TipoDeRecurso objTipoDeRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoDeRecurso _objTipoDeRecurso = dc.TipoDeRecurso.Single(p => p.Id == objTipoDeRecurso.Id);
                dc.TipoDeRecurso.DeleteOnSubmit(_objTipoDeRecurso);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(TipoDeRecurso objTipoDeRecurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoDeRecurso _objTipoDeRecurso = dc.TipoDeRecurso.Single(p => p.Id == objTipoDeRecurso.Id);
                _objTipoDeRecurso.Id = objTipoDeRecurso.Id;
                _objTipoDeRecurso.Nombre = objTipoDeRecurso.Nombre;
                dc.SubmitChanges();
            }
        }
    }
}