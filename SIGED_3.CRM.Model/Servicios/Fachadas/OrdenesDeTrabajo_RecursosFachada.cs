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
    public class OrdenesDeTrabajo_RecursosFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<OrdenesDeTrabajo_Recursos> Seleccionar_All()
        {
            OrdenesDeTrabajo_RecursosLN objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            return objOrdenesDeTrabajo_Recursos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public OrdenesDeTrabajo_Recursos Seleccionar_Id(long Id)
        {
            OrdenesDeTrabajo_RecursosLN objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            return objOrdenesDeTrabajo_Recursos.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            OrdenesDeTrabajo_RecursosLN _objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            _objOrdenesDeTrabajo_Recursos.Guardar(objOrdenesDeTrabajo_Recursos);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            OrdenesDeTrabajo_RecursosLN _objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            _objOrdenesDeTrabajo_Recursos.Eliminar(objOrdenesDeTrabajo_Recursos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(OrdenesDeTrabajo_Recursos objOrdenesDeTrabajo_Recursos)
        {
            OrdenesDeTrabajo_RecursosLN _objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            _objOrdenesDeTrabajo_Recursos.Actualizar(objOrdenesDeTrabajo_Recursos);
        }
        /// <summary>
        /// Trae todos los ordern de trabajo detalle ya con su lista.
        /// </summary>
        /// <param name="Id_Pedido">id del pedido padre</param>
        /// <returns>lista de detalles de pedido</returns>
        public List<LS_OrdenesDeTrabajo_RecursoResult> Seleccionar_By_OrdenDeTrabajo_LP(long Id_Orden)
        {
            OrdenesDeTrabajo_RecursosLN _objOrdenesDeTrabajo_Recursos = new OrdenesDeTrabajo_RecursosLN();
            return _objOrdenesDeTrabajo_Recursos.Seleccionar_By_OrdenDeTrabajo_LP(Id_Orden);
        }
    }
}