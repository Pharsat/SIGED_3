using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Costo_ProcesoDeFabricacionOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_ProcesoDeFabricacion> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_ProcesoDeFabricacion.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_ProcesoDeFabricacion Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Costo_ProcesoDeFabricacion.Any(p => p.Id == Id))
                {
                    return dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == Id);
                }
                else
                {
                    return new Costo_ProcesoDeFabricacion();
                }
            }
        }
        /// <summary>
        /// seleccionar todos los procesos agregados a este costo
        /// </summary>
        /// <param name="id_Costo">costo al cual se le consultaran los procesos</param>
        /// <returns>Lista de procesos</returns>
        public List<LS_Costo_ProcesosResult> Seleccionar_By_Id(long? id_Costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Costo_Procesos(id_Costo).ToList();
            }
        }

        public List<Costo_ProcesoDeFabricacion> Seleccionar_By_Id_Complete(long? id_Costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_ProcesoDeFabricacion.Where(p => p.Id_Costo == id_Costo).ToList();
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo_ProcesoDeFabricacion.InsertOnSubmit(objCosto_ProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_ProcesoDeFabricacion _objCosto_ProcesoDeFabricacion = dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == objCosto_ProcesoDeFabricacion.Id);
                dc.Costo_ProcesoDeFabricacion.DeleteOnSubmit(_objCosto_ProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo_ProcesoDeFabricacion _objCosto_ProcesoDeFabricacion = dc.Costo_ProcesoDeFabricacion.Single(p => p.Id == objCosto_ProcesoDeFabricacion.Id);
                _objCosto_ProcesoDeFabricacion.Id = objCosto_ProcesoDeFabricacion.Id;
                _objCosto_ProcesoDeFabricacion.Id_Costo = objCosto_ProcesoDeFabricacion.Id_Costo;
                _objCosto_ProcesoDeFabricacion.Id_Proceso = objCosto_ProcesoDeFabricacion.Id_Proceso;
                _objCosto_ProcesoDeFabricacion.Id_UnidadDeMedida = objCosto_ProcesoDeFabricacion.Id_UnidadDeMedida;
                _objCosto_ProcesoDeFabricacion.Cantidad = objCosto_ProcesoDeFabricacion.Cantidad;
                _objCosto_ProcesoDeFabricacion.Valor = objCosto_ProcesoDeFabricacion.Valor;
                dc.SubmitChanges();
            }
        }
    }
}