using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class PublicacionesLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Publicaciones
        /// </summary>
        /// <returns>Lista de registros tipo Publicaciones</returns>
        public List<Publicaciones> Seleccionar_All()
        {
            PublicacionesOAD objPublicaciones = new PublicacionesOAD();
            return objPublicaciones.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Publicaciones
        /// </summary>
        /// <param name=Id>Identificador de la Publicaciones</param>
        /// <returns>Objeto singular del tipo Publicaciones</returns>
        public Publicaciones Seleccionar_Id(long Id)
        {
            PublicacionesOAD objPublicaciones = new PublicacionesOAD();
            return objPublicaciones.Seleccionar_Id(Id);
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
            PublicacionesOAD objPublicaciones = new PublicacionesOAD();
            return objPublicaciones.Seleccionar_LP();
        }
        /// <summary>
        /// Guarda un objeto de tipo Publicaciones en la base de datos.
        /// </summary>
        /// <param name=objPublicaciones>Objeto Publicaciones a guardar</param>
        public void Guardar(Publicaciones objPublicaciones)
        {
            PublicacionesOAD _objPublicaciones = new PublicacionesOAD();
            _objPublicaciones.Guardar(objPublicaciones);
        }
        /// <summary>
        /// Guarda el objeto Publicaciones y obtiene su Id
        /// </summary>
        /// <param name="objPublicaciones">Licnete a guardar</param>
        public long Guardar_2(Publicaciones objPublicaciones)
        {
            PublicacionesOAD _objPublicaciones = new PublicacionesOAD();
            return _objPublicaciones.Guardar_2(objPublicaciones);
        }
        /// <summary>
        /// Elimina un objeto del tipo Publicaciones, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Publicaciones</param>
        public void Eliminar(Publicaciones objPublicaciones)
        {
            PublicacionesOAD _objPublicaciones = new PublicacionesOAD();
            _objPublicaciones.Eliminar(objPublicaciones);
        }
        /// <summary>
        /// Actualiza una Publicaciones, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objPublicaciones>Objeto del tipo Publicaciones</param>
        public void Actualizar(Publicaciones objPublicaciones)
        {
            PublicacionesOAD _objPublicaciones = new PublicacionesOAD();
            _objPublicaciones.Actualizar(objPublicaciones);
        }
    }
}
