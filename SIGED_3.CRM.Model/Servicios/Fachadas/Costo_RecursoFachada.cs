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
    public class Costo_RecursoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo_Recurso> Seleccionar_All()
        {
            Costo_RecursoLN objCosto_Recurso = new Costo_RecursoLN();
            return objCosto_Recurso.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo_Recurso Seleccionar_Id(long Id)
        {
            Costo_RecursoLN objCosto_Recurso = new Costo_RecursoLN();
            return objCosto_Recurso.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Trae la lista de recursos en la lista de costos
        /// </summary>
        /// <param name="id_Costo">id del costo a traer</param>
        /// <returns>lista de costos</returns>
        public List<LS_Costo_RecursosResult> Seleccionar_By_Id(long? id_Costo)
        {
            Costo_RecursoLN objCosto_Recurso = new Costo_RecursoLN();
            return objCosto_Recurso.Seleccionar_By_Id(id_Costo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo_Recurso objCosto_Recurso)
        {
            Costo_RecursoLN _objCosto_Recurso = new Costo_RecursoLN();
            _objCosto_Recurso.Guardar(objCosto_Recurso);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo_Recurso objCosto_Recurso)
        {
            Costo_RecursoLN _objCosto_Recurso = new Costo_RecursoLN();
            _objCosto_Recurso.Eliminar(objCosto_Recurso);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo_Recurso objCosto_Recurso)
        {
            Costo_RecursoLN _objCosto_Recurso = new Costo_RecursoLN();
            _objCosto_Recurso.Actualizar(objCosto_Recurso);
        }
    }
}