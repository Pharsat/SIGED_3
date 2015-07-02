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
    internal class CostoOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// obtiene el costo asociado al recurso mencionado.
        /// </summary>
        /// <param name="Id_Recurso">recurso que deberia estar ligado a un costo</param>
        /// <returns>objeto costo</returns>
        public Costo Seleccionar_Id_Recurso(long Id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Costo.Any(p => p.Id_Recurso == Id_Recurso))
                {
                    return dc.Costo.Single(p => p.Id_Recurso == Id_Recurso);
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Lista principal de controles
        /// </summary>
        /// <param name="estado">Estado del costo</param>
        /// <param name="id_GrupoDeMiembros">Id grupo de miembros</param>
        /// <param name="codigo">codigo de la prenda segun ficha tecnica</param>
        /// <param name="tipoPrenda">tipo de la prenda segun ficha tecnica</param>
        /// <returns>Lista principal de costos</returns>
        public List<LP_CostosResult> Seleccionar_LP(int? id_GrupoDeMiembros, string codigo, string tipoPrenda)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Costos(id_GrupoDeMiembros, codigo, tipoPrenda).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo objCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo.InsertOnSubmit(objCosto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto Costo y obtiene su Id
        /// </summary>
        /// <param name="objCosto">Licnete a guardar</param>
        public long Guardar_2(Costo objCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Costo.InsertOnSubmit(objCosto);
                dc.SubmitChanges();
                return dc.Costo.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo objCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo _objCosto = dc.Costo.Single(p => p.Id == objCosto.Id);
                dc.Costo.DeleteOnSubmit(_objCosto);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo objCosto)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo _objCosto = dc.Costo.Single(p => p.Id == objCosto.Id);
                _objCosto.Id = objCosto.Id;
                _objCosto.Id_GrupoDeMiembros = objCosto.Id_GrupoDeMiembros;
                _objCosto.Id_Recurso = objCosto.Id_Recurso;
                _objCosto.FechaDeCreacion = objCosto.FechaDeCreacion;
                _objCosto.CostoDeRecursos = objCosto.CostoDeRecursos;
                _objCosto.CostoDeProcesos = objCosto.CostoDeProcesos;
                _objCosto.CostoDeProduccion = objCosto.CostoDeProduccion;
                _objCosto.CostoConValirizacion = objCosto.CostoConValirizacion;
                _objCosto.PrecioVentaFinal = objCosto.PrecioVentaFinal;
                _objCosto.PrecioPublico = objCosto.PrecioPublico;
                _objCosto.PrecioDistrbuidor = objCosto.PrecioDistrbuidor;
                dc.SubmitChanges();
            }
        }
        public bool Existencia_Costo(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo.Any(p => p.Id == Id);
            }
        }
        public List<R_Costos_CabeceraResult> InformeCostos_Cabecera(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Costos_Cabecera(id_GrupoDeMiembros,id_Recurso).ToList();
            }
        }
        public List<R_Costos_ProcesosResult> InformeCostos_Procesos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Costos_Procesos(id_GrupoDeMiembros, id_Recurso).ToList();
            }
        }
        public List<R_Costos_RecursosResult> InformeCostos_Recursos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Costos_Recursos(id_GrupoDeMiembros, id_Recurso).ToList();
            }
        }
        public List<R_Costos_ValorizacionResult> InformeCostos_Valorizacion(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Costos_Valorizacion(id_GrupoDeMiembros, id_Recurso).ToList();
            }
        }
        public List<R_UtilidadesResult> Informe_Utilidades(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.R_Utilidades(id_GrupoDeMiembros, desde, hasta).ToList();
            }
        }

        public DataTable Impresion_Lista_Precios(long? Id_GrupoDeMiembros)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { 
                new ParametrosBD("Id_GrupoDeMiembros", Id_GrupoDeMiembros) }, ProcedimientosAlmacenados.R_Lista_Precios);
        }
        public DataTable Impresion_Lista_Precios_2(long? Id_GrupoDeMiembros, short? Selector)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { 
                new ParametrosBD("Id_GrupoDeMiembros", Id_GrupoDeMiembros), 
                new ParametrosBD("Selector", Selector) }, ProcedimientosAlmacenados.R_Lista_Precios_2);
        }
    }
}