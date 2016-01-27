using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
using SIGED_3.CRM.Model.Util.Session;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class BodegaLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Bodega> Seleccionar_All()
        {
            BodegaOad objBodega = new BodegaOad();
            return objBodega.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Bodega Seleccionar_Id(long Id)
        {
            BodegaOad objBodega = new BodegaOad();
            return objBodega.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Metodo que consulta la lista principal de bodegas.
        /// </summary>
        /// <param name="Estado">Estado de habilidad de la bodega</param>
        /// <param name="Id_GrupoDeMiembros">Grupo de pertenencia</param>
        /// <param name="Nombre">Nombre de la bodega</param>
        /// <returns>Lista de datos de la bodega</returns>
        public List<LP_BodegasResult> Seleccionar_LP(bool? Estado, long? Id_GrupoDeMiembros, string Nombre)
        {
            BodegaOad objBodega = new BodegaOad();
            return objBodega.Seleccionar_LP(Estado, Id_GrupoDeMiembros, Nombre);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Bodega objBodega)
        {
            BodegaOad _objBodega = new BodegaOad();
            _objBodega.Guardar(objBodega);
        }
        /// <summary>
        /// Guarda el objeto Bodega y obtiene su Id
        /// </summary>
        /// <param name="objBodega">Licnete a guardar</param>
        public long Guardar_2(Bodega objBodega)
        {
            BodegaOad _objBodega = new BodegaOad();
            return _objBodega.Guardar_2(objBodega);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Bodega objBodega)
        {
            BodegaOad _objBodega = new BodegaOad();
            _objBodega.Eliminar(objBodega);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Bodega objBodega)
        {
            BodegaOad _objBodega = new BodegaOad();
            _objBodega.Actualizar(objBodega);
        }
        public List<Bodega> Seleccionar_All_Activos(long? Id_Bodega)
        {
            BodegaOad _objBodega = new BodegaOad();
            return _objBodega.Seleccionar_All_Activos(SessionManager.Id_GrupoDeMiembros, Id_Bodega);
        }
    }
}