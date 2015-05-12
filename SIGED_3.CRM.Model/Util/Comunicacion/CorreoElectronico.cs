using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Configuration;
namespace SIGED_3.CRM.Model.Util.Comunicacion
{
    public class CorreoElectronico
    {
        #region Atributos
        List<string> lstReceptores_Correos;
        List<string> lstReceptores_Nombres;
        List<System.IO.Stream> lstArchivos_Objeto;
        List<string> lstArchivos_Nombre;
        string strEmisor_Correo;
        string strEmisor_Alias;
        string strAsunto;
        string strCuerpo;
        string strMailUsuario;
        string strContrasenaUsuario;
        int intPuerto;
        string strHost;
        bool SSL;
        #endregion
        #region Propiedades
        public string p_strAsunto
        {
            get { return strAsunto; }
            set { strAsunto = value; }
        }
        private string p_Para
        {
            get
            {
                return ArmarPara();
            }
        }
        #endregion
        #region Constructores
        public CorreoElectronico(string CorreoEmisor, string AliasEmisor)
        {
            lstReceptores_Correos = new List<string>();
            lstReceptores_Nombres = new List<string>();
            lstArchivos_Objeto = new List<System.IO.Stream>();
            lstArchivos_Nombre = new List<string>();
            strEmisor_Correo = CorreoEmisor;
            strEmisor_Alias = AliasEmisor;
            strAsunto = String.Empty;
            strCuerpo = String.Empty;
            strMailUsuario = global::SIGED_3.CRM.Model.Properties.Settings.Default.SmtpClientCredencialUsuario;
            strContrasenaUsuario = global::SIGED_3.CRM.Model.Properties.Settings.Default.SmtpClientCredencialContrasena;
            intPuerto = global::SIGED_3.CRM.Model.Properties.Settings.Default.SmtpClientPuerto;
            strHost = global::SIGED_3.CRM.Model.Properties.Settings.Default.SmtpClientHost;
            SSL = global::SIGED_3.CRM.Model.Properties.Settings.Default.SmtpClientSSL;
        }
        #endregion
        #region Metodos
        public string ArmarPara()
        {
            string Resultado = String.Empty; ;
            for (int i = 0; i < lstReceptores_Correos.Count; i++)
            {
                Resultado += "'" + lstReceptores_Nombres[i] + " <" + lstReceptores_Correos[i] + ">'; ";
            }
            return Resultado.TrimEnd(' ').TrimEnd(';') + ".";
        }
        public void Agregar_Receptor(string Correo, string Nombres)
        {
            if (!lstReceptores_Correos.Any(p => p.ToLower() == Correo.ToLower()))
            {
                lstReceptores_Correos.Add(Correo);
                lstReceptores_Nombres.Add(Nombres);
            }
        }
        public void Agregar_Archivo(System.IO.Stream Objeto, string Nombre)
        {
            if (!lstArchivos_Objeto.Any(p => p == Objeto))
            {
                lstArchivos_Objeto.Add(Objeto);
                lstArchivos_Nombre.Add(Nombre);
            }
        }
        public bool EnviarMail()
        {
            try
            {
                if (strCuerpo != String.Empty)
                {
                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                    foreach (string a in lstReceptores_Correos)
                    {
                        msg.To.Add(new MailAddress(a));
                    }
                    msg.To.Add(new MailAddress("amejiav@easyprocesscompany.com"));
                    msg.From = new MailAddress(strEmisor_Correo, strEmisor_Alias, System.Text.Encoding.UTF8);
                    msg.Subject = strAsunto;
                    msg.SubjectEncoding = System.Text.Encoding.UTF8;
                    msg.Body = strCuerpo;
                    msg.BodyEncoding = System.Text.Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential(strMailUsuario, strContrasenaUsuario);
                    client.Port = intPuerto;
                    client.Host = strHost;
                    client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail 
                    for (int i = 0; i < lstArchivos_Objeto.Count; i++)
                    {
                        msg.Attachments.Add(new Attachment(lstArchivos_Objeto[i], lstArchivos_Nombre[i]));
                    }
                    client.Send(msg);
                    return true;
                }
                else
                {
                    throw new Exception("El cuerpo del correo no debe estar vacio.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ContruccionDelCuerpoClasico(DateTime dtFecha, string strMensaje)
        {
            strCuerpo = String.Empty;
            strCuerpo += "<div style=\"width: 700px; float: left;\">";
            strCuerpo += "<div style=\"width: 700px; height: 160px; float: left;\">";
            strCuerpo += "<img alt=\"CabezoteCorreo\" title=\"CabezoteEmpresaMail\" src=\"" + global::SIGED_3.CRM.Model.Properties.Settings.Default.URLCorreoImagen + "\" />";
            strCuerpo += "</div>";
            strCuerpo += "<div style=\"width: 700px; float: left;\">";
            strCuerpo += "<div style=\"width: 100px; float: left;\">";
            strCuerpo += String.Empty;
            strCuerpo += "</div>";
            strCuerpo += "<div style=\"width: 500px; float: left; font-family:Calibri; font-size:16px;\">";
            strCuerpo += "<br />Fecha: " + dtFecha;
            strCuerpo += "<br />De: " + strEmisor_Alias;
            strCuerpo += "<br />Para: " + p_Para;
            strCuerpo += "<br /><br /><br />";
            strCuerpo += "Mensaje: <br />" + strMensaje.Replace("\n", "<br />");
            strCuerpo += "<br />Easy Process Company le recuerda que es importante cuidar el medio ambiente y sus recursos, no imprima este mensaje si no es estrictamente necesario.<br />";
            strCuerpo += "<br />No responda a la dirección de correo electrónico que le envía este mensaje.";
            strCuerpo += "</div>";
            strCuerpo += "<div style=\"width: 100px; float: left;\">";
            strCuerpo += String.Empty;
            strCuerpo += "</div>";
            strCuerpo += "</div>";
            strCuerpo += "</div>";
        }
        #endregion
    }
}
