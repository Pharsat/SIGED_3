using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class ModuloOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <returns>Lista de registros tipo Modulo</returns>
        public List<Modulo> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Modulo.ToList();
            }
        }
        /// <summary>
        /// lista de modulos a los cuales se les puede colocar consecutivo.
        /// </summary>
        /// <returns>lista de modulos</returns>
        public List<Modulo> Seleccionar_All_Consecutbles()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Modulo.Where(p => p.UsaConsecutivos.Value == true).ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Modulo
        /// </summary>
        /// <param name=Id>Identificador de la Modulo</param>
        /// <returns>Objeto singular del tipo Modulo</returns>
        public List<Modulo> Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.Modulo
                            where p.Id == Id
                            select p;
                return query.ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Modulo en la base de datos.
        /// </summary>
        /// <param name=objModulo>Objeto Modulo a guardar</param>
        public void Guardar(Modulo objModulo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Modulo.InsertOnSubmit(objModulo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Modulo, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Modulo</param>
        public void Eliminar(Modulo objModulo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Modulo _objModulo = dc.Modulo.Single(p => p.Id == objModulo.Id);
                dc.Modulo.DeleteOnSubmit(_objModulo);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Modulo, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objModulo>Objeto del tipo Modulo</param>
        public void Actualizar(Modulo objModulo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Modulo _objModulo = dc.Modulo.Single(p => p.Id == objModulo.Id);
                _objModulo.Id = objModulo.Id;
                _objModulo.Nombre = objModulo.Nombre;
                _objModulo.UsaConsecutivos = objModulo.UsaConsecutivos;
                dc.SubmitChanges();
            }
        }

        public List<S_ConfiguracionMenuResult> ConfiguracionModulo(long? Id_Cuenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.S_ConfiguracionMenu(Id_Cuenta).ToList();
            }
        }

        public List<LC_Modulos_PermitidosResult> ModulosPermitidos(int? id_Rol, long? id_Cuenta, long? id_Modulo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LC_Modulos_Permitidos(id_Rol, id_Cuenta, id_Modulo).ToList();
            }
        }
    }
}