using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Model.Util.Session
{
    public class SessionManager
    {
        //Id del usuario logueado
        public static Int64? Id_Miembro
        {
            get { return (Int64?)HttpContext.Current.Session["IdM"] ?? 0; }
            set { HttpContext.Current.Session["IdM"] = value; }
        }
        // Id del grupo logueado.
        public static Int64? Id_GrupoDeMiembros
        {
            get { return (Int64?)HttpContext.Current.Session["IdGM"] ?? 0; }
            set { HttpContext.Current.Session["IdGM"] = value; }
        }
        //Id de la cuenta logueada
        public static Int64? Id_Cuenta
        {
            get { return (Int64?)HttpContext.Current.Session["IdC"] ?? 0; }
            set { HttpContext.Current.Session["IdC"] = value; }
        }

        public static Int32? Id_Rol
        {
            get { return (Int32?)HttpContext.Current.Session["IdR"] ?? 0; }
            set { HttpContext.Current.Session["IdR"] = value; }
        }

        public static List<S_ConfiguracionPermisosResult> ConfiguracionPermisos
        {
            get { return (List<S_ConfiguracionPermisosResult>)HttpContext.Current.Session["ConfiguracionPermisos"] ?? null; }
            set { HttpContext.Current.Session["ConfiguracionPermisos"] = value; }
        }

        public static List<S_ConfiguracionMenuResult> ConfiguracionMenu
        {
            get { return (List<S_ConfiguracionMenuResult>)HttpContext.Current.Session["ConfiguracionMenu"] ?? null; }
            set { HttpContext.Current.Session["ConfiguracionMenu"] = value; }
        }

        public static string Token
        {
            get { return (string)HttpContext.Current.Session["Token"] ?? null; }
            set { HttpContext.Current.Session["Token"] = value; }
        }
    }
}
