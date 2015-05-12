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
    public class VentaFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta> Seleccionar_All()
        {
            VentaLN objVenta = new VentaLN();
            return objVenta.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta Seleccionar_Id(long Id)
        {
            VentaLN objVenta = new VentaLN();
            return objVenta.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Lista principal de ventas
        /// </summary>
        /// <param name="id_GrupoDeMiembros">Identificativo del grupo de miembros de esta venta</param>
        /// <param name="desde">fecha inicial del periodo a consultar</param>
        /// <param name="hasta">fecha final del periodo a consultar</param>
        /// <returns>Lista del tipo resultado de ventas.</returns>
        public List<LP_VentasResult> Seleccionar_LP(int? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            VentaLN objVenta = new VentaLN();
            return objVenta.Seleccionar_LP(id_GrupoDeMiembros, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta objVenta)
        {
            VentaLN _objVenta = new VentaLN();
            _objVenta.Guardar(objVenta);
        }
        public long Guardar_2(Venta objVenta)
        {
            VentaLN _objVenta = new VentaLN();
            return _objVenta.Guardar_2(objVenta);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Venta objVenta)
        {
            VentaLN _objVenta = new VentaLN();
            _objVenta.Eliminar(objVenta);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta objVenta)
        {
            VentaLN _objVenta = new VentaLN();
            _objVenta.Actualizar(objVenta);
        }
        public List<R_VentasResult> Informe_Ventas(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            VentaLN _objVenta = new VentaLN();
            return _objVenta.Informe_Ventas(id_GrupoDeMiembros, desde, hasta);
        }
    }
}