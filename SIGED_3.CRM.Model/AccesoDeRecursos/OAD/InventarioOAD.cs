using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class InventarioOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Inventario> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Inventario.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Inventario Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Inventario.Single(p => p.Id == Id);
            }
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
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Inventario(estado, id_GrupoDeMiembros, nombre100, id_Bodega, codigo).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Inventario objInventario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Inventario.InsertOnSubmit(objInventario);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Inventario objInventario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Inventario _objInventario = dc.Inventario.Single(p => p.Id == objInventario.Id);
                dc.Inventario.DeleteOnSubmit(_objInventario);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Inventario objInventario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Inventario _objInventario = dc.Inventario.Single(p => p.Id == objInventario.Id);
                _objInventario.Id = objInventario.Id;
                _objInventario.Id_GrupoDeMiemros = objInventario.Id_GrupoDeMiemros;
                _objInventario.Id_Recurso = objInventario.Id_Recurso;
                _objInventario.Id_Bodega = objInventario.Id_Bodega;
                _objInventario.Existencia = objInventario.Existencia;
                _objInventario.Stock_Minimo = objInventario.Stock_Minimo;
                _objInventario.Stock_Maximo = objInventario.Stock_Maximo;
                _objInventario.Estado = objInventario.Estado;
                dc.SubmitChanges();
            }
        }
        public bool ExisteInventario(long? Id_GrupoDeMiembros, long? Id_Bodega, long? Id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Inventario.Any(p => p.Id_Bodega == Id_Bodega && p.Id_GrupoDeMiemros == Id_GrupoDeMiembros && p.Id_Recurso == Id_Recurso);
            }
        }
        public Inventario SeleccionarInventarioPorReferencia(long? Id_Bodega, long? Id_Recurso, long? Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (!dc.Inventario.Any(p => p.Id_Bodega == Id_Bodega && p.Id_Recurso == Id_Recurso && p.Id_GrupoDeMiemros == Id_GrupoDeMiembros))
                {
                    Inventario objInventario = new Inventario();
                    objInventario.Id_Bodega = Id_Bodega;
                    objInventario.Id_GrupoDeMiemros = Id_GrupoDeMiembros;
                    objInventario.Id_Recurso = Id_Recurso;
                    objInventario.Existencia = 0;
                    objInventario.Estado = true;
                    objInventario.Stock_Maximo = 0;
                    objInventario.Stock_Minimo = 0;
                    dc.Inventario.InsertOnSubmit(objInventario);
                    dc.SubmitChanges();
                }
                return dc.Inventario.Where(p => p.Id_Bodega == Id_Bodega && p.Id_Recurso == Id_Recurso && p.Id_GrupoDeMiemros == Id_GrupoDeMiembros).Single();
            }
        }
        public List<R_InventarioResult> Reporte_Inventario(long? id_GrupoDeMiembros, long? id_Bodega)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Inventario(id_GrupoDeMiembros, id_Bodega).ToList();
            }
        }
    }
}