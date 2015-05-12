using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class EntradaOSalidaFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<EntradaOSalida> Seleccionar_All()
        {
            EntradaOSalidaLN objEntradaOSalida = new EntradaOSalidaLN();
            return objEntradaOSalida.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public EntradaOSalida Seleccionar_Id(long Id)
        {
            EntradaOSalidaLN objEntradaOSalida = new EntradaOSalidaLN();
            return objEntradaOSalida.Seleccionar_Id(Id);
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
            EntradaOSalidaLN objEntradaOSalida = new EntradaOSalidaLN();
            return objEntradaOSalida.Seleccionar_LP(id_GrupoDeMiembros, nombre50, desde, hasta, codigo);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(EntradaOSalida objEntradaOSalida)
        {
            EntradaOSalidaLN _objEntradaOSalida = new EntradaOSalidaLN();
            _objEntradaOSalida.Guardar(objEntradaOSalida);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(EntradaOSalida objEntradaOSalida)
        {
            EntradaOSalidaLN _objEntradaOSalida = new EntradaOSalidaLN();
            _objEntradaOSalida.Eliminar(objEntradaOSalida);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(EntradaOSalida objEntradaOSalida)
        {
            EntradaOSalidaLN _objEntradaOSalida = new EntradaOSalidaLN();
            _objEntradaOSalida.Actualizar(objEntradaOSalida);
        }
    }
}