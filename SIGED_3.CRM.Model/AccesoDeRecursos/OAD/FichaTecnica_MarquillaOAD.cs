using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_MarquillaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Marquilla> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Marquilla.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Marquilla Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_Marquilla.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_Marquilla.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_Marquilla();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica Marquilla por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de Marquillaes</returns>
        public List<FichaTecnica_Marquilla> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Marquilla.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_Marquilla.InsertOnSubmit(objFichaTecnica_Marquilla);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Marquilla _objFichaTecnica_Marquilla = dc.FichaTecnica_Marquilla.Single(p => p.Id == objFichaTecnica_Marquilla.Id);
                dc.FichaTecnica_Marquilla.DeleteOnSubmit(_objFichaTecnica_Marquilla);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Marquilla objFichaTecnica_Marquilla)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Marquilla _objFichaTecnica_Marquilla = dc.FichaTecnica_Marquilla.Single(p => p.Id == objFichaTecnica_Marquilla.Id);
                _objFichaTecnica_Marquilla.Id = objFichaTecnica_Marquilla.Id;
                _objFichaTecnica_Marquilla.Id_FichaTecnica = objFichaTecnica_Marquilla.Id_FichaTecnica;
                _objFichaTecnica_Marquilla.Id_Imagen = objFichaTecnica_Marquilla.Id_Imagen;
                _objFichaTecnica_Marquilla.Tipo = objFichaTecnica_Marquilla.Tipo;
                _objFichaTecnica_Marquilla.Ubicacion = objFichaTecnica_Marquilla.Ubicacion;
                _objFichaTecnica_Marquilla.Altura = objFichaTecnica_Marquilla.Altura;
                dc.SubmitChanges();
            }
        }
    }
}