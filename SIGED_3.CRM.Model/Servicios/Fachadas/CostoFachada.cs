using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
using System.Data;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;

namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class CostoFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Costo> Seleccionar_All()
        {
            CostoLn objCosto = new CostoLn();
            return objCosto.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Costo Seleccionar_Id(long Id)
        {
            CostoLn objCosto = new CostoLn();
            return objCosto.Seleccionar_Id(Id);
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
            CostoLn objCosto = new CostoLn();
            return objCosto.Seleccionar_LP(id_GrupoDeMiembros, codigo, tipoPrenda);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Costo objCosto)
        {
            CostoLn _objCosto = new CostoLn();
            _objCosto.Guardar(objCosto);
        }
        /// <summary>
        /// Guarda el objeto Costo y obtiene su Id
        /// </summary>
        /// <param name="objCosto">Licnete a guardar</param>
        public long Guardar_2(Costo objCosto)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.Guardar_2(objCosto);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Costo objCosto)
        {
            CostoLn _objCosto = new CostoLn();
            _objCosto.Eliminar(objCosto);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Costo objCosto)
        {
            CostoLn _objCosto = new CostoLn();
            _objCosto.Actualizar(objCosto);
        }
        /// <summary>
        /// obtiene el costo asociado al recurso mencionado.
        /// </summary>
        /// <param name="Id_Recurso">recurso que deberia estar ligado a un costo</param>
        /// <returns>objeto costo</returns>
        public Costo Seleccionar_Id_Recurso(long Id_Recurso)
        {
            CostoLn objCosto = new CostoLn();
            return objCosto.Seleccionar_Id_Recurso(Id_Recurso);
        }
        public List<R_Costos_CabeceraResult> InformeCostos_Cabecera(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.InformeCostos_Cabecera(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_ProcesosResult> InformeCostos_Procesos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.InformeCostos_Procesos(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_RecursosResult> InformeCostos_Recursos(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.InformeCostos_Recursos(id_GrupoDeMiembros, id_Recurso);
        }
        public List<R_Costos_ValorizacionResult> InformeCostos_Valorizacion(long? id_GrupoDeMiembros, long? id_Recurso)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.InformeCostos_Valorizacion(id_GrupoDeMiembros, id_Recurso);
        }

        public void MultiplicarCostos(long? Id_Costo)
        {
            CostoLn _objCosto = new CostoLn();
            _objCosto.MultiplicarCostos(Id_Costo);
        }
        public List<R_UtilidadesResult> Informe_Utilidades(long? id_GrupoDeMiembros, DateTime? desde, DateTime? hasta)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.Informe_Utilidades(id_GrupoDeMiembros, desde, hasta);
        }
        public DataTable Impresion_Lista_Precios(long? Id_GrupoDeMiembros)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.Impresion_Lista_Precios(Id_GrupoDeMiembros);
        }
        public DataTable Impresion_Lista_Precios_2(long? Id_GrupoDeMiembros, short? Selector)
        {
            CostoLn _objCosto = new CostoLn();
            return _objCosto.Impresion_Lista_Precios_2(Id_GrupoDeMiembros, Selector);
        }
    }
}