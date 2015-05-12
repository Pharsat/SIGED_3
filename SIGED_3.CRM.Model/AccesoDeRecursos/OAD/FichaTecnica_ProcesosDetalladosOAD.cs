using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_ProcesosDetalladosOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_ProcesosDetallados.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_ProcesosDetallados Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_ProcesosDetallados.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_ProcesosDetallados.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_ProcesosDetallados();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica ProcesosDetallados por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de ProcesosDetalladoses</returns>
        public List<FichaTecnica_ProcesosDetallados> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_ProcesosDetallados.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_ProcesosDetallados.InsertOnSubmit(objFichaTecnica_ProcesosDetallados);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_ProcesosDetallados _objFichaTecnica_ProcesosDetallados = dc.FichaTecnica_ProcesosDetallados.Single(p => p.Id == objFichaTecnica_ProcesosDetallados.Id);
                dc.FichaTecnica_ProcesosDetallados.DeleteOnSubmit(_objFichaTecnica_ProcesosDetallados);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_ProcesosDetallados objFichaTecnica_ProcesosDetallados)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_ProcesosDetallados _objFichaTecnica_ProcesosDetallados = dc.FichaTecnica_ProcesosDetallados.Single(p => p.Id == objFichaTecnica_ProcesosDetallados.Id);
                _objFichaTecnica_ProcesosDetallados.Id = objFichaTecnica_ProcesosDetallados.Id;
                _objFichaTecnica_ProcesosDetallados.Id_FichaTecnica = objFichaTecnica_ProcesosDetallados.Id_FichaTecnica;
                _objFichaTecnica_ProcesosDetallados.Id_Proceso = objFichaTecnica_ProcesosDetallados.Id_Proceso;
                _objFichaTecnica_ProcesosDetallados.Descripcion = objFichaTecnica_ProcesosDetallados.Descripcion;
                _objFichaTecnica_ProcesosDetallados.Id_Imagen = objFichaTecnica_ProcesosDetallados.Id_Imagen;
                dc.SubmitChanges();
            }
        }
    }
}