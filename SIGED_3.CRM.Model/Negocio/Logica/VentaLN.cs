using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.AccesoDeRecursos.SQL;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Struct;

namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class VentaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta> Seleccionar_All()
        {
            VentaOAD objVenta = new VentaOAD();
            return objVenta.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta Seleccionar_Id(long Id)
        {
            VentaOAD objVenta = new VentaOAD();
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
            VentaOAD objVenta = new VentaOAD();
            return objVenta.Seleccionar_LP(id_GrupoDeMiembros, desde, hasta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta objVenta)
        {
            VentaOAD _objVenta = new VentaOAD();
            _objVenta.Guardar(objVenta);
        }
        public long Guardar_2(Venta objVenta)
        {
            try
            {
                long Id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    VentaOAD _objVenta = new VentaOAD();
                    objVenta.Consecutivo = new ConsecutivosLN().TomarConsecutivo((long)Modulo_Enum.Ventas, objVenta.Id_GrupoDeMiembros.Value);
                    objVenta.IVA = 0;
                    objVenta.Retencion = 0;
                    objVenta.SubTotal = 0;
                    objVenta.Total = 0;
                    objVenta.TotalEnLetras = new Genericos().ValorATexto(objVenta.Total.Value);
                    Id = _objVenta.Guardar_2(objVenta);
                    objTransacion.Complete();
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Venta objVenta)
        {
            VentaOAD _objVenta = new VentaOAD();
            _objVenta.Eliminar(objVenta);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta objVenta)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    VentaOAD _objVenta = new VentaOAD();
                    List<Venta_Detalle> objDetalles = new Venta_DetalleOAD().Seleccionar_By_Venta(objVenta.Id).ToList();
                    objVenta.SubTotal = objDetalles.Sum(p => p.Total);
                    objVenta.Total = (objVenta.SubTotal + ((objVenta.SubTotal * objVenta.IVA) / 100) - ((objVenta.SubTotal * objVenta.Retencion) / 100));
                    objVenta.TotalEnLetras = new Genericos().ValorATexto(objVenta.Total.Value);
                    _objVenta.Actualizar(objVenta);

                    objTransacion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_VentasResult> Informe_Ventas(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            try
            {
                VentaOAD _objVenta = new VentaOAD();
                return _objVenta.Informe_Ventas(id_GrupoDeMiembros, desde, hasta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Impresion_Venta(long? Id_Venta)
        {
            VentaOAD _objVenta = new VentaOAD();
            return _objVenta.Impresion_Venta(Id_Venta);
        }
        public DataTable Impresion_Venta_Detalle(long? Id_Venta)
        {
            VentaOAD _objVenta = new VentaOAD();
            return _objVenta.Impresion_Venta_Detalle(Id_Venta);
        }
    }
}