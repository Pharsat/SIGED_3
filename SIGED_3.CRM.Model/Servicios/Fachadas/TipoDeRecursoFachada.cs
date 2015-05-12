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
    public class TipoDeRecursoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<TipoDeRecurso> Seleccionar_All()
        {
            TipoDeRecursoLN objTipoDeRecurso = new TipoDeRecursoLN();
            return objTipoDeRecurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los tipos de recurso que no son procuto terminado
        /// </summary>
        /// <returns>Lista de tipos de recurso</returns>
        public List<TipoDeRecurso> Seleccionar_All_QueNoSonProductoTerminado()
        {
            TipoDeRecursoLN objTipoDeRecurso = new TipoDeRecursoLN();
            return objTipoDeRecurso.Seleccionar_All_QueNoSonProductoTerminado();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public TipoDeRecurso Seleccionar_Id(long Id)
        {
            TipoDeRecursoLN objTipoDeRecurso = new TipoDeRecursoLN();
            return objTipoDeRecurso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoLN _objTipoDeRecurso = new TipoDeRecursoLN();
            _objTipoDeRecurso.Guardar(objTipoDeRecurso);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoLN _objTipoDeRecurso = new TipoDeRecursoLN();
            _objTipoDeRecurso.Eliminar(objTipoDeRecurso);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoLN _objTipoDeRecurso = new TipoDeRecursoLN();
            _objTipoDeRecurso.Actualizar(objTipoDeRecurso);
        }
    }
}