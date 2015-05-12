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
    public class FichaTecnica_ColorFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Color> Seleccionar_All()
        {
            FichaTecnica_ColorLN objFichaTecnica_Color = new FichaTecnica_ColorLN();
            return objFichaTecnica_Color.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Color Seleccionar_Id(long Id)
        {
            FichaTecnica_ColorLN objFichaTecnica_Color = new FichaTecnica_ColorLN();
            return objFichaTecnica_Color.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae una lista de fichatecnica color por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de colores</returns>
        public List<FichaTecnica_Color> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            FichaTecnica_ColorLN objFichaTecnica_Color = new FichaTecnica_ColorLN();
            return objFichaTecnica_Color.Seleccionar_By_FichaTecnica(Id_FichaTecnica);
        }
        /// <summary>
        /// Retorna lalista de fichas tecnicas color que no han sido registradas.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">id del grupo al qe pertenecen las fichas</param>
        /// <returns>Retorna la lista de fichas tecnicas color.</returns>
        public List<LC_FichasTecnicasColoresResult> Seleccionar_FichasColoresParaCostos(long? id_GrupoDeMiembros, long? id_RecursoActual)
        {
            FichaTecnica_ColorLN objFichaTecnica_Color = new FichaTecnica_ColorLN();
            return objFichaTecnica_Color.Seleccionar_FichasColoresParaCostos(id_GrupoDeMiembros, id_RecursoActual);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Color objFichaTecnica_Color)
        {
            FichaTecnica_ColorLN _objFichaTecnica_Color = new FichaTecnica_ColorLN();
            _objFichaTecnica_Color.Guardar(objFichaTecnica_Color);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Color objFichaTecnica_Color)
        {
            FichaTecnica_ColorLN _objFichaTecnica_Color = new FichaTecnica_ColorLN();
            _objFichaTecnica_Color.Eliminar(objFichaTecnica_Color);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Color objFichaTecnica_Color)
        {
            FichaTecnica_ColorLN _objFichaTecnica_Color = new FichaTecnica_ColorLN();
            _objFichaTecnica_Color.Actualizar(objFichaTecnica_Color);
        }
        /// <summary>
        /// Verifica si existe alguna fuicha tecnica color con un color singular.
        /// </summary>
        /// <param name="Id_Color">Color a verificar</param>
        /// <returns>Si existe o no</returns>
        public bool Existencia_PorColor(long Id_Color)
        {
            FichaTecnica_ColorLN _objFichaTecnica_Color = new FichaTecnica_ColorLN();
            return _objFichaTecnica_Color.Existencia_PorColor(Id_Color);
        }
    }
}