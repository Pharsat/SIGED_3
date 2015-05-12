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
    public class Costo_ProcesoDeFabricacionFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_ProcesoDeFabricacion> Seleccionar_All()
        {
            Costo_ProcesoDeFabricacionLN objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            return objCosto_ProcesoDeFabricacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_ProcesoDeFabricacion Seleccionar_Id(long Id)
        {
            Costo_ProcesoDeFabricacionLN objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            return objCosto_ProcesoDeFabricacion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// seleccionar todos los procesos agregados a este costo
        /// </summary>
        /// <param name="id_Costo">costo al cual se le consultaran los procesos</param>
        /// <returns>Lista de procesos</returns>
        public List<LS_Costo_ProcesosResult> Seleccionar_By_Id(long? id_Costo)
        {
            Costo_ProcesoDeFabricacionLN objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            return objCosto_ProcesoDeFabricacion.Seleccionar_By_Id(id_Costo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            Costo_ProcesoDeFabricacionLN _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            _objCosto_ProcesoDeFabricacion.Guardar(objCosto_ProcesoDeFabricacion);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            Costo_ProcesoDeFabricacionLN _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            _objCosto_ProcesoDeFabricacion.Eliminar(objCosto_ProcesoDeFabricacion);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_ProcesoDeFabricacion objCosto_ProcesoDeFabricacion)
        {
            Costo_ProcesoDeFabricacionLN _objCosto_ProcesoDeFabricacion = new Costo_ProcesoDeFabricacionLN();
            _objCosto_ProcesoDeFabricacion.Actualizar(objCosto_ProcesoDeFabricacion);
        }
    }
}