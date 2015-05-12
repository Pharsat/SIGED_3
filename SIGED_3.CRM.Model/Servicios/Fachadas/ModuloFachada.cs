using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Logica;
using System.ComponentModel;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class ModuloFachada
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <returns>Lista de registros tipo Modulo</returns>
        public List<Modulo> Seleccionar_All()
        {
            ModuloLN objModulo = new ModuloLN();
            return objModulo.Seleccionar_All();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <param name=Id>Identificador de la Modulo</param>
        /// <returns>Objeto singular del tipo Modulo</returns>
        public List<Modulo> Seleccionar_Id(long Id)
        {
            ModuloLN objModulo = new ModuloLN();
            return objModulo.Seleccionar_Id(Id);
        }
        /// <summary>
        /// lista de modulos a los cuales se les puede colocar consecutivo.
        /// </summary>
        /// <returns>lista de modulos</returns>
        public List<Modulo> Seleccionar_All_Consecutbles()
        {
            ModuloLN objModulo = new ModuloLN();
            return objModulo.Seleccionar_All_Consecutbles();
        }
        /// <summary>
        /// Guarda un objeto de tipo Modulo en la base de datos.
        /// </summary>
        /// <param name=objModulo>Objeto Modulo a guardar</param>
        public void Guardar(Modulo objModulo)
        {
            ModuloLN _objModulo = new ModuloLN();
            _objModulo.Guardar(objModulo);
        }
        /// <summary>
        /// Elimina un objeto del tipo Modulo, se recibe su Id unicamente
        /// </summary>
        /// <param name=objModulo>Identificativo del(a) Modulo</param>
        public void Eliminar(Modulo objModulo)
        {
            ModuloLN _objModulo = new ModuloLN();
            _objModulo.Eliminar(objModulo);
        }
        /// <summary>
        /// Actualiza una Modulo, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objModulo>Objeto del tipo Modulo</param>
        public void Actualizar(Modulo objModulo)
        {
            ModuloLN _objModulo = new ModuloLN();
            _objModulo.Actualizar(objModulo);
        }

        public List<S_ConfiguracionMenuResult> ConfiguracionModulo(long? Id_Cuenta)
        {
            ModuloLN _objModulo = new ModuloLN();
            return _objModulo.ConfiguracionModulo(Id_Cuenta);
        }

        public List<LC_Modulos_PermitidosResult> ModulosPermitidos(int? id_Rol, long? id_Cuenta, long? id_Modulo)
        {
            ModuloLN _objModulo = new ModuloLN();
            return _objModulo.ModulosPermitidos(id_Rol, id_Cuenta, id_Modulo);
        }
    }
}
