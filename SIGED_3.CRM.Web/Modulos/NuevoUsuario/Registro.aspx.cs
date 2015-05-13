using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using System.Drawing;
using SIGED_3.CRM.Model.Negocio.Entidades;

namespace SIGED_3.CRM.Web.Modulos.NuevoUsuario
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(View1);
                dtFechaNacimiento.MinDate = new DateTime(1940, 1, 1);
                dtFechaNacimiento.MaxDate = DateTime.Now.ToUniversalTime().AddYears(-18);
                dtFechaNacimiento.SelectedDate = DateTime.Now.ToUniversalTime().AddYears(-18).AddMinutes(-1);
                if (Request["Num1"] != null)
                {
                    Miembro objMiembro = new MiembroFachada().Seleccionar_Id(long.Parse(Request["Num1"].ToString()));
                    SIGED_3.CRM.Model.Negocio.Entidades.GrupoDeMiembros objGrupo = new GrupoDeMiembrosFachada().Seleccionar_Id(objMiembro.Id_GrupoDeMiembros.Value);
                    MultiView1.SetActiveView(View2);

                    txtNombreGrupo.Enabled = false;
                    cboPais.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboCiudad.Enabled = false;
                    txtDescripcion.Enabled = false;

                    txtNombreGrupo.Text = objGrupo.Nombre;
                    cboPais.SelectedValue = objGrupo.Id_Pais.ToString();
                    cboProvincia.DataBind();
                    cboProvincia.SelectedValue = objGrupo.Id_Provincia.ToString();
                    cboCiudad.DataBind();
                    cboCiudad.SelectedValue = objGrupo.Id_Ciudad.ToString();
                    txtDescripcion.Text = objGrupo.Descripcion;

                    cboTipoDeDocumento.SelectedValue = objMiembro.Id_TipoDeDocumento.Value.ToString();
                    txtNroDocumento.DbValue = objMiembro.Identificacion;
                    txtNombres.Text = objMiembro.Nombres;
                    txtApellidos.Text = objMiembro.Apellidos;
                    dtFechaNacimiento.SelectedDate = objMiembro.FechaDeNacimiento;
                    txtEmail.Text = objMiembro.Email;

                    cboTipoDeDocumento.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtNombres.Enabled = false;
                    txtApellidos.Enabled = false;
                    dtFechaNacimiento.Enabled = false;
                    txtEmail.Enabled = false;
                }
            }
        }
        protected void btnValidarCodigo_Click(object sender, ImageClickEventArgs e)
        {
            if (new CodigosDeActivacionFachada().Verificar(txtCodigoActivacion.Text, false))
            {
                MultiView1.SetActiveView(View2);
            }
            else
            {
                txtCodigoActivacion.BackColor = ColorTranslator.FromHtml("#f85a76");
            }
        }
        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            if (chkAcepto.Checked)
            {
                if (!new CuentasFachada().ComprobarUsuario(txtUsuario.Text.Trim()))
                {
                    if (Request["Num1"] == null)
                    {
                        if (new CuentasFachada().RegistrarAcceso(txtNombreGrupo.Text.Trim(), long.Parse(cboPais.SelectedValue), long.Parse(cboProvincia.SelectedValue), long.Parse(cboCiudad.SelectedValue), txtDescripcion.Text.Trim(), long.Parse(cboTipoDeDocumento.SelectedValue), (long)txtNroDocumento.Value, txtNombres.Text.Trim(), txtApellidos.Text.Trim(), dtFechaNacimiento.SelectedDate.Value, txtEmail.Text.Trim(), txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtCodigoActivacion.Text.Trim()))
                        {
                            MultiView1.SetActiveView(View3);
                            ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Registro exitoso.\\r\\n\\r\\nSe le ha enviado la información necesaria para activar su cuenta al Email indicado en este formulario, dispone de 3 días para realizar la activación.')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Upss, lo sentimos algo ha fallado.')", true);
                        }
                    }
                    else
                    {
                        Miembro objMiembro = new MiembroFachada().Seleccionar_Id(long.Parse(Request["Num1"].ToString()));
                        if (new CuentasFachada().RegistrarAccesoDos(objMiembro.Id_GrupoDeMiembros.Value, objMiembro.Id, txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtCodigoActivacion.Text.Trim()))
                        {
                            MultiView1.SetActiveView(View3);
                            ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Registro exitoso.\\r\\n\\r\\nSe le ha enviado la información necesaria para activar su cuenta al Email indicado en este formulario, dispone de 3 días para realizar la activación.')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Upss, lo sentimos algo ha fallado.')", true);
                        }
                    }
                }
                else
                {
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                    ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('El Usuario inidicado no esta disponible.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upDetalle, upDetalle.GetType(), "CallMyFunction", "Mensaje('Debe aceptar los términos y condiciones de uso.')", true);
            }
        }
    }
}