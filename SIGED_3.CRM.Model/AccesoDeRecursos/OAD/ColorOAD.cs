using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ColorOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Color> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Color.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Color Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Color.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Retorna la lista de colores de una organizacion
        /// </summary>
        /// <param name="Id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <returns>lista de colores de la organizacion</returns>
        public List<Color> Seleccionar_By_IdGrupoMiembros(long Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Color.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList() ;
            }
        }
        /// <summary>
        /// Selecciona la lista de colores
        /// </summary>
        /// <param name="id_GrupoDeMiembros">Grupo al que pertenece el mimebro</param>
        /// <param name="estado">estado de habilidad del color</param>
        /// <param name="nombre">nombre del color</param>
        /// <returns>lista de colores.</returns>
        public List<LP_ColoresResult> Seleccionar_LP(int? id_GrupoDeMiembros, bool? estado, string nombre)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Colores(id_GrupoDeMiembros, estado, nombre).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Color objColor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Color.InsertOnSubmit(objColor);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto color y obtiene su Id
        /// </summary>
        /// <param name="objColor">Licnete a guardar</param>
        public long Guardar_2(Color objColor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Color.InsertOnSubmit(objColor);
                dc.SubmitChanges();
                return dc.Color.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Color objColor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Color _objColor = dc.Color.Single(p => p.Id == objColor.Id);
                dc.Color.DeleteOnSubmit(_objColor);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Color objColor)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Color _objColor = dc.Color.Single(p => p.Id == objColor.Id);
                _objColor.Id = objColor.Id;
                _objColor.Id_GrupoDeMiembros = objColor.Id_GrupoDeMiembros;
                _objColor.Nombre = objColor.Nombre;
                _objColor.Estado = objColor.Estado;
                _objColor.Color1 = objColor.Color1;
                dc.SubmitChanges();
            }
        }
    }
}