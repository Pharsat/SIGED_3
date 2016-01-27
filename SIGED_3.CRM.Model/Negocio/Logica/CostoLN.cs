using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CostoLn
    {

        public List<Costo> Seleccionar_All()
        {
            var objCosto = new CostoOad();
            return objCosto.Seleccionar_All();
        }

        public Costo Seleccionar_Id(long id)
        {
            var objCosto = new CostoOad();
            return objCosto.Seleccionar_Id(id);
        }

        public Costo Seleccionar_Id_Recurso(long idRecurso)
        {
            var objCosto = new CostoOad();
            return objCosto.Seleccionar_Id_Recurso(idRecurso);
        }

        public List<LP_CostosResult> Seleccionar_LP(int? idGrupoDeMiembros, string codigo, string tipoPrenda)
        {
            var objCosto = new CostoOad();
            return objCosto.Seleccionar_LP(idGrupoDeMiembros, codigo, tipoPrenda);
        }

        public void Guardar(Costo objCostoAGuardar)
        {
            var objCosto = new CostoOad();
            objCosto.Guardar(objCostoAGuardar);
        }

        public long Guardar_2(Costo objCostoGuardar)
        {
            try
            {
                long id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    var objCosto = new CostoOad();
                    id = objCosto.Guardar_2(objCostoGuardar);
                    string[] costosPredefinidos = new string[] { "Costos Administrativos", "Utilidad", "Comisión", "Descuento" };
                    for (int i = 0; i < costosPredefinidos.Count(); i++)
                    {
                        Costo_Valorizacion objValorizacion = new Costo_Valorizacion
                        {
                            Id_Costo = id,
                            Descripcion = costosPredefinidos[i],
                            Porcentaje = 0,
                            Posicion = i + 1,
                            ValorHastaElMomento = 0
                        };
                        new Costo_ValorizacionLN().Guardar_IgnorarActualizacion(objValorizacion);
                    }
                    objTransacion.Complete();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(Costo objCostoEliminar)
        {
            CostoOad objCosto = new CostoOad();
            objCosto.Eliminar(objCostoEliminar);
        }

        public void Actualizar(Costo objCostoActualizar)
        {
            CostoOad objCosto = new CostoOad();
            objCosto.Actualizar(objCostoActualizar);
        }

        public void Renovar_Valores(long id)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    if (new CostoOad().Existencia_Costo(id))
                    {
                        Costo objCosto = new CostoOad().Seleccionar_Id(id);
                        objCosto.CostoDeProcesos = new CostoProcesoDeFabricacionOad().Seleccionar_By_Id(objCosto.Id).Sum(p => (p.Cantidad * p.Valor));
                        objCosto.CostoDeRecursos = new CostoRecursoOad().Seleccionar_By_Id(objCosto.Id).Sum(p => (p.Consumo * p.ValoUnitario));
                        objCosto.CostoDeProduccion = objCosto.CostoDeProcesos + objCosto.CostoDeRecursos;
                        decimal? totalConValorizacion = objCosto.CostoDeProduccion;
                        List<Costo_Valorizacion> lstCostosValorizacion = new CostoValorizacionOad().Seleccionar_By_Id(objCosto.Id).OrderBy(p => p.Posicion).ToList();
                        foreach (Costo_Valorizacion objCostoValorizacion in lstCostosValorizacion)
                        {
                            totalConValorizacion += ((totalConValorizacion * objCostoValorizacion.Porcentaje) / 100m);
                            objCostoValorizacion.ValorHastaElMomento = totalConValorizacion;
                            new CostoValorizacionOad().Actualizar(objCostoValorizacion);
                        }
                        objCosto.CostoConValirizacion = totalConValorizacion;
                        new CostoOad().Actualizar(objCosto);
                        objTransaccion.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_Costos_CabeceraResult> InformeCostos_Cabecera(long? idGrupoDeMiembros, long? idRecurso)
        {
            var objCosto = new CostoOad();
            return objCosto.InformeCostos_Cabecera(idGrupoDeMiembros, idRecurso);
        }
        public List<R_Costos_ProcesosResult> InformeCostos_Procesos(long? idGrupoDeMiembros, long? idRecurso)
        {
            var objCosto = new CostoOad();
            return objCosto.InformeCostos_Procesos(idGrupoDeMiembros, idRecurso);
        }
        public List<R_Costos_RecursosResult> InformeCostos_Recursos(long? idGrupoDeMiembros, long? idRecurso)
        {
            var objCosto = new CostoOad();
            return objCosto.InformeCostos_Recursos(idGrupoDeMiembros, idRecurso);
        }
        public List<R_Costos_ValorizacionResult> InformeCostos_Valorizacion(long? idGrupoDeMiembros, long? idRecurso)
        {
            var objCosto = new CostoOad();
            return objCosto.InformeCostos_Valorizacion(idGrupoDeMiembros, idRecurso);
        }

        public void MultiplicarCostos(long? idCostoAMultiplicar)
        {
            if (idCostoAMultiplicar.HasValue)
            {
                try
                {
                    var objCosto = Seleccionar_Id(idCostoAMultiplicar.Value);
                    var objCostoProcesos = new Costo_ProcesoDeFabricacionLN().Seleccionar_By_Id_Complete(idCostoAMultiplicar);
                    var objCostoMateriales = new Costo_RecursoLN().Seleccionar_By_Id_Complete(idCostoAMultiplicar);
                    var objCostoPorcentajes = new Costo_ValorizacionLN().Seleccionar_By_Id_Complete(idCostoAMultiplicar);
                    if (objCosto.Id_Recurso != null)
                    {
                        var objRecursoDeCosto = new RecursoLN().Seleccionar_Id(objCosto.Id_Recurso.Value);
                        var recursosAMultiplicar = new RecursoLN().Seleccionar_RecursosQueNoEstanEnCostos(objRecursoDeCosto.Id_FichaTecnica).Where(p => p.Id_FichaTecnica == objRecursoDeCosto.Id_FichaTecnica && p.Id != objCosto.Id_Recurso);

                        foreach (Recurso objRecurso in recursosAMultiplicar)
                        {
                            var newCosto = new Costo
                            {
                                Id_GrupoDeMiembros = objCosto.Id_GrupoDeMiembros,
                                Id_Recurso = objRecurso.Id,
                                FechaDeCreacion = objCosto.FechaDeCreacion,
                                CostoDeRecursos = objCosto.CostoDeRecursos,
                                CostoDeProcesos = objCosto.CostoDeProcesos,
                                CostoDeProduccion = objCosto.CostoDeProduccion,
                                CostoConValirizacion = objCosto.CostoConValirizacion,
                                PrecioVentaFinal = objCosto.PrecioVentaFinal,
                                PrecioPublico = objCosto.PrecioPublico,
                                PrecioDistrbuidor = objCosto.PrecioDistrbuidor
                            };

                            var idCosto = Guardar_2(newCosto);

                            foreach (var objCostoRecurso in objCostoMateriales)
                            {
                                var newCostoRecurso = new Costo_Recurso
                                {
                                    Id_Costo = idCosto,
                                    Id_Recurso = objCostoRecurso.Id_Recurso,
                                    Id_UnidadDeMedida = objCostoRecurso.Id_UnidadDeMedida,
                                    Consumo = objCostoRecurso.Consumo,
                                    ValoUnitario = objCostoRecurso.ValoUnitario
                                };
                                new Costo_RecursoLN().GuardarCopia(newCostoRecurso);
                            }

                            foreach (Costo_Valorizacion objCostoPorcentaje in objCostoPorcentajes)
                            {
                                var newCostoConPorcentaje = new Costo_Valorizacion
                                {
                                    Id_Costo = idCosto,
                                    Descripcion = objCostoPorcentaje.Descripcion,
                                    Porcentaje = objCostoPorcentaje.Porcentaje,
                                    Posicion = objCostoPorcentaje.Posicion,
                                    ValorHastaElMomento = objCostoPorcentaje.ValorHastaElMomento
                                };
                                new Costo_ValorizacionLN().GuardarCopia(newCostoConPorcentaje);
                            }

                            foreach (Costo_ProcesoDeFabricacion objCostoRecurso in objCostoProcesos)
                            {
                                var newCostoProceso = new Costo_ProcesoDeFabricacion
                                {
                                    Id_Costo = idCosto,
                                    Id_Proceso = objCostoRecurso.Id_Proceso,
                                    Id_UnidadDeMedida = objCostoRecurso.Id_UnidadDeMedida,
                                    Cantidad = objCostoRecurso.Cantidad,
                                    Valor = objCostoRecurso.Valor
                                };
                                new Costo_ProcesoDeFabricacionLN().GuardarCopia(newCostoProceso);
                            }

                            new CostoLn().Renovar_Valores(newCosto.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<R_UtilidadesResult> Informe_Utilidades(long? idGrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            var objCosto = new CostoOad();
            return objCosto.Informe_Utilidades(idGrupoDeMiembros, desde, hasta);
        }

        public DataTable Impresion_Lista_Precios(long? idGrupoDeMiembros)
        {
            var objCosto = new CostoOad();
            return objCosto.Impresion_Lista_Precios(idGrupoDeMiembros);
        }

        public DataTable Impresion_Lista_Precios_2(long? idGrupoDeMiembros, short? selector)
        {
            var objCosto = new CostoOad();
            return objCosto.Impresion_Lista_Precios_2(idGrupoDeMiembros, selector);
        }
    }
}