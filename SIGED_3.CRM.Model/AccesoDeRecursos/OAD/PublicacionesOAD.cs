using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class PublicacionesOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Publicaciones
        /// </summary>
        /// <returns>Lista de registros tipo Publicaciones</returns>
        public List<Publicaciones> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Publicaciones.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Publicaciones
        /// </summary>
        /// <param name=Id>Identificador de la Publicaciones</param>
        /// <returns>Objeto singular del tipo Publicaciones</returns>
        public Publicaciones Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Publicaciones.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Metodo que consulta la lista principal de bodegas.
        /// </summary>
        /// <param name="Estado">Estado de habilidad de la bodega</param>
        /// <param name="Id_GrupoDeMiembros">Grupo de pertenencia</param>
        /// <param name="Nombre">Nombre de la bodega</param>
        /// <returns>Lista de datos de la bodega</returns>
        public List<LP_PublicacionesResult> Seleccionar_LP()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Publicaciones().ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Publicaciones en la base de datos.
        /// </summary>
        /// <param name=objPublicaciones>Objeto Publicaciones a guardar</param>
        public void Guardar(Publicaciones objPublicaciones)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Publicaciones.InsertOnSubmit(objPublicaciones);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Publicaciones y obtiene su Id
        /// </summary>
        /// <param name="objPublicaciones">Licnete a guardar</param>
        public long Guardar_2(Publicaciones objPublicaciones)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Publicaciones.InsertOnSubmit(objPublicaciones);
                dc.SubmitChanges();
                return dc.Publicaciones.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Publicaciones, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Publicaciones</param>
        public void Eliminar(Publicaciones objPublicaciones)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Publicaciones _objPublicaciones = dc.Publicaciones.Single(p => p.Id == objPublicaciones.Id);
                dc.Publicaciones.DeleteOnSubmit(_objPublicaciones);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Publicaciones, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objPublicaciones>Objeto del tipo Publicaciones</param>
        public void Actualizar(Publicaciones objPublicaciones)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Publicaciones _objPublicaciones = dc.Publicaciones.Single(p => p.Id == objPublicaciones.Id);
                _objPublicaciones.Id = objPublicaciones.Id;
                _objPublicaciones.Id_Cuenta = objPublicaciones.Id_Cuenta;
                _objPublicaciones.FechaPublicacion = objPublicaciones.FechaPublicacion;
                _objPublicaciones.Publicacion = objPublicaciones.Publicacion;
                dc.SubmitChanges();
            }
        }
    }
}
