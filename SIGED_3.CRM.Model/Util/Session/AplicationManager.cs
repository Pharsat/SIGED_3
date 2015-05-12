using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Model.Util.Session
{
    public class AplicationManager
    {
        public static List<EstadoDeSesion> Sesiones
        {
            get
            {
                if (HttpContext.Current.Application["Sesiones"] == null)
                {
                    HttpContext.Current.Application["Sesiones"] = new List<EstadoDeSesion>();
                }
                return (List<EstadoDeSesion>)HttpContext.Current.Application["Sesiones"];
            }
            set { HttpContext.Current.Application["Sesiones"] = value; }
        }

        public static bool ConfirmarDuplicidad()
        {
            return Sesiones.Any(p => p.Id_Cuenta == SessionManager.Id_Cuenta && p.Token != SessionManager.Token);
        }

        public static void IncluirToken()
        {
            if (Sesiones.Any(p => p.Id_Cuenta == SessionManager.Id_Cuenta))
            {
                EstadoDeSesion objNuevo = Sesiones.Single(p => p.Id_Cuenta == SessionManager.Id_Cuenta);
                objNuevo.Token = SessionManager.Token;
            }
            else
            {
                EstadoDeSesion objToken = new EstadoDeSesion();
                objToken.Id_Cuenta = SessionManager.Id_Cuenta.Value;
                objToken.Token = SessionManager.Token;
                Sesiones.Add(objToken);
            }
        }
    }
}
