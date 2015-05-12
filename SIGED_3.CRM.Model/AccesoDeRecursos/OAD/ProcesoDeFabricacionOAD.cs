using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ProcesoDeFabricacionOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<ProcesoDeFabricacion> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.ProcesoDeFabricacion.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public ProcesoDeFabricacion Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.ProcesoDeFabricacion.Single(p => p.Id == Id);
            }
        }
        /// <summary>
        /// Metodo que retorna la lista de procesos de fabricación
        /// de un grupo especifico
        /// </summary>
        /// <param name="Id_GrupoDeMiembros">grupo de membros al cual pertenecen los procesos</param>
        /// <returns>Proceso de fabricación</returns>
        public List<ProcesoDeFabricacion> Seleccionar_By_IdGrupoMiembros(long Id_GrupoDeMiembros)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.ProcesoDeFabricacion.Where(p => p.Id_GrupoDeMiembros == Id_GrupoDeMiembros).ToList();
            }
        }
        /// <summary>
        /// consulta la lista principal de procesos de fabricacion
        /// </summary>
        /// <param name="id_GrupoDeMiembros">grupo de miembros al que pertenece el miemro actual</param>
        /// <param name="estado">estado del proceso de fabricación.</param>
        /// <returns></returns>
        public List<LP_ProcesosDeFabricacionResult> Seleccionar_LP(int? id_GrupoDeMiembros, bool? estado, string descripcion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_ProcesosDeFabricacion(id_GrupoDeMiembros, estado, descripcion).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.ProcesoDeFabricacion.InsertOnSubmit(objProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// guarda el objeto proceso de fabricacion enviado
        /// </summary>
        /// <param name="objProcesoDeFabricacion">objeto a guardar</param>
        /// <returns>identificadot del objeto guardado</returns>
        public long Guardar_2(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.ProcesoDeFabricacion.InsertOnSubmit(objProcesoDeFabricacion);
                dc.SubmitChanges();
                return dc.ProcesoDeFabricacion.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                ProcesoDeFabricacion _objProcesoDeFabricacion = dc.ProcesoDeFabricacion.Single(p => p.Id == objProcesoDeFabricacion.Id);
                dc.ProcesoDeFabricacion.DeleteOnSubmit(_objProcesoDeFabricacion);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(ProcesoDeFabricacion objProcesoDeFabricacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                ProcesoDeFabricacion _objProcesoDeFabricacion = dc.ProcesoDeFabricacion.Single(p => p.Id == objProcesoDeFabricacion.Id);
                _objProcesoDeFabricacion.Id = objProcesoDeFabricacion.Id;
                _objProcesoDeFabricacion.Id_GrupoDeMiembros = objProcesoDeFabricacion.Id_GrupoDeMiembros;
                _objProcesoDeFabricacion.Id_UnidadDeMedida = objProcesoDeFabricacion.Id_UnidadDeMedida;
                _objProcesoDeFabricacion.Descripcion = objProcesoDeFabricacion.Descripcion;
                _objProcesoDeFabricacion.Estado = objProcesoDeFabricacion.Estado;
                dc.SubmitChanges();
            }
        }
        public bool AnalizarRegistrosVinculados(int? Id_Proceso)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Costo_ProcesoDeFabricacion.Any(p => p.Id_Proceso == Id_Proceso) || dc.FichaTecnica_ProcesosDetallados.Any(p => p.Id_Proceso == Id_Proceso);
            }
        }
    }
}