using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Negocio.Logica;

namespace SIGED_3.CRM.Model.Servicios.Fachadas
{
    [DataObject(true)]
    public class PermisosFachada
    {
        public void PrepararRoles()
        {
            PermisosLN objPermisos = new PermisosLN();
            objPermisos.PrepararRoles();
        }

        public S_ConfiguracionPermisosResult PermisosDeUsuario(long Id_Modulo)
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.PermisosDeUsuario(Id_Modulo);
        }

        public List<S_ConfiguracionPermisosResult> ConfiguracionPermisos(long? Id_Cuenta)
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.ConfiguracionPermisos(Id_Cuenta);
        }

        public List<Permisos> Seleccionar_All()
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.Seleccionar_All();
        }
        
        public Permisos Seleccionar_Id(long Id)
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.Seleccionar_Id(Id);
        }
        
        public List<Permisos> Seleccionar_By_Rol(int Id_Rol)
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.Seleccionar_By_Rol(Id_Rol);
        }
        
        public void Guardar(Permisos objPermisos)
        {
            PermisosLN _objPermisos = new PermisosLN();
            _objPermisos.Guardar(objPermisos);
        }
        
        public void Eliminar(Permisos objPermisos)
        {
            PermisosLN _objPermisos = new PermisosLN();
            _objPermisos.Eliminar(objPermisos);
        }
        
        public void Actualizar(Permisos objPermisos)
        {
            PermisosLN _objPermisos = new PermisosLN();
            _objPermisos.Actualizar(objPermisos);
        }

        public List<LS_PermisosResult> Seleccionar_By_Rol_LS(int Id_Rol)
        {
            PermisosLN objPermisos = new PermisosLN();
            return objPermisos.Seleccionar_By_Rol_LS(Id_Rol);
        }
    }
}
