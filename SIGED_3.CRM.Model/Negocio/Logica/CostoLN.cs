using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using System.Transactions;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class CostoLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo> Seleccionar_All()
        {
            CostoOAD objCosto = new CostoOAD();
            return objCosto.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo Seleccionar_Id(long Id)
        {
            CostoOAD objCosto = new CostoOAD();
            return objCosto.Seleccionar_Id(Id);
        }
        /// <summary>
        /// obtiene el costo asociado al recurso mencionado.
        /// </summary>
        /// <param name="Id_Recurso">recurso que deberia estar ligado a un costo</param>
        /// <returns>objeto costo</returns>
        public Costo Seleccionar_Id_Recurso(long Id_Recurso)
        {
            CostoOAD objCosto = new CostoOAD();
            return objCosto.Seleccionar_Id_Recurso(Id_Recurso);
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
            CostoOAD objCosto = new CostoOAD();
            return objCosto.Seleccionar_LP(id_GrupoDeMiembros, codigo, tipoPrenda);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo objCosto)
        {
            CostoOAD _objCosto = new CostoOAD();
            _objCosto.Guardar(objCosto);
        }
        /// <summary>
        /// Guarda el objeto Costo y obtiene su Id
        /// </summary>
        /// <param name="objCosto">Licnete a guardar</param>
        public long Guardar_2(Costo objCosto)
        {
            try
            {
                long Id;
                using (TransactionScope objTransacion = new TransactionScope())
                {
                    CostoOAD _objCosto = new CostoOAD();
                    Id = _objCosto.Guardar_2(objCosto);
                    string[] CostosPredefinidos = new string[] { "Costos Administrativos", "Utilidad", "Comisión", "Descuento" };
                    for (int i = 0; i < CostosPredefinidos.Count(); i++)
                    {
                        Costo_Valorizacion objValorizacion = new Costo_Valorizacion();
                        objValorizacion.Id_Costo = Id;
                        objValorizacion.Descripcion = CostosPredefinidos[i];
                        objValorizacion.Porcentaje = 0;
                        objValorizacion.Posicion = i + 1;
                        objValorizacion.ValorHastaElMomento = 0;
                        new Costo_ValorizacionLN().Guardar_IgnorarActualizacion(objValorizacion);
                    }
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
        public void Eliminar(Costo objCosto)
        {
            CostoOAD _objCosto = new CostoOAD();
            _objCosto.Eliminar(objCosto);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo objCosto)
        {
            CostoOAD _objCosto = new CostoOAD();
            _objCosto.Actualizar(objCosto);
        }
        /// <summary>
        /// Actualiza los valores de costos de un costo en particular
        /// </summary>
        /// <param name="objCosto"></param>
        public void Renovar_Valores(long Id)
        {
            try
            {
                using (TransactionScope objTransaccion = new TransactionScope())
                {
                    if (new CostoOAD().Existencia_Costo(Id))
                    {
                        Costo objCosto = new CostoOAD().Seleccionar_Id(Id);
                        objCosto.CostoDeProcesos = new Costo_ProcesoDeFabricacionOAD().Seleccionar_By_Id(objCosto.Id).Sum(p => (p.Cantidad * p.Valor));
                        objCosto.CostoDeRecursos = new Costo_RecursoOAD().Seleccionar_By_Id(objCosto.Id).Sum(p => (p.Consumo * p.ValoUnitario));
                        objCosto.CostoDeProduccion = objCosto.CostoDeProcesos + objCosto.CostoDeRecursos;
                        decimal? Total_ConValorizacion = objCosto.CostoDeProduccion;
                        List<Costo_Valorizacion> lstCostosValorizacion = new Costo_ValorizacionOAD().Seleccionar_By_Id(objCosto.Id).OrderBy(p => p.Posicion).ToList();
                        foreach (Costo_Valorizacion objCosto_valorizacion in lstCostosValorizacion)
                        {
                            Total_ConValorizacion += ((Total_ConValorizacion * objCosto_valorizacion.Porcentaje) / 100m);
                            objCosto_valorizacion.ValorHastaElMomento = Total_ConValorizacion;
                            new Costo_ValorizacionOAD().Actualizar(objCosto_valorizacion);
                        }
                        objCosto.CostoConValirizacion = Total_ConValorizacion;
                        new CostoOAD().Actualizar(objCosto);
                        objTransaccion.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<R_Costos_CabeceraResult> InformeCostos_Cabecera(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoOAD _objCosto = new CostoOAD();
            return _objCosto.InformeCostos_Cabecera(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_ProcesosResult> InformeCostos_Procesos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoOAD _objCosto = new CostoOAD();
            return _objCosto.InformeCostos_Procesos(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_RecursosResult> InformeCostos_Recursos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoOAD _objCosto = new CostoOAD();
            return _objCosto.InformeCostos_Recursos(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_ValorizacionResult> InformeCostos_Valorizacion(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoOAD _objCosto = new CostoOAD();
            return _objCosto.InformeCostos_Valorizacion(id_GrupoDeMiembros, id_Recurso);
        }
    }
}