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
    public class FichaTecnica_ProcesosDetalladosFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_All()
        {
            FichaTecnica_ProcesosDetalladosLN objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_ProcesosDetallados Seleccionar_Id(long Id)
        {
            FichaTecnica_ProcesosDetalladosLN objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica ProcesosDetallados por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de ProcesosDetalladoses</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_ProcesosDetalladosLN objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            return objFichaTecnica_ProcesosDetallados.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            FichaTecnica_ProcesosDetalladosLN _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            _objFichaTecnica_ProcesosDetallados.Guardar(objFichaTecnica_ProcesosDetallados);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            FichaTecnica_ProcesosDetalladosLN _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            _objFichaTecnica_ProcesosDetallados.Eliminar(objFichaTecnica_ProcesosDetallados);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            FichaTecnica_ProcesosDetalladosLN _objFichaTecnica_ProcesosDetallados = new FichaTecnica_ProcesosDetalladosLN();
            _objFichaTecnica_ProcesosDetallados.Actualizar(objFichaTecnica_ProcesosDetallados);
        }
    }
}