using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;
using Telerik.Web.UI;

namespace SIGED_3.CRM.Web.MasterPage
{
    public partial class Ppal_NoSearch : System.Web.UI.MasterPage
    {
        //public UpdatePanel Expose_upLista
        //{
        //    get
        //    {
        //        return this.upPrincipal;
        //    }
        //}
        public void CerrarSesion()
        {
            Session.Abandon();
            Response.Redirect("~/Modulos/Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
            if (!IsPostBack)
            {
                lblNombreMiembro.Text = new MiembroFachada().Seleccionar_Id(SessionManager.Id_Miembro.Value).NombreCompleto;
                lblPerfil.Text = new RolesFachada().Seleccionar_Id(SessionManager.Id_Rol.Value).Rol;
                CargarImagenGrupo();

                FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.NumMenu == 1).ToList(), RadMenu1.Items);
                FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.NumMenu == 2).ToList(), RadMenu2.Items);
                FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.NumMenu == 3).ToList(), RadMenu3.Items);
                FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.NumMenu == 4).ToList(), RadMenu4.Items);
                FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.NumMenu == 5).ToList(), RadMenu5.Items);
                SessionManager.ConfiguracionMenu.ForEach(p => p.Usado = false);
            }
            if (AplicationManager.ConfirmarDuplicidad())
            {
                CerrarSesion();
            }
        }
        protected void btnSalir_Click(object sender, ImageClickEventArgs e)
        {
            CerrarSesion();
        }
        protected void btnEjecutarCambio_Click(object sender, ImageClickEventArgs e)
        {
            if (txtPass.Text.Trim() != "" && txtPassNueva.Text.Trim() != "" && txtPassNuevaComparar.Text.Trim() != "")
            {
                if (new CuentasFachada().CambioContrasena(SessionManager.Id_Cuenta.Value, txtPass.Text.Trim(), txtPassNueva.Text.Trim()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Mensaje('Cambio de contraseña exitoso.')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "Mensaje('Cambio de contraseña invalido.')", true);
                }
            }
        }
        protected void btnCambioContrasena_Click(object sender, ImageClickEventArgs e)
        {
            if (!pnlCambioContrasena.Visible)
            {
                pnlCambioContrasena.Visible = true;
                pnlActualizacionImagenPerfil.Visible = false;
            }
            else
            {
                pnlCambioContrasena.Visible = false;
            }
        }
        protected void btnCambioImagen_Click(object sender, ImageClickEventArgs e)
        {
            if (!pnlActualizacionImagenPerfil.Visible)
            {
                pnlActualizacionImagenPerfil.Visible = true;
                pnlCambioContrasena.Visible = false;
                Miembro objMiembro = new MiembroFachada().Seleccionar_Id(SessionManager.Id_Miembro.Value);
                rbiPerfil.DataValue = objMiembro.Id_Imagen.HasValue ? objMiembro.ImagenMiembro : null;
            }
            else
            {
                pnlActualizacionImagenPerfil.Visible = false;
            }
        }
        protected void btnActualizarImagen_Click(object sender, ImageClickEventArgs e)
        {
            if (rauImagenPerfil.UploadedFiles.Count == 1)
            {
                byte[] Bytes = new byte[rauImagenPerfil.UploadedFiles[0].InputStream.Length];
                rauImagenPerfil.UploadedFiles[0].InputStream.Read(Bytes, 0, Bytes.Length);
                new MiembroFachada().GuardarImagen_Miembro(SessionManager.Id_Miembro.Value, SessionManager.Id_Miembro.Value, Bytes, rauImagenPerfil.UploadedFiles[0].GetName(), rauImagenPerfil.UploadedFiles[0].ContentType);
                Miembro objMiembro = new MiembroFachada().Seleccionar_Id(SessionManager.Id_Miembro.Value);
                rbiPerfil.DataValue = objMiembro.Id_Imagen.HasValue ? objMiembro.ImagenMiembro : null;
            }
        }
        public void CargarImagenGrupo()
        {
            GrupoDeMiembros objGrupo = new GrupoDeMiembrosFachada().Seleccionar_Id(SessionManager.Id_GrupoDeMiembros.Value);
            rbiImagenGrupo.DataValue = objGrupo.Id_Imagen.HasValue ? objGrupo.ImagenGrupo : null;
        }

        public void FabricarMenus(List<S_ConfiguracionMenuResult> lstConfigMenu, RadMenuItemCollection Menu)
        {
            for (int i = 0; i < lstConfigMenu.Count; i++)
            {
                if (!lstConfigMenu[i].Usado)
                {
                    RadMenuItem objItem = new RadMenuItem();
                    if (!string.IsNullOrEmpty(lstConfigMenu[i].Nombre))
                    {
                        objItem.Text = lstConfigMenu[i].Nombre;
                    }
                    if (!string.IsNullOrEmpty(lstConfigMenu[i].URL))
                    {
                        objItem.NavigateUrl = lstConfigMenu[i].URL;
                    }
                    if (!string.IsNullOrEmpty(lstConfigMenu[i].URLImagen))
                    {
                        objItem.ImageUrl = lstConfigMenu[i].URLImagen;
                    }
                    objItem.Value = lstConfigMenu[i].Id.ToString();
                    lstConfigMenu[i].Usado = true;
                    Menu.Add(objItem);
                    FabricarMenus(SessionManager.ConfiguracionMenu.Where(p => p.Id_Modulo_Padre == lstConfigMenu[i].Id && p.Usado == false).ToList(), objItem.Items);
                }
            }
        }
    }
}