using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Costo_ValorizacionOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Valorizacion> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_Valorizacion.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Valorizacion Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Costo_Valorizacion.Any(p => p.Id == Id))
                {
                    return dc.Costo_Valorizacion.Single(p => p.Id == Id);
                }
                else
                {
                    return new Costo_Valorizacion();
                }
            }
        }
        /// <summary>
        /// Retorna la lista de valorización
        /// </summary>
        /// <param name="id_Costo">costo al cual pertenecen los parametros de valorización</param>
        /// <returns></returns>
        public List<Costo_Valorizacion> Seleccionar_By_Id(long? id_Costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_Valorizacion.Where(p => p.Id_Costo == id_Costo).OrderBy(p => p.Posicion).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Valorizacion objCosto_Valorizacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo_Valorizacion.InsertOnSubmit(objCosto_Valorizacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_Valorizacion objCosto_Valorizacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Valorizacion _objCosto_Valorizacion = dc.Costo_Valorizacion.Single(p => p.Id == objCosto_Valorizacion.Id);
                dc.Costo_Valorizacion.DeleteOnSubmit(_objCosto_Valorizacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_Valorizacion objCosto_Valorizacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_Valorizacion _objCosto_Valorizacion = dc.Costo_Valorizacion.Single(p => p.Id == objCosto_Valorizacion.Id);
                _objCosto_Valorizacion.Id = objCosto_Valorizacion.Id;
                _objCosto_Valorizacion.Id_Costo = objCosto_Valorizacion.Id_Costo;
                _objCosto_Valorizacion.Descripcion = objCosto_Valorizacion.Descripcion;
                _objCosto_Valorizacion.Porcentaje = objCosto_Valorizacion.Porcentaje;
                _objCosto_Valorizacion.Posicion = objCosto_Valorizacion.Posicion;
                _objCosto_Valorizacion.ValorHastaElMomento = objCosto_Valorizacion.ValorHastaElMomento;
                dc.SubmitChanges();
            }
        }
    }
}