using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class InventarioFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Inventario> Seleccionar_All()
        {
            InventarioLN objInventario = new InventarioLN();
            return objInventario.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Inventario Seleccionar_Id(long Id)
        {
            InventarioLN objInventario = new InventarioLN();
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
            InventarioLN objInventario = new InventarioLN();
            return objInventario.Seleccionar_LP(estado, id_GrupoDeMiembros, nombre100, id_Bodega, codigo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Inventario objInventario)
        {
            InventarioLN _objInventario = new InventarioLN();
            _objInventario.Guardar(objInventario);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Inventario objInventario)
        {
            InventarioLN _objInventario = new InventarioLN();
            _objInventario.Eliminar(objInventario);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Inventario objInventario)
        {
            InventarioLN _objInventario = new InventarioLN();
            _objInventario.Actualizar(objInventario);
        }
        public bool Mover_Cantidad(long Id_Inventario, decimal Cantidad)
        {
            InventarioLN _objInventario = new InventarioLN();
            return _objInventario.Mover_Cantidad(Id_Inventario, Cantidad);
        }
        public bool Mover_StockMaximo(long Id_Inventario, decimal Stock)
        {
            InventarioLN _objInventario = new InventarioLN();
            return _objInventario.Mover_StockMaximo(Id_Inventario, Stock);
        }
        public bool Mover_StockMinimo(long Id_Inventario, decimal Stock)
        {
            InventarioLN _objInventario = new InventarioLN();
            return _objInventario.Mover_StockMinimo(Id_Inventario, Stock);
        }
        public void CompletarInventario()
        {
            InventarioLN _objInventario = new InventarioLN();
            _objInventario.CompletarInventario(SessionManager.Id_GrupoDeMiembros);
        }
        public List<R_InventarioResult> Reporte_Inventario(long? id_GrupoDeMiembros, long? id_Bodega)
        {
            InventarioLN _objInventario = new InventarioLN();
            return _objInventario.Reporte_Inventario(id_GrupoDeMiembros, id_Bodega);
        }
        public bool Mover_En_Inventario(long Id_InventarioOrigen, decimal Cantidad, long Id_BodegaDestino)
        {
            InventarioLN _objInventario = new InventarioLN();
            return _objInventario.Mover_En_Inventario(Id_InventarioOrigen, Cantidad, Id_BodegaDestino);
        }
    }
}