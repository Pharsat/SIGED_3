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
    public class ProcesoDeFabricacionFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<ProcesoDeFabricacion> Seleccionar_All()
        {
            ProcesoDeFabricacionLN objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            return objProcesoDeFabricacion.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public ProcesoDeFabricacion Seleccionar_Id(long Id)
        {
            ProcesoDeFabricacionLN objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            return objProcesoDeFabricacion.Seleccionar_Id(Id);
        }
        /// <summary>
        /// consulta la lista principal de procesos de fabricacion
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros al que pertenece el miemro actual</param>
        /// <param name="estado">estado del proceso de fabricación.</param>
        /// <returns></returns>
        public List<LP_ProcesosDeFabricacionResult> Seleccionar_LP(int? id_GrupoDeMiembros, bool? estado, string descripcion)
        {
            ProcesoDeFabricacionLN objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            return objProcesoDeFabricacion.Seleccionar_LP(id_GrupoDeMiembros, estado, descripcion);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            ProcesoDeFabricacionLN _objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            _objProcesoDeFabricacion.Guardar(objProcesoDeFabricacion);
        }
        /// <summary>
        /// guarda el objeto proceso de fabricacion enviado
        /// </summary>
        /// <param name="objProcesoDeFabricacion">objeto a guardar</param>
        /// <returns>identificadot del objeto guardado</returns>
        public long Guardar_2(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            ProcesoDeFabricacionLN _objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            return _objProcesoDeFabricacion.Guardar_2(objProcesoDeFabricacion);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            ProcesoDeFabricacionLN _objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            _objProcesoDeFabricacion.Eliminar(objProcesoDeFabricacion);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            ProcesoDeFabricacionLN _objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            _objProcesoDeFabricacion.Actualizar(objProcesoDeFabricacion);
        }
        /// <summary>
        /// Metodo que retorna la lista de procesos de fabricación
        /// de un grupo especifico
        /// </summary>
        /// <param name="Id_GrupoDeMiembros">grupo de membros al cual pertenecen los procesos</param>
        /// <returns>Proceso de fabricación</returns>
        public List<ProcesoDeFabricacion> Seleccionar_By_IdGrupoMiembros(long Id_GrupoDeMiembros)
        {
            ProcesoDeFabricacionLN objProcesoDeFabricacion = new ProcesoDeFabricacionLN();
            return objProcesoDeFabricacion.Seleccionar_By_IdGrupoMiembros(Id_GrupoDeMiembros);
        }
        public bool AnalizarRegistrosVinculados(int? Id_Proceso)
        {
            return new ProcesoDeFabricacionLN().AnalizarRegistrosVinculados(Id_Proceso);
        }
    }
}