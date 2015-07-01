using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.AccesoDeRecursos.SQL;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Struct;

namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class VentaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Venta.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Venta.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Ventas(id_GrupoDeMiembros, desde, hasta).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta objVenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Venta.InsertOnSubmit(objVenta);
                dc.SubmitChanges();
            }
        }
        public long Guardar_2(Venta objVenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Venta.InsertOnSubmit(objVenta);
                dc.SubmitChanges();
                return dc.Venta.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Venta objVenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Venta _objVenta = dc.Venta.Single(p => p.Id == objVenta.Id);
                dc.Venta.DeleteOnSubmit(_objVenta);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta objVenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Venta _objVenta = dc.Venta.Single(p => p.Id == objVenta.Id);
                _objVenta.Id = objVenta.Id;
                _objVenta.Id_GrupoDeMiembros = objVenta.Id_GrupoDeMiembros;
                _objVenta.Id_Facturador = objVenta.Id_Facturador;
                _objVenta.Id_Cliente = objVenta.Id_Cliente;
                _objVenta.Consecutivo = objVenta.Consecutivo;
                _objVenta.FechaDeRealizacion = objVenta.FechaDeRealizacion;
                _objVenta.SubTotal = objVenta.SubTotal;
                _objVenta.Total = objVenta.Total;
                _objVenta.IVA = objVenta.IVA;
                _objVenta.Retencion = objVenta.Retencion;
                _objVenta.TotalEnLetras = objVenta.TotalEnLetras;
                _objVenta.Observaciones = objVenta.Observaciones;
                _objVenta.TipoPrecioVenta = objVenta.TipoPrecioVenta;
                dc.SubmitChanges();
            }
        }
        public List<R_VentasResult> Informe_Ventas(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Ventas(id_GrupoDeMiembros, desde, hasta).ToList();
            }
        }

        public DataTable Impresion_Venta(long? Id_Venta)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Venta) }, ProcedimientosAlmacenados.I_Venta);
        }
        public DataTable Impresion_Venta_Detalle(long? Id_Venta)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { new ParametrosBD("Id", Id_Venta) }, ProcedimientosAlmacenados.I_Venta_Detalle);
        }
    }
}