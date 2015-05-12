using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class EntradaOSalidaOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<EntradaOSalida> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.EntradaOSalida.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public EntradaOSalida Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.EntradaOSalida.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Lista principal de movimientos en el inventario-
        /// </summary>
        /// <param name="id_GrupoDeMiembros">Id del grupo al que pertenece el usuario</param>
        /// <param name="ultimosE">Cantidad de ultimas entradas a ver</param>
        /// <param name="ultimosS">Cantidad de ultimas salidas a ver</param>
        /// <param name="nombre50">Nombre del recurso</param>
        /// <param name="desde">Fecha desde a buscar los movimientos de los recursos</param>
        /// <param name="hasta">Fecha hasta a buscar los movimientos de los recursos</param>
        /// <param name="codigo">Codigo dela prenda segu ficha tecnica</param>
        /// <returns>Lista de resultados de entradas o salidas</returns>
        public List<LP_EntradasOSalidasResult> Seleccionar_LP(int? id_GrupoDeMiembros, string nombre50, DateTime? desde, DateTime? hasta, string codigo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_EntradasOSalidas(id_GrupoDeMiembros,  nombre50, desde, hasta, codigo).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(EntradaOSalida objEntradaOSalida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.EntradaOSalida.InsertOnSubmit(objEntradaOSalida);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(EntradaOSalida objEntradaOSalida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                EntradaOSalida _objEntradaOSalida = dc.EntradaOSalida.Single(p => p.Id == objEntradaOSalida.Id);
                dc.EntradaOSalida.DeleteOnSubmit(_objEntradaOSalida);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(EntradaOSalida objEntradaOSalida)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                EntradaOSalida _objEntradaOSalida = dc.EntradaOSalida.Single(p => p.Id == objEntradaOSalida.Id);
                _objEntradaOSalida.Id = objEntradaOSalida.Id;
                _objEntradaOSalida.Id_GrupoDeMiembros = objEntradaOSalida.Id_GrupoDeMiembros;
                _objEntradaOSalida.Id_Recurso = objEntradaOSalida.Id_Recurso;
                _objEntradaOSalida.Id_Bodega_Desde = objEntradaOSalida.Id_Bodega_Desde;
                _objEntradaOSalida.Id_Bodega_Hasta = objEntradaOSalida.Id_Bodega_Hasta;
                _objEntradaOSalida.Movimiento = objEntradaOSalida.Movimiento;
                _objEntradaOSalida.Cantiidad = objEntradaOSalida.Cantiidad;
                _objEntradaOSalida.Valor = objEntradaOSalida.Valor;
                _objEntradaOSalida.Fecha = objEntradaOSalida.Fecha;
                _objEntradaOSalida.Observaciones = objEntradaOSalida.Observaciones;
                dc.SubmitChanges();
            }
        }
    }
}