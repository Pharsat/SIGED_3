using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class ColorLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Color> Seleccionar_All()
        {
            ColorOAD objColor = new ColorOAD();
            return objColor.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Color Seleccionar_Id(long Id)
        {
            ColorOAD objColor = new ColorOAD();
            return objColor.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Retorna la lista de colores de una organizacion
        /// </summary>
        /// <param name="Id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <returns>lista de colores de la organizacion</returns>
        public List<Color> Seleccionar_By_IdGrupoMiembros(long Id_GrupoDeMiembros)
        {
            ColorOAD objColor = new ColorOAD();
            return objColor.Seleccionar_By_IdGrupoMiembros(Id_GrupoDeMiembros);
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
            ColorOAD objColor = new ColorOAD();
            return objColor.Seleccionar_LP(id_GrupoDeMiembros, estado, nombre);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Color objColor)
        {
            ColorOAD _objColor = new ColorOAD();
            _objColor.Guardar(objColor);
        }
        /// <summary>
        /// Guarda el objeto color y obtiene su Id
        /// </summary>
        /// <param name="objColor">Licnete a guardar</param>
        public long Guardar_2(Color objColor)
        {
            ColorOAD _objColor = new ColorOAD();
            return _objColor.Guardar_2(objColor);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Color objColor)
        {
            ColorOAD _objColor = new ColorOAD();
            _objColor.Eliminar(objColor);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Color objColor)
        {
            ColorOAD _objColor = new ColorOAD();
            _objColor.Actualizar(objColor);
        }
    }
}