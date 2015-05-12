using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ImagenesOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Imagenes
        /// </summary>
        /// <returns>Lista de registros tipo Imagenes</returns>
        public List<Imagenes> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Imagenes.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Imagenes
        /// </summary>
        /// <param name=Id>Identificador de la Imagenes</param>
        /// <returns>Objeto singular del tipo Imagenes</returns>
        public List<Imagenes> Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.Imagenes
                            where p.Id == Id
                            select p;
                return query.ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Imagenes en la base de datos.
        /// </summary>
        /// <param name=objImagenes>Objeto Imagenes a guardar</param>
        public void Guardar(Imagenes objImagenes)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Imagenes.InsertOnSubmit(objImagenes);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda una imagen y devuelve su id salvado
        /// </summary>
        /// <param name="objImagenes">objeto imagen a guardar</param>
        /// <returns>id de la imagen guardada</returns>
        public long Guardar_2(Imagenes objImagenes)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Imagenes.InsertOnSubmit(objImagenes);
                dc.SubmitChanges();
                return dc.Imagenes.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Imagenes, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Imagenes</param>
        public void Eliminar(Imagenes objImagenes)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Imagenes _objImagenes = dc.Imagenes.Single(p => p.Id == objImagenes.Id);
                dc.Imagenes.DeleteOnSubmit(_objImagenes);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Imagenes, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objImagenes>Objeto del tipo Imagenes</param>
        public void Actualizar(Imagenes objImagenes)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Imagenes _objImagenes = dc.Imagenes.Single(p => p.Id == objImagenes.Id);
                _objImagenes.Id = objImagenes.Id;
                _objImagenes.Id_Miembro_Salvado = objImagenes.Id_Miembro_Salvado;
                _objImagenes.Image = objImagenes.Image;
                _objImagenes.NombreOriginal = objImagenes.NombreOriginal;
                _objImagenes.Tipo = objImagenes.Tipo;
                _objImagenes.Fecha_Salvado = objImagenes.Fecha_Salvado;
                dc.SubmitChanges();
            }
        }
    }
}