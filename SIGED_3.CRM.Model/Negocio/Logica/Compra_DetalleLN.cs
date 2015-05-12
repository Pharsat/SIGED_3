using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Struct;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class Compra_DetalleLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Compra_Detalle> Seleccionar_All()
        {
            Compra_DetalleOAD objCompra_Detalle = new Compra_DetalleOAD();
            return objCompra_Detalle.Seleccionar_All();
        }
        public List<LS_Compra_DetalleResult> Seleccionar_By_Compra_LP(long Id_Compra)
        {
            Compra_DetalleOAD objCompra_Detalle = new Compra_DetalleOAD();
            return objCompra_Detalle.Seleccionar_By_Compra_LP(Id_Compra);
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Compra_Detalle Seleccionar_Id(long Id)
        {
            Compra_DetalleOAD objCompra_Detalle = new Compra_DetalleOAD();
            return objCompra_Detalle.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Compra_Detalle objCompra_Detalle)
        {
            try
            {
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    Compra_DetalleOAD _objCompra_Detalle = new Compra_DetalleOAD();
                    InventarioOAD _objInventario = new InventarioOAD();
                    Inventario objInventario = _objInventario.SeleccionarInventarioPorReferencia(objCompra_Detalle.Id_Bodega, objCompra_Detalle.Id_Recurso, SessionManager.Id_GrupoDeMiembros);
                    objInventario.Existencia += objCompra_Detalle.Cantidad;
                    _objInventario.Actualizar(objInventario);
                    EntradaOSalidaOAD _objEntradaOSalida = new EntradaOSalidaOAD();
                    EntradaOSalida objEntradaOSalida = new EntradaOSalida();
                    objEntradaOSalida.Cantiidad = objCompra_Detalle.Cantidad;
                    objEntradaOSalida.Fecha = DateTime.Now;
                    objEntradaOSalida.Id_Bodega_Desde = null;
                    objEntradaOSalida.Id_Bodega_Hasta = objCompra_Detalle.Id_Bodega;
                    objEntradaOSalida.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
                    objEntradaOSalida.Id_Recurso = objCompra_Detalle.Id_Recurso;
                    objEntradaOSalida.Movimiento = TipoMovimiento_Struct.Entrada;
                    objEntradaOSalida.Observaciones = MensajesAplicacion_Struct.ObservacionesMovimientoCompra;
                    objEntradaOSalida.Valor = objCompra_Detalle.ValorUnitario;
                    _objEntradaOSalida.Guardar(objEntradaOSalida);
                    Compra objCompra = new CompraOAD().Seleccionar_Id(objCompra_Detalle.Id_Compra.Value);
                    objCompra_Detalle.Total = objCompra_Detalle.Cantidad * objCompra_Detalle.ValorUnitario;
                    _objCompra_Detalle.Guardar(objCompra_Detalle);
                    List<Compra_Detalle> objDetalles = new Compra_DetalleOAD().Seleccionar_All(objCompra_Detalle.Id_Compra.Value).ToList();
                    objCompra.SubTotal = objDetalles.Sum(p => p.Total);
                    objCompra.Total = (objCompra.SubTotal + ((objCompra.SubTotal * objCompra.IVA) / 100) - ((objCompra.SubTotal * objCompra.Retencion) / 100));
                    objCompra.TotalEnLetras = new Genericos().ValorATexto(objCompra.Total.Value);
                    new CompraOAD().Actualizar(objCompra);
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
        public void Eliminar(Compra_Detalle objCompra_Detalle)
        {
            Compra_DetalleOAD _objCompra_Detalle = new Compra_DetalleOAD();
            _objCompra_Detalle.Eliminar(objCompra_Detalle);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Compra_Detalle objCompra_Detalle)
        {
            Compra_DetalleOAD _objCompra_Detalle = new Compra_DetalleOAD();
            _objCompra_Detalle.Actualizar(objCompra_Detalle);
        }
    }
}