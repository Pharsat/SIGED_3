using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Model.Util.Struct;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class InventarioLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Inventario> Seleccionar_All()
        {
            InventarioOAD objInventario = new InventarioOAD();
            return objInventario.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Inventario Seleccionar_Id(long Id)
        {
            InventarioOAD objInventario = new InventarioOAD();
            return objInventario.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Metodo para traer la lista principal del inventario del sistema.
        /// </summary>
        /// <param name="estado">Estado del objeto de inventario</param>
        /// <param name="id_GrupoDeMiembros">Identificador del grupo al cual pertencec el inventario</param>
        /// <param name="nombre100">Nombre del recurso en el inventario</param>
        /// <param name="id_Proveedor">Identificador del proveedor al cual pertenece el recurso</param>
        /// <param name="id_Bodega">Identificador de la bodega donde esta el recurso</param>
        /// <param name="codigo">Codigo de la prenda, segun ficha tecnica</param>
        /// <returns>Lista de items en el inventario</returns>
        public List<LP_InventarioResult> Seleccionar_LP(bool? estado, int? id_GrupoDeMiembros, string nombre100, int? id_Bodega, string codigo)
        {
            InventarioOAD objInventario = new InventarioOAD();
            if (id_Bodega.HasValue)
            {
                if (id_Bodega.Value.ToString() == (0).ToString())
                {
                    id_Bodega = null;
                }
            }
            return objInventario.Seleccionar_LP(estado, id_GrupoDeMiembros, nombre100, id_Bodega, codigo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Inventario objInventario)
        {
            InventarioOAD _objInventario = new InventarioOAD();
            _objInventario.Guardar(objInventario);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Inventario objInventario)
        {
            InventarioOAD _objInventario = new InventarioOAD();
            _objInventario.Eliminar(objInventario);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Inventario objInventario)
        {
            InventarioOAD _objInventario = new InventarioOAD();
            _objInventario.Actualizar(objInventario);
        }
        public bool Mover_Cantidad(long Id_Inventario, decimal Cantidad)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Inventario _objInventario = this.Seleccionar_Id(Id_Inventario);
                    if ((_objInventario.Existencia + Cantidad) >= _objInventario.Stock_Minimo && (_objInventario.Existencia + Cantidad) <= _objInventario.Stock_Maximo && _objInventario.Estado == true)
                    {
                        _objInventario.Existencia = _objInventario.Existencia + Cantidad;
                        this.Actualizar(_objInventario);

                        EntradaOSalidaOAD _objEntradaOSalida = new EntradaOSalidaOAD();
                        EntradaOSalida objEntradaOSalida = new EntradaOSalida();
                        objEntradaOSalida.Cantiidad = Cantidad;
                        objEntradaOSalida.Fecha = DateTime.Now.ToUniversalTime();
                        if (Cantidad < 0)
                        {
                            objEntradaOSalida.Id_Bodega_Desde = _objInventario.Id_Bodega;
                            objEntradaOSalida.Id_Bodega_Hasta = null;
                            objEntradaOSalida.Movimiento = TipoMovimiento_Struct.Salida;
                        }
                        else
                        {
                            objEntradaOSalida.Id_Bodega_Desde = null;
                            objEntradaOSalida.Id_Bodega_Hasta = _objInventario.Id_Bodega;
                            objEntradaOSalida.Movimiento = TipoMovimiento_Struct.Entrada;
                        }
                        objEntradaOSalida.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
                        objEntradaOSalida.Id_Recurso = _objInventario.Id_Recurso;
                        objEntradaOSalida.Observaciones = MensajesAplicacion_Struct.ObservacionesMovimientoInventariManual;
                        objEntradaOSalida.Valor = 0m;
                        _objEntradaOSalida.Guardar(objEntradaOSalida);

                        objTransaccion.Complete();
                        return true;
                    }
                    else
                    {
                        objTransaccion.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Mover_StockMaximo(long Id_Inventario, decimal Stock)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Inventario _objInventario = this.Seleccionar_Id(Id_Inventario);
                    if (_objInventario.Existencia <= Stock && _objInventario.Stock_Minimo <= Stock && _objInventario.Estado == true)
                    {
                        _objInventario.Stock_Maximo = Stock;
                        this.Actualizar(_objInventario);
                        objTransaccion.Complete();
                        return true;
                    }
                    else
                    {
                        objTransaccion.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Mover_StockMinimo(long Id_Inventario, decimal Stock)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Inventario _objInventario = this.Seleccionar_Id(Id_Inventario);
                    if (_objInventario.Existencia >= Stock && _objInventario.Stock_Maximo >= Stock && _objInventario.Estado == true)
                    {
                        _objInventario.Stock_Minimo = Stock;
                        this.Actualizar(_objInventario);
                        objTransaccion.Complete();
                        return true;
                    }
                    else
                    {
                        objTransaccion.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ExisteInventario(long? Id_GrupoDeMiembros, long? Id_Bodega, long? Id_Recurso)
        {
            return new InventarioOAD().ExisteInventario(Id_GrupoDeMiembros, Id_Bodega, Id_Recurso);
        }
        public void CompletarInventario(long? Id_GrupoDeMiembros)
        {
            try
            {
                TransactionOptions transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
                transactionOptions.Timeout = TimeSpan.MaxValue;
                using (TransactionScope objTransaccion = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    List<Recurso> lstRecursosNoEnInventario = new RecursoOAD().Seleccionar_RecursosQueNoEstanEnInventario(Id_GrupoDeMiembros);
                    List<Bodega> lstBodegas = new BodegaOAD().Seleccionar_All_Activos(Id_GrupoDeMiembros, null);

                    foreach (Bodega objBodega in lstBodegas)
                    {
                        foreach (Recurso objRecurso in lstRecursosNoEnInventario)
                        {
                            Inventario _objInventario = new Inventario();
                            _objInventario.Id_Recurso = objRecurso.Id;
                            _objInventario.Id_Bodega = objBodega.Id;
                            _objInventario.Id_GrupoDeMiemros = Id_GrupoDeMiembros;
                            _objInventario.Estado = true;
                            _objInventario.Existencia = 0;
                            _objInventario.Stock_Maximo = 0;
                            _objInventario.Stock_Minimo = 0;
                            if (!this.ExisteInventario(_objInventario.Id_GrupoDeMiemros, _objInventario.Id_Bodega, objRecurso.Id))
                            {
                                this.Guardar(_objInventario);
                            }
                        }
                    }
                    objTransaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_InventarioResult> Reporte_Inventario(long? id_GrupoDeMiembros, long? id_Bodega)
        {
            InventarioOAD _objInventario = new InventarioOAD();
            return _objInventario.Reporte_Inventario(id_GrupoDeMiembros, id_Bodega);
        }

        public Inventario SeleccionarInventarioPorReferencia(long? Id_Bodega, long? Id_Recurso, long? Id_GrupoDeMiembros)
        {
            InventarioOAD _objInventarioOAD = new InventarioOAD();
            return _objInventarioOAD.SeleccionarInventarioPorReferencia(Id_Bodega, Id_Recurso, Id_GrupoDeMiembros);
        }

        public bool Mover_En_Inventario(long Id_InventarioOrigen, decimal Cantidad, long Id_BodegaDestino)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    Inventario objInventarioOrigen = this.Seleccionar_Id(Id_InventarioOrigen);
                    if (objInventarioOrigen.Id_Bodega != Id_BodegaDestino)
                    {
                        if (this.ExisteInventario(objInventarioOrigen.Id_GrupoDeMiemros, Id_BodegaDestino, objInventarioOrigen.Id_Recurso))
                        {
                            Inventario objInventarioDestino = this.SeleccionarInventarioPorReferencia(Id_BodegaDestino, objInventarioOrigen.Id_Recurso, objInventarioOrigen.Id_GrupoDeMiemros);
                            objInventarioDestino.Existencia += Cantidad;
                            objInventarioOrigen.Existencia -= Cantidad;
                            this.Actualizar(objInventarioDestino);
                            this.Actualizar(objInventarioOrigen);

                            BodegaOAD objBodegaOAD = new BodegaOAD();
                            Bodega objBodegaOrigen = objBodegaOAD.Seleccionar_Id(objInventarioOrigen.Id_Bodega.Value);
                            Bodega objBodegaDestino = objBodegaOAD.Seleccionar_Id(objInventarioDestino.Id_Bodega.Value);

                            EntradaOSalidaOAD _objEntradaOSalida = new EntradaOSalidaOAD();
                            EntradaOSalida objEntradaOSalida = new EntradaOSalida();
                            objEntradaOSalida.Cantiidad = Cantidad;
                            objEntradaOSalida.Fecha = DateTime.Now.ToUniversalTime();
                            objEntradaOSalida.Id_Bodega_Desde = objInventarioOrigen.Id_Bodega;
                            objEntradaOSalida.Id_Bodega_Hasta = objInventarioDestino.Id_Bodega;
                            objEntradaOSalida.Movimiento = TipoMovimiento_Struct.MoVimientoEntreBodegas;
                            objEntradaOSalida.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
                            objEntradaOSalida.Id_Recurso = objInventarioOrigen.Id_Recurso;
                            objEntradaOSalida.Observaciones = string.Format(MensajesAplicacion_Struct.ObservacionesMovimientoEntreBodega, new string[] { objBodegaOrigen.Nombre, objBodegaDestino.Nombre });
                            objEntradaOSalida.Valor = 0m;
                            _objEntradaOSalida.Guardar(objEntradaOSalida);

                            objTransaccion.Complete();
                            return true;
                        }
                        else
                        {
                            objTransaccion.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        objTransaccion.Dispose();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}