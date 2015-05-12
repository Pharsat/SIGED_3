using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Util.Session;
using System.Web.UI.HtmlControls;
namespace SIGED_3.CRM.Web.Modulos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUsuario.Focus();
                if (Request["Num1"] != null)
                {
                    if (Request["Num2"] != null)
                    {
                        try
                        {
                            if (new CuentasFachada().ComprobarActivacionCuenta(long.Parse(Request["Num1"].ToString()), int.Parse(Request["Num2"].ToString())))
                            {
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "CallMyFunction", "Mensaje('Cuenta activada correctamente, !A Disfrutar¡.')", true);
                            }
                        }
                        catch
                        {
                            Response.Redirect("~/Modulos/Login.aspx");
                        }
                    }
                }

                Page.Header.DataBind();
            }
        }
        protected void btnEntrar_Click(object sender, ImageClickEventArgs e)
        {
            Cuentas objCuenta = new CuentasFachada().Validar_Usuario(txtUsuario.Text.Trim(), txtPass.Text.Trim());
            if (objCuenta != null)
            {
                SessionManager.Id_GrupoDeMiembros = objCuenta.Id_GrupoDeMiembros;
                SessionManager.Id_Miembro = objCuenta.Id_Miembro;
                SessionManager.Id_Cuenta = objCuenta.Id;
                SessionManager.Id_Rol = objCuenta.Id_Rol;
                SessionManager.ConfiguracionPermisos = new PermisosFachada().ConfiguracionPermisos(SessionManager.Id_Cuenta);
                SessionManager.ConfiguracionMenu = new ModuloFachada().ConfiguracionModulo(SessionManager.Id_Cuenta);
                SessionManager.Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                AplicationManager.IncluirToken();
                Response.Redirect("~/Modulos/Inicio.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }
        protected void btnNuevoUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Modulos/NuevoUsuario/Registro.aspx");
        }
        protected void btnRecordarContrasena_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Modulos/RecordarContrasena/RecordarContrasena.aspx");
        }
    }
}