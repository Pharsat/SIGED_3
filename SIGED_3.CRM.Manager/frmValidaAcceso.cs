using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Manager
{
    public partial class frmValidaAcceso : Form
    {
        frmPpal Padre;

        public frmValidaAcceso(frmPpal _Padre)
        {
            Padre = _Padre;
            InitializeComponent();
        }
        private void btnValida_Click(object sender, EventArgs e)
        {
            Cuentas objCuenta = new CuentasFachada().Validar_Usuario(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
            if (objCuenta != null)
            {
                //if (objCuenta.Id_Rol != (int)Roles_Enum.)
                Padre.objCuenta = objCuenta;
                Padre.Log = true;
                this.Close();
            }
            else
            {
                Padre.objCuenta = null;
                MessageBox.Show("Login incorrecto", "Por favor digite de nuevo su login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContraseña.Focus();
            }
        }

        private void frmValidaAcceso_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
