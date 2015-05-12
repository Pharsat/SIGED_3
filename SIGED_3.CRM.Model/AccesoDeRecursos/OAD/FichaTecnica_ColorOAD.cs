using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_ColorOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_Color> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Color.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_Color Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_Color.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_Color.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_Color();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica color por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de colores</returns>
        public List<FichaTecnica_Color> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Color.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).ToList();
            }
        }
        /// <summary>
        /// Retorna lalista de fichas tecnicas color que no han sido registradas.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">id del grupo al qe pertenecen las fichas</param>
        /// <returns>Retorna la lista de fichas tecnicas color.</returns>
        public List<LC_FichasTecnicasColoresResult> Seleccionar_FichasColoresParaCostos(long? id_GrupoDeMiembros, long? id_RecursoActual)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LC_FichasTecnicasColores(id_GrupoDeMiembros, id_RecursoActual).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_Color objFichaTecnica_Color)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_Color.InsertOnSubmit(objFichaTecnica_Color);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_Color objFichaTecnica_Color)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Color _objFichaTecnica_Color = dc.FichaTecnica_Color.Single(p => p.Id == objFichaTecnica_Color.Id);
                dc.FichaTecnica_Color.DeleteOnSubmit(_objFichaTecnica_Color);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_Color objFichaTecnica_Color)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_Color _objFichaTecnica_Color = dc.FichaTecnica_Color.Single(p => p.Id == objFichaTecnica_Color.Id);
                _objFichaTecnica_Color.Id = objFichaTecnica_Color.Id;
                _objFichaTecnica_Color.Id_FichaTecnica = objFichaTecnica_Color.Id_FichaTecnica;
                _objFichaTecnica_Color.Id_Color = objFichaTecnica_Color.Id_Color;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Verifica si existe alguna fuicha tecnica color con un color singular.
        /// </summary>
        /// <param name="Id_Color">Color a verificar</param>
        /// <returns>Si existe o no</returns>
        public bool Existencia_PorColor(long Id_Color)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_Color.Any(p => p.Id_Color == Id_Color);
            }
        }
    }
}