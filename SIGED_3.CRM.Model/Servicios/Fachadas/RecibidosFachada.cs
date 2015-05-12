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
    public class RecibidosFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Recibidos> Seleccionar_All()
        {
            RecibidosLN objRecibidos = new RecibidosLN();
            return objRecibidos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Recibidos Seleccionar_Id(long Id)
        {
            RecibidosLN objRecibidos = new RecibidosLN();
            return objRecibidos.Seleccionar_Id(Id);
        }
        public List<LP_RecibidosResult> Seleccionar_LP(long? estado, long? id_Cliente, long? consecutivo, DateTime? desde, DateTime? hasta)
        {
            RecibidosLN objRecibidos = new RecibidosLN();
            return objRecibidos.Seleccionar_LP(estado, id_Cliente, consecutivo, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Recibidos objRecibidos)
        {
            RecibidosLN _objRecibidos = new RecibidosLN();
            _objRecibidos.Guardar(objRecibidos);
        }
        public long Guardar_2(Recibidos objRecibidos)
        {
            RecibidosLN _objRecibidos = new RecibidosLN();
            return _objRecibidos.Guardar_2(objRecibidos);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Recibidos objRecibidos)
        {
            RecibidosLN _objRecibidos = new RecibidosLN();
            _objRecibidos.Eliminar(objRecibidos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Recibidos objRecibidos)
        {
            RecibidosLN _objRecibidos = new RecibidosLN();
            _objRecibidos.Actualizar(objRecibidos);
        }
        public void IncluirARecibidosOrdenesDetalles(long Id_OrdenDeTrabajo, long Id_Recibido)
        {
            RecibidosLN _objRecibidos = new RecibidosLN();
            _objRecibidos.IncluirARecibidosOrdenesDetalles(Id_OrdenDeTrabajo, Id_Recibido);
        }
    }
}