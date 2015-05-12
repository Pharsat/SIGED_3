using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class FichaTecnica_PasosDeConfeccionOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<FichaTecnica_PasosDeConfeccion> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_PasosDeConfeccion.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public FichaTecnica_PasosDeConfeccion Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_PasosDeConfeccion.Any(p => p.Id == Id))
                {
                    return dc.FichaTecnica_PasosDeConfeccion.Single(p => p.Id == Id);
                }
                else
                {
                    return new FichaTecnica_PasosDeConfeccion();
                }
            }
        }
        /// <summary>
        /// Trae una lista de fichatecnica PasosDeConfeccion por la ficha tecnica a la cual pertenece
        /// </summary>
        /// <param name="Id_FichaTecnica">Id de la ficha tecnica</param>
        /// <returns>Lista de PasosDeConfecciones</returns>
        public List<FichaTecnica_PasosDeConfeccion> Seleccionar_By_FichaTecnica(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_PasosDeConfeccion.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).OrderBy(p => p.Numeracion).ToList();
            }
        }
        /// <summary>
        /// Returna la cantidad de fichas tecnicas actualess en el sistema y 
        /// </summary>
        /// <param name="Id_FichaTecnica">ficha tecnica a la cual le pertenecen los procesos</param>
        /// <returns>la numeracion sigueinte para los pasos</returns>
        public int Seleccionar_ProximoNumeracion(long Id_FichaTecnica)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.FichaTecnica_PasosDeConfeccion.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).Count() >= 1)
                {
                    return dc.FichaTecnica_PasosDeConfeccion.Where(p => p.Id_FichaTecnica == Id_FichaTecnica).Max(p => p.Numeracion).Value + 1;
                }
                else
                {
                    return 1;
                }
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_PasosDeConfeccion.InsertOnSubmit(objFichaTecnica_PasosDeConfeccion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_PasosDeConfeccion _objFichaTecnica_PasosDeConfeccion = dc.FichaTecnica_PasosDeConfeccion.Single(p => p.Id == objFichaTecnica_PasosDeConfeccion.Id);
                dc.FichaTecnica_PasosDeConfeccion.DeleteOnSubmit(_objFichaTecnica_PasosDeConfeccion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(FichaTecnica_PasosDeConfeccion objFichaTecnica_PasosDeConfeccion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                FichaTecnica_PasosDeConfeccion _objFichaTecnica_PasosDeConfeccion = dc.FichaTecnica_PasosDeConfeccion.Single(p => p.Id == objFichaTecnica_PasosDeConfeccion.Id);
                _objFichaTecnica_PasosDeConfeccion.Id = objFichaTecnica_PasosDeConfeccion.Id;
                _objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica = objFichaTecnica_PasosDeConfeccion.Id_FichaTecnica;
                _objFichaTecnica_PasosDeConfeccion.Id_Recurso = objFichaTecnica_PasosDeConfeccion.Id_Recurso;
                _objFichaTecnica_PasosDeConfeccion.Descripcion = objFichaTecnica_PasosDeConfeccion.Descripcion;
                _objFichaTecnica_PasosDeConfeccion.Numeracion = objFichaTecnica_PasosDeConfeccion.Numeracion;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Valida si el numero existe
        /// </summary>
        /// <param name="Numero">numero a validar</param>
        /// <returns></returns>
        public bool VerificarNumeracion(long? Id_FichaTecnica, int Numero)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.FichaTecnica_PasosDeConfeccion.Any(p => p.Id_FichaTecnica == Id_FichaTecnica && p.Numeracion.Value == Numero);
            }
        }
        /// <summary>
        /// Actualiza todos los elementos cuya numeracion es superior a la numeracion indicada
        /// aumentando su valor en 1
        /// </summary>
        /// <param name="Id_FichaTecnica">ficha a la cual se aplica la instruccion</param>
        /// <param name="Numero">numero a buscar</param>
        public void ActualizarValoresMayoresANumero(long? Id_FichaTecnica, int Numero)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.FichaTecnica_PasosDeConfeccion.Where(p => p.Id_FichaTecnica == Id_FichaTecnica && p.Numeracion.Value >= Numero).ToList().ForEach(p => p.Numeracion = p.Numeracion + 1);
                dc.SubmitChanges();
            }
        }
    }
}