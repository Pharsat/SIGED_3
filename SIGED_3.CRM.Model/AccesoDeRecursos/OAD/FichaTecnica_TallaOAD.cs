using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_TallaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Talla> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Talla.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Talla Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_Talla.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_Talla.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_Talla();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica Talla por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de Tallaes</returns>
        public List<FichaTecnica_Talla> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Talla.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_Talla.InsertOnSubmit(objFichaTecnica_Talla);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Talla _objFichaTecnica_Talla = dc.FichaTecnica_Talla.Single(p => p.Id == objFichaTecnica_Talla.Id);
                dc.FichaTecnica_Talla.DeleteOnSubmit(_objFichaTecnica_Talla);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Talla objFichaTecnica_Talla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Talla _objFichaTecnica_Talla = dc.FichaTecnica_Talla.Single(p => p.Id == objFichaTecnica_Talla.Id);
                _objFichaTecnica_Talla.Id = objFichaTecnica_Talla.Id;
                _objFichaTecnica_Talla.Id_FichaTecnica = objFichaTecnica_Talla.Id_FichaTecnica;
                _objFichaTecnica_Talla.Talla = objFichaTecnica_Talla.Talla;
                dc.SubmitChanges();
            }
        }
    }
}