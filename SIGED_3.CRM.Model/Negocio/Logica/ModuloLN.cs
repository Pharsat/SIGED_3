using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.AccesoDeRecursos.OAD;
namespace SIGED_3.CRM.Model.Negocio.Logica
{
    internal class ModuloLN
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <returns>Lista de registros tipo Modulo</returns>
        public List<Modulo> Seleccionar_All()
        {
            ModuloOAD objModulo = new ModuloOAD();
            return objModulo.Seleccionar_All();
        }
        /// <summary>
        /// lista de modulos a los cuales se les puede colocar consecutivo.
        /// </summary>
        /// <returns>lista de modulos</returns>
        public List<Modulo> Seleccionar_All_Consecutbles()
        {
            ModuloOAD objModulo = new ModuloOAD();
            return objModulo.Seleccionar_All_Consecutbles();
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <param name=Id>Identificador de la Modulo</param>
        /// <returns>Objeto singular del tipo Modulo</returns>
        public List<Modulo> Seleccionar_Id(long Id)
        {
            ModuloOAD objModulo = new ModuloOAD();
            return objModulo.Seleccionar_Id(Id);
        }
        /// <summary>
        /// Guarda un objeto de tipo Modulo en la base de datos.
        /// </summary>
        /// <param name=objModulo>Objeto Modulo a guardar</param>
        public void Guardar(Modulo objModulo)
        {
            ModuloOAD _objModulo = new ModuloOAD();
            _objModulo.Guardar(objModulo);
        }
        /// <summary>
        /// Elimina un objeto del tipo Modulo, se recibe su Id unicamente
        /// </summary>
        /// <param name=objModulo>Identificativo del(a) Modulo</param>
        public void Eliminar(Modulo objModulo)
        {
            ModuloOAD _objModulo = new ModuloOAD();
            _objModulo.Eliminar(objModulo);
        }
        /// <summary>
        /// Actualiza una Modulo, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objModulo>Objeto del tipo Modulo</param>
        public void Actualizar(Modulo objModulo)
        {
            ModuloOAD _objModulo = new ModuloOAD();
            _objModulo.Actualizar(objModulo);
        }

        public List<S_ConfiguracionMenuResult> ConfiguracionModulo(long? Id_Cuenta)
        {
            ModuloOAD _objModulo = new ModuloOAD();
            return _objModulo.ConfiguracionModulo(Id_Cuenta);
        }

        public List<LC_Modulos_PermitidosResult> ModulosPermitidos(int? id_Rol, long? id_Cuenta, long? id_Modulo)
        {
            ModuloOAD _objModulo = new ModuloOAD();
            return _objModulo.ModulosPermitidos(id_Rol, id_Cuenta, id_Modulo);
        }
    }
}