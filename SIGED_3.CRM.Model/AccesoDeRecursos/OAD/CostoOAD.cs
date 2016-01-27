namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using SQL;
    using Negocio.Entidades;
    using Util.Struct;

    internal class CostoOad
    {
        public List<Costo> Seleccionar_All()
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo.ToList();
            }
        }

        public Costo Seleccionar_Id(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo.Single(p => p.Id == id);
            }
        }

        public Costo Seleccionar_Id_Recurso(long idRecurso)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo.SingleOrDefault(p => p.Id_Recurso == idRecurso);
            }
        }

        public List<LP_CostosResult> Seleccionar_LP(int? idGrupoDeMiembros, string codigo, string tipoPrenda)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.LP_Costos(idGrupoDeMiembros, codigo, tipoPrenda).ToList();
            }
        }


        public void Guardar(Costo objCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                dc.Costo.InsertOnSubmit(objCosto);
                dc.SubmitChanges();
            }
        }

        public long Guardar_2(Costo objCosto)
        {
            using (var dc = new ModeloDataContext())
            {
                dc.Costo.InsertOnSubmit(objCosto);
                dc.SubmitChanges();
                return dc.Costo.Max(p => p.Id);
            }
        }

        public void Eliminar(Costo costo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Costo objCosto = dc.Costo.Single(p => p.Id == costo.Id);
                dc.Costo.DeleteOnSubmit(objCosto);
                dc.SubmitChanges();
            }
        }

        public void Actualizar(Costo costoAActualizar)
        {
            using (var dc = new ModeloDataContext())
            {
                Costo objCosto = dc.Costo.Single(p => p.Id == costoAActualizar.Id);
                objCosto.Id = costoAActualizar.Id;
                objCosto.Id_GrupoDeMiembros = costoAActualizar.Id_GrupoDeMiembros;
                objCosto.Id_Recurso = costoAActualizar.Id_Recurso;
                objCosto.FechaDeCreacion = costoAActualizar.FechaDeCreacion;
                objCosto.CostoDeRecursos = costoAActualizar.CostoDeRecursos;
                objCosto.CostoDeProcesos = costoAActualizar.CostoDeProcesos;
                objCosto.CostoDeProduccion = costoAActualizar.CostoDeProduccion;
                objCosto.CostoConValirizacion = costoAActualizar.CostoConValirizacion;
                objCosto.PrecioVentaFinal = costoAActualizar.PrecioVentaFinal;
                objCosto.PrecioPublico = costoAActualizar.PrecioPublico;
                objCosto.PrecioDistrbuidor = costoAActualizar.PrecioDistrbuidor;
                dc.SubmitChanges();
            }
        }

        public bool Existencia_Costo(long id)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.Costo.Any(p => p.Id == id);
            }
        }

        public List<R_Costos_CabeceraResult> InformeCostos_Cabecera(long? idGrupoDeMiembros, long? idRecurso)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.R_Costos_Cabecera(idGrupoDeMiembros, idRecurso).ToList();
            }
        }

        public List<R_Costos_ProcesosResult> InformeCostos_Procesos(long? idGrupoDeMiembros, long? idRecurso)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.R_Costos_Procesos(idGrupoDeMiembros, idRecurso).ToList();
            }
        }

        public List<R_Costos_RecursosResult> InformeCostos_Recursos(long? idGrupoDeMiembros, long? idRecurso)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.R_Costos_Recursos(idGrupoDeMiembros, idRecurso).ToList();
            }
        }

        public List<R_Costos_ValorizacionResult> InformeCostos_Valorizacion(long? idGrupoDeMiembros, long? idRecurso)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.R_Costos_Valorizacion(idGrupoDeMiembros, idRecurso).ToList();
            }
        }

        public List<R_UtilidadesResult> Informe_Utilidades(long? idGrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            using (var dc = new ModeloDataContext())
            {
                return dc.R_Utilidades(idGrupoDeMiembros, desde, hasta).ToList();
            }
        }

        public DataTable Impresion_Lista_Precios(long? idGrupoDeMiembros)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { 
                new ParametrosBD("Id_GrupoDeMiembros", idGrupoDeMiembros) }, ProcedimientosAlmacenados.R_Lista_Precios);
        }

        public DataTable Impresion_Lista_Precios_2(long? idGrupoDeMiembros, short? selector)
        {
            return new QuerysSQL().Consultar(new List<ParametrosBD> { 
                new ParametrosBD("Id_GrupoDeMiembros", idGrupoDeMiembros), 
                new ParametrosBD("Selector", selector) }, ProcedimientosAlmacenados.R_Lista_Precios_2);
        }
    }
}