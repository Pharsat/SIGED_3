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
    public class TipoDeDocumentoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<TipoDeDocumento> Seleccionar_All()
        {
            TipoDeDocumentoLN objTipoDeDocumento = new TipoDeDocumentoLN();
            return objTipoDeDocumento.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public TipoDeDocumento Seleccionar_Id(long Id)
        {
            TipoDeDocumentoLN objTipoDeDocumento = new TipoDeDocumentoLN();
            return objTipoDeDocumento.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(TipoDeDocumento objTipoDeDocumento)
        {
            TipoDeDocumentoLN _objTipoDeDocumento = new TipoDeDocumentoLN();
            _objTipoDeDocumento.Guardar(objTipoDeDocumento);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(TipoDeDocumento objTipoDeDocumento)
        {
            TipoDeDocumentoLN _objTipoDeDocumento = new TipoDeDocumentoLN();
            _objTipoDeDocumento.Eliminar(objTipoDeDocumento);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(TipoDeDocumento objTipoDeDocumento)
        {
            TipoDeDocumentoLN _objTipoDeDocumento = new TipoDeDocumentoLN();
            _objTipoDeDocumento.Actualizar(objTipoDeDocumento);
        }
    }
}