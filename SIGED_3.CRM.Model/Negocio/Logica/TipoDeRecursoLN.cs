using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class TipoDeRecursoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<TipoDeRecurso> Seleccionar_All()
        {
            TipoDeRecursoOAD objTipoDeRecurso = new TipoDeRecursoOAD();
            return objTipoDeRecurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los tipos de recurso que no son procuto terminado
        /// </summary>
        /// <returns>Lista de tipos de recurso</returns>
        public List<TipoDeRecurso> Seleccionar_All_QueNoSonProductoTerminado()
        {
            TipoDeRecursoOAD objTipoDeRecurso = new TipoDeRecursoOAD();
            return objTipoDeRecurso.Seleccionar_All_QueNoSonProductoTerminado();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public TipoDeRecurso Seleccionar_Id(long Id)
        {
            TipoDeRecursoOAD objTipoDeRecurso = new TipoDeRecursoOAD();
            return objTipoDeRecurso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoOAD _objTipoDeRecurso = new TipoDeRecursoOAD();
            _objTipoDeRecurso.Guardar(objTipoDeRecurso);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoOAD _objTipoDeRecurso = new TipoDeRecursoOAD();
            _objTipoDeRecurso.Eliminar(objTipoDeRecurso);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(TipoDeRecurso objTipoDeRecurso)
        {
            TipoDeRecursoOAD _objTipoDeRecurso = new TipoDeRecursoOAD();
            _objTipoDeRecurso.Actualizar(objTipoDeRecurso);
        }
    }
}