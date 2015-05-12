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
    public class ConsecutivosFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Consecutivos> Seleccionar_All()
        {
            ConsecutivosLN objConsecutivos = new ConsecutivosLN();
            return objConsecutivos.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Consecutivos Seleccionar_Id(long Id)
        {
            ConsecutivosLN objConsecutivos = new ConsecutivosLN();
            return objConsecutivos.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Carga de la lista principal de consecutivos.
        /// </summary>
        /// <param name="id_GrupoDeMiembros">identificador del grupo de miembros</param>
        /// <returns>Lista de consecutivos secun procedimiento.</returns>
        public List<LP_ConsecutivosResult> Seleccionar_LP(int? id_GrupoDeMiembros)
        {
            ConsecutivosLN objConsecutivos = new ConsecutivosLN();
            return objConsecutivos.Seleccionar_LP(id_GrupoDeMiembros);
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Consecutivos objConsecutivos)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            _objConsecutivos.Guardar(objConsecutivos);
        }
        /// <summary>
        /// Guarda el objeto Consecutivo y obtiene su Id
        /// </summary>
        /// <param name="objConsecutivo">Licnete a guardar</param>
        public long Guardar_2(Consecutivos objConsecutivo)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            return _objConsecutivos.Guardar_2(objConsecutivo);
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Consecutivos objConsecutivos)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            _objConsecutivos.Eliminar(objConsecutivos);
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Consecutivos objConsecutivos)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            _objConsecutivos.Actualizar(objConsecutivos);
        }
        /// <summary>
        /// Metodo que retorna la configuracion para un modulo seleccionado en el modulo de consecutivos
        /// </summary>
        /// <param name="Id_Modulo">Id del modulo que se debe cargar la configuracion</param>
        /// <param name="Id_GrupoDeMiembros">Grupo de miembros del modulos</param>
        /// <returns>configuracion</returns>
        public long?[] Determinar_Configuracion(long Id_Modulo, long Id_GrupoDeMiembros)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            return _objConsecutivos.Determinar_Configuracion(Id_Modulo, Id_GrupoDeMiembros);
        }
        /// <summary>
        /// Valida si existe un consecutivo para un modulo cualquiera sin usarlo
        /// </summary>
        /// <param name="Id_Modulo">Modulo del consecutivo a tomar</param>
        /// <param name="Id_GrupoDeMiembros">grupo de miembro del usuario actual</param>
        /// <returns>si hay consecutivo o no</returns>
        public bool HayConsecutivo(long Id_Modulo, long Id_GrupoDeMiembros)
        {
            ConsecutivosLN _objConsecutivos = new ConsecutivosLN();
            return _objConsecutivos.HayConsecutivo(Id_Modulo, Id_GrupoDeMiembros);
        }
    }
}