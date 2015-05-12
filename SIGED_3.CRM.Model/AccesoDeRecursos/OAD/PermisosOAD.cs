using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Enum;

namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class PermisosOAD
    {
        public void PrepararRoles()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                List<Roles> lstRoles = dc.Roles.Where(p => !p.Id_GrupoDeMiembros.HasValue).ToList();
                List<Modulo> lstModulos = dc.Modulo.Where(p => !p.GeneralParaPublico.Value).ToList();
                for (int i = 0; i < lstRoles.Count; i++)
                {
                    switch (lstRoles[i].Id)
                    {
                        case ((int)Roles_Enum.AdministradorDelSistema):
                            for (int j = 0; j < lstModulos.Count; j++)
                            {
                                if (dc.Permisos.Any(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id))
                                {
                                    Permisos objPermiso = dc.Permisos.Single(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id);
                                    objPermiso.ActualizarDetalle = true;
                                    objPermiso.ConsultarDetalle = true;
                                    objPermiso.ConsultarLista = true;
                                    objPermiso.CrearRegistro = true;
                                    objPermiso.EliminarRegistro = true;
                                    dc.SubmitChanges();
                                }
                                else
                                {
                                    Permisos objPermiso = new Permisos();
                                    objPermiso.ActualizarDetalle = true;
                                    objPermiso.ConsultarDetalle = true;
                                    objPermiso.ConsultarLista = true;
                                    objPermiso.CrearRegistro = true;
                                    objPermiso.EliminarRegistro = true;
                                    objPermiso.Id_Rol = lstRoles[i].Id;
                                    objPermiso.Id_Modulo = lstModulos[j].Id;
                                    dc.Permisos.InsertOnSubmit(objPermiso);
                                    dc.SubmitChanges();
                                }
                            }
                            break;
                        case ((int)Roles_Enum.GerenteComercial):
                            for (int j = 0; j < lstModulos.Count; j++)
                            {
                                if (dc.Permisos.Any(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id))
                                {
                                    Permisos objPermiso = dc.Permisos.Single(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id);
                                    objPermiso.ActualizarDetalle = true;
                                    objPermiso.ConsultarDetalle = true;
                                    objPermiso.ConsultarLista = true;
                                    objPermiso.CrearRegistro = true;
                                    objPermiso.EliminarRegistro = true;
                                    dc.SubmitChanges();
                                }
                                else
                                {
                                    Permisos objPermiso = new Permisos();
                                    objPermiso.ActualizarDetalle = true;
                                    objPermiso.ConsultarDetalle = true;
                                    objPermiso.ConsultarLista = true;
                                    objPermiso.CrearRegistro = true;
                                    objPermiso.EliminarRegistro = true;
                                    objPermiso.Id_Rol = lstRoles[i].Id;
                                    objPermiso.Id_Modulo = lstModulos[j].Id;
                                    dc.Permisos.InsertOnSubmit(objPermiso);
                                    dc.SubmitChanges();
                                }
                            }
                            break;
                        case ((int)Roles_Enum.ClientePremium):
                            for (int j = 0; j < lstModulos.Count; j++)
                            {
                                if (lstModulos[j].Id != (int)Modulo_Enum.Publicaciones && lstModulos[j].Id != (int)Modulo_Enum.Manager)
                                {
                                    if (dc.Permisos.Any(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id))
                                    {
                                        Permisos objPermiso = dc.Permisos.Single(p => p.Id_Modulo == lstModulos[j].Id && p.Id_Rol == lstRoles[i].Id);
                                        objPermiso.ActualizarDetalle = true;
                                        objPermiso.ConsultarDetalle = true;
                                        objPermiso.ConsultarLista = true;
                                        objPermiso.CrearRegistro = true;
                                        objPermiso.EliminarRegistro = true;
                                        dc.SubmitChanges();
                                    }
                                    else
                                    {
                                        Permisos objPermiso = new Permisos();
                                        objPermiso.ActualizarDetalle = true;
                                        objPermiso.ConsultarDetalle = true;
                                        objPermiso.ConsultarLista = true;
                                        objPermiso.CrearRegistro = true;
                                        objPermiso.EliminarRegistro = true;
                                        objPermiso.Id_Rol = lstRoles[i].Id;
                                        objPermiso.Id_Modulo = lstModulos[j].Id;
                                        dc.Permisos.InsertOnSubmit(objPermiso);
                                        dc.SubmitChanges();
                                    }
                                }
                            }
                            List<Permisos> lstPermisos = dc.Permisos.Where(p => p.Id_Rol == lstRoles[i].Id && p.Id_Modulo == (int)Modulo_Enum.Publicaciones).ToList();
                            for (int j = 0; j < lstPermisos.Count(); j++)
                            {
                                dc.Permisos.DeleteOnSubmit(lstPermisos[j]);
                            }
                            dc.SubmitChanges();
                            break;
                    }
                }
            }
        }

        public List<S_ConfiguracionPermisosResult> ConfiguracionPermisos(long? Id_Cuenta)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.S_ConfiguracionPermisos(Id_Cuenta).ToList();
            }
        }

        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <returns>Lista de registros tipo Bodega</returns>
        public List<Permisos> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Permisos.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Bodega
        /// </summary>
        /// <param name=Id>Identificador de la Bodega</param>
        /// <returns>Objeto singular del tipo Bodega</returns>
        public Permisos Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Permisos.Any(p => p.Id == Id))
                {
                    return dc.Permisos.Single(p => p.Id == Id);
                }
                else
                {
                    return new Permisos();
                }
            }
        }
        /// <summary>
        /// Obtiene todos los contactos de un cliente
        /// </summary>
        /// <param name="Id_Cliente">Identificativo del cliente</param>
        /// <returns>Lista de los contactos del cliernte</returns>
        public List<Permisos> Seleccionar_By_Rol(long Id_Rol)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var Query = from p in dc.Permisos
                            where p.Id_Rol == Id_Rol
                            select p;
                return Query.ToList();
            }
        }

        public List<LS_PermisosResult> Seleccionar_By_Rol_LS(int Id_Rol)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LS_Permisos(Id_Rol).ToList();
            }
        }
        /// <summary>
        /// Guarda un objeto de tipo Bodega en la base de datos.
        /// </summary>
        /// <param name=objBodega>Objeto Bodega a guardar</param>
        public void Guardar(Permisos objPermisos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                dc.Permisos.InsertOnSubmit(objPermisos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Bodega, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Bodega</param>
        public void Eliminar(Permisos objPermisos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Permisos _objPermisos = dc.Permisos.Single(p => p.Id == objPermisos.Id);
                dc.Permisos.DeleteOnSubmit(_objPermisos);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Bodega, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objBodega>Objeto del tipo Bodega</param>
        public void Actualizar(Permisos objPermisos)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Permisos _objPermisos = dc.Permisos.Single(p => p.Id == objPermisos.Id);
                _objPermisos.Id = objPermisos.Id;
                _objPermisos.Id_Modulo = objPermisos.Id_Modulo;
                _objPermisos.Id_Rol = objPermisos.Id_Rol;
                _objPermisos.ConsultarLista = objPermisos.ConsultarLista;
                _objPermisos.ConsultarDetalle = objPermisos.ConsultarDetalle;
                _objPermisos.ActualizarDetalle = objPermisos.ActualizarDetalle;
                _objPermisos.EliminarRegistro = objPermisos.EliminarRegistro;
                _objPermisos.CrearRegistro = objPermisos.CrearRegistro;
                dc.SubmitChanges();
            }
        }
    }
}
