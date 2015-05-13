using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Model.Util.Struct;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Venta_DetalleLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Venta_Detalle> Seleccionar_All()
        {
            Venta_DetalleOAD objVenta_Detalle = new Venta_DetalleOAD();
            return objVenta_Detalle.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Venta_Detalle Seleccionar_Id(long Id)
        {
            Venta_DetalleOAD objVenta_Detalle = new Venta_DetalleOAD();
            return objVenta_Detalle.Seleccionar_Id(Id);
        }
        public List<LS_Venta_DetalleResult> Seleccionar_By_Venta_LP(long Id_Venta)
        {
            Venta_DetalleOAD objVenta_Detalle = new Venta_DetalleOAD();
            return objVenta_Detalle.Seleccionar_By_Venta_LP(Id_Venta);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Venta_Detalle objVenta_Detalle)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    InventarioOAD _objInventario = new InventarioOAD();
                    Inventario objInventario = _objInventario.SeleccionarInventarioPorReferencia(objVenta_Detalle.Id_Bodega, objVenta_Detalle.Id_Producto, SessionManager.Id_GrupoDeMiembros);
                    objInventario.Existencia -= objVenta_Detalle.Cantidad;
                    _objInventario.Actualizar(objInventario);
                    EntradaOSalidaOAD _objEntradaOSalida = new EntradaOSalidaOAD();
                    EntradaOSalida objEntradaOSalida = new EntradaOSalida();
                    objEntradaOSalida.Cantiidad = objVenta_Detalle.Cantidad;
                    objEntradaOSalida.Fecha = DateTime.Now.ToUniversalTime();
                    objEntradaOSalida.Id_Bodega_Desde = null;
                    objEntradaOSalida.Id_Bodega_Hasta = objVenta_Detalle.Id_Bodega;
                    objEntradaOSalida.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
                    objEntradaOSalida.Id_Recurso = objVenta_Detalle.Id_Producto;
                    objEntradaOSalida.Movimiento = TipoMovimiento_Struct.Salida;
                    objEntradaOSalida.Observaciones = MensajesAplicacion_Struct.ObservacionesMovimientoVenta;
                    objEntradaOSalida.Valor = objVenta_Detalle.ValorUnitario;
                    _objEntradaOSalida.Guardar(objEntradaOSalida);
                    Venta objVenta = new VentaOAD().Seleccionar_Id(objVenta_Detalle.Id_Venta.Value);
                    Venta_DetalleOAD _objVenta_Detalle = new Venta_DetalleOAD();
                    objVenta_Detalle.Total = objVenta_Detalle.Cantidad * objVenta_Detalle.ValorUnitario;
                    _objVenta_Detalle.Guardar(objVenta_Detalle);
                    List<Venta_Detalle> objDetalles = new Venta_DetalleOAD().Seleccionar_All().ToList();
                    objVenta.SubTotal = objDetalles.Sum(p => p.Total);
                    objVenta.Total = (objVenta.SubTotal + ((objVenta.SubTotal * objVenta.IVA) / 100) - ((objVenta.SubTotal * objVenta.Retencion) / 100));
                    objVenta.TotalEnLetras = new Genericos().ValorATexto(objVenta.Total.Value);
                    new VentaOAD().Actualizar(objVenta);
                    objTransacion.Complete();
                }
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
        public void Eliminar(Venta_Detalle objVenta_Detalle)
        {
            Venta_DetalleOAD _objVenta_Detalle = new Venta_DetalleOAD();
            _objVenta_Detalle.Eliminar(objVenta_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Venta_Detalle objVenta_Detalle)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    Venta objVenta = new VentaOAD().Seleccionar_Id(objVenta_Detalle.Id_Venta.Value);
                    Venta_DetalleOAD _objVenta_Detalle = new Venta_DetalleOAD();
                    objVenta_Detalle.Total = objVenta_Detalle.Cantidad * objVenta_Detalle.ValorUnitario;
                    _objVenta_Detalle.Actualizar(objVenta_Detalle);
                    List<Venta_Detalle> objDetalles = new Venta_DetalleOAD().Seleccionar_All().ToList();
                    objVenta.SubTotal = objDetalles.Sum(p => p.Total);
                    objVenta.Total = (objVenta.SubTotal + ((objVenta.SubTotal * objVenta.IVA) / 100) - ((objVenta.SubTotal * objVenta.Retencion) / 100));
                    objVenta.TotalEnLetras = new Genericos().ValorATexto(objVenta.Total.Value);
                    new VentaOAD().Actualizar(objVenta);
                    objTransacion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}