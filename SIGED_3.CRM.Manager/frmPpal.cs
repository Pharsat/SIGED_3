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
using SIGED_3.CRM.Model.Util.Comunicacion;
namespace SIGED_3.CRM.Manager
{
    public partial class frmPpal : Form
    {
        public Cuentas objCuenta;
        public bool Log;
        public frmPpal()
        {
            InitializeComponent();
        }
        private void btnGenerarCodigoActivacion_Click(object sender, EventArgs e)
        {
            if (objCuenta != null)
            {
                string Resultado = new CodigosDeActivacionFachada().GenerarCodigo((short)numericUpDown1.Value, objCuenta.Id);
                if (Resultado != "X")
                {
                    txtCodigoDeActivacion.Text = Resultado;
                    HabilitarDeshabilitarEnvio();
                    MessageBox.Show("Su codigo de validacion es: " + Resultado, " Exito.");
                }
                else
                {
                    MessageBox.Show("No puede obtener codigos de validacion en estos momentos.");
                }
            }
            else
            {
                MessageBox.Show("Debe realizar login para obtener un codigo de activación.");
            }
        }
        private void txtCodigoDeActivacion_TextChanged(object sender, EventArgs e)
        {
            HabilitarDeshabilitarEnvio();
        }
        public void HabilitarDeshabilitarEnvio()
        {
            if (string.IsNullOrEmpty(txtCodigoDeActivacion.Text.Trim()))
            {
                txtCorreoEnvio.Enabled = false;
                btnEnvio.Enabled = false;
                txtNombreNurvoCliente.Enabled = false;
            }
            else
            {
                txtCorreoEnvio.Enabled = true;
                btnEnvio.Enabled = true;
                txtNombreNurvoCliente.Enabled = true;
            }
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            CorreoElectronico objCorreoElectronico = new CorreoElectronico(global::SIGED_3.CRM.Manager.Properties.Settings.Default.EmisorDeLosCorreos, global::SIGED_3.CRM.Manager.Properties.Settings.Default.NombreCompania);
            objCorreoElectronico.p_strAsunto = "Código de registro en SIGED.";
            objCorreoElectronico.Agregar_Receptor(txtCorreoEnvio.Text.Trim(), txtNombreNurvoCliente.Text.Trim());
            string Mensaje = "Bienvenido a SIGED.\r\n\r\nEs una alegria para nosotros comunicarte tu código de registro a nuestra aplicación: " + txtCodigoDeActivacion.Text.Trim() + " .\r\n\r\nPara realizar el registro continue en el siguiente enlace: <a href=\"" + global::SIGED_3.CRM.Manager.Properties.Settings.Default.URLCompania + "Modulos/NuevoUsuario/Registro.aspx\" target=\"_blank\">Activar cuenta.</a>\r\n";
            objCorreoElectronico.ContruccionDelCuerpoClasico(DateTime.Now, Mensaje);
            objCorreoElectronico.EnviarMail();
            objCorreoElectronico = null;
            MessageBox.Show("Se ha enviado la información con exito.");
        }

        private void frmPpal_Load(object sender, EventArgs e)
        {
            Log = false;

            frmValidaAcceso frmValidador = new frmValidaAcceso(this);
            frmValidador.ShowDialog();
            if (Log)
            {
                dgPersonasParaAprobarlesCuenta.AutoGenerateColumns = false;
                dgPersonasParaAprobarlesCuenta.DataSource = new CodigosDeActivacionFachada().ListaDeCodigosParaAprobar();
            }
            else
            {
                this.Close();
            }
        }

        private void dgPersonasParaAprobarlesCuenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                List<LP_CodigosDeActivacionNuevosUsuariosResult> lstDatos = ((List<LP_CodigosDeActivacionNuevosUsuariosResult>)senderGrid.DataSource);
                CodigosDeActivacionFachada objCodigoDeActivacion = new CodigosDeActivacionFachada();
                objCodigoDeActivacion.AprobarCodigo(lstDatos[e.RowIndex].Id, objCuenta.Id);
                MessageBox.Show("Aprobación Concedida", "Aprobación Exitosa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PermisosFachada().PrepararRoles();
        }

    }
}
