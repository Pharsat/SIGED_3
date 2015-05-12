using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_HiloOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Hilo> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Hilo.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Hilo Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_Hilo.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_Hilo.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_Hilo();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica Hilo por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de Hiloes</returns>
        public List<FichaTecnica_Hilo> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Hilo.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_Hilo.InsertOnSubmit(objFichaTecnica_Hilo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Hilo _objFichaTecnica_Hilo = dc.FichaTecnica_Hilo.Single(p => p.Id == objFichaTecnica_Hilo.Id);
                dc.FichaTecnica_Hilo.DeleteOnSubmit(_objFichaTecnica_Hilo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Hilo objFichaTecnica_Hilo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Hilo _objFichaTecnica_Hilo = dc.FichaTecnica_Hilo.Single(p => p.Id == objFichaTecnica_Hilo.Id);
                _objFichaTecnica_Hilo.Id = objFichaTecnica_Hilo.Id;
                _objFichaTecnica_Hilo.Id_FichaTecnica = objFichaTecnica_Hilo.Id_FichaTecnica;
                _objFichaTecnica_Hilo.Tipo = objFichaTecnica_Hilo.Tipo;
                _objFichaTecnica_Hilo.Calibre = objFichaTecnica_Hilo.Calibre;
                dc.SubmitChanges();
            }
        }
    }
}