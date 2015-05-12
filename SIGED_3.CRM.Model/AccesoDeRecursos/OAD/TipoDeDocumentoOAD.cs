using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class TipoDeDocumentoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<TipoDeDocumento> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoDeDocumento.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public TipoDeDocumento Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.TipoDeDocumento.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(TipoDeDocumento objTipoDeDocumento)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.TipoDeDocumento.InsertOnSubmit(objTipoDeDocumento);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(TipoDeDocumento objTipoDeDocumento)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoDeDocumento _objTipoDeDocumento = dc.TipoDeDocumento.Single(p => p.Id == objTipoDeDocumento.Id);
                dc.TipoDeDocumento.DeleteOnSubmit(_objTipoDeDocumento);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(TipoDeDocumento objTipoDeDocumento)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                TipoDeDocumento _objTipoDeDocumento = dc.TipoDeDocumento.Single(p => p.Id == objTipoDeDocumento.Id);
                _objTipoDeDocumento.Id = objTipoDeDocumento.Id;
                _objTipoDeDocumento.Nombre = objTipoDeDocumento.Nombre;
                _objTipoDeDocumento.Estado = objTipoDeDocumento.Estado;
                dc.SubmitChanges();
            }
        }
    }
}