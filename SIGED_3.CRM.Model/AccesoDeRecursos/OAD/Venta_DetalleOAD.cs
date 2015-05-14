using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class Venta_DetalleOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta_Detalle> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Venta_Detalle.ToList();
            }
        }

        public List<Venta_Detalle> Seleccionar_By_Venta(long Id_Venta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Venta_Detalle.Where(p => p.Id_Venta == Id_Venta).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta_Detalle Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Venta_Detalle.Any(p => p.Id == Id))
                {
                    return dc.Venta_Detalle.Single(p => p.Id == Id);
                }
                else
                {
                    return new Venta_Detalle();
                }
            }
        }
        public List<LS_Venta_DetalleResult> Seleccionar_By_Venta_LP(long Id_Venta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Venta_Detalle(Id_Venta).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta_Detalle objVenta_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Venta_Detalle.InsertOnSubmit(objVenta_Detalle);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Venta_Detalle objVenta_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Venta_Detalle _objVenta_Detalle = dc.Venta_Detalle.Single(p => p.Id == objVenta_Detalle.Id);
                dc.Venta_Detalle.DeleteOnSubmit(_objVenta_Detalle);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta_Detalle objVenta_Detalle)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Venta_Detalle _objVenta_Detalle = dc.Venta_Detalle.Single(p => p.Id == objVenta_Detalle.Id);
                _objVenta_Detalle.Id = objVenta_Detalle.Id;
                _objVenta_Detalle.Id_Venta = objVenta_Detalle.Id_Venta;
                _objVenta_Detalle.Id_Producto = objVenta_Detalle.Id_Producto;
                _objVenta_Detalle.Descripccion = objVenta_Detalle.Descripccion;
                _objVenta_Detalle.Cantidad = objVenta_Detalle.Cantidad;
                _objVenta_Detalle.ValorUnitario = objVenta_Detalle.ValorUnitario;
                _objVenta_Detalle.Total = objVenta_Detalle.Total;
                _objVenta_Detalle.Id_Bodega = objVenta_Detalle.Id_Bodega;
                dc.SubmitChanges();
            }
        }
    }
}