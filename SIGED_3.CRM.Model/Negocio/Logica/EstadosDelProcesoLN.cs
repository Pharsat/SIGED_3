using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class EstadosDelProcesoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla EstadosDelProceso
        /// </summary>
        /// <returns>Lista de registros tipo EstadosDelProceso</returns>
        public List<EstadosDelProceso> Seleccionar_All()
        {
            EstadosDelProcesoOAD objEstadosDelProceso = new EstadosDelProcesoOAD();
            return objEstadosDelProceso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla EstadosDelProceso
        /// </summary>
        /// <param name=Id>Identificador de la EstadosDelProceso</param>
        /// <returns>Objeto singular del tipo EstadosDelProceso</returns>
        public EstadosDelProceso Seleccionar_Id(long Id)
        {
            EstadosDelProcesoOAD objEstadosDelProceso = new EstadosDelProcesoOAD();
            return objEstadosDelProceso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo EstadosDelProceso en la base de datos.
        /// </summary>
        /// <param name=objEstadosDelProceso>Objeto EstadosDelProceso a guardar</param>
        public void Guardar(EstadosDelProceso objEstadosDelProceso)
        {
            EstadosDelProcesoOAD _objEstadosDelProceso = new EstadosDelProcesoOAD();
            _objEstadosDelProceso.Guardar(objEstadosDelProceso);
        }
        /// <summary>
        /// Elimina un objeto del tipo EstadosDelProceso, se recibe su Id unicamente
        /// </summary>
        /// <param name=objEstadosDelProceso>Identificativo del(a) EstadosDelProceso</param>
        public void Eliminar(EstadosDelProceso objEstadosDelProceso)
        {
            EstadosDelProcesoOAD _objEstadosDelProceso = new EstadosDelProcesoOAD();
            _objEstadosDelProceso.Eliminar(objEstadosDelProceso);
        }
        /// <summary>
        /// Actualiza una EstadosDelProceso, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objEstadosDelProceso>Objeto del tipo EstadosDelProceso</param>
        public void Actualizar(EstadosDelProceso objEstadosDelProceso)
        {
            EstadosDelProcesoOAD _objEstadosDelProceso = new EstadosDelProcesoOAD();
            _objEstadosDelProceso.Actualizar(objEstadosDelProceso);
        }
    }
}