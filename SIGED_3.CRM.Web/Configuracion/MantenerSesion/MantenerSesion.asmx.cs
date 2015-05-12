using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Negocio.Entidades;
namespace SIGED_3.CRM.Web.Configuracion.MantenerSesion
{
    /// <summary>
    /// Descripción breve de MantenerSesion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class MantenerSesion : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public void ActualizarSesion()
        {
            SessionManager.Id_Miembro = SessionManager.Id_Miembro;
            SessionManager.Id_GrupoDeMiembros = SessionManager.Id_GrupoDeMiembros;
            SessionManager.Id_Cuenta = SessionManager.Id_Cuenta;
        }
    }
}
