namespace SIGED_3.CRM.Manager
{
    partial class frmPpal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPpal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgPersonasParaAprobarlesCuenta = new System.Windows.Forms.DataGridView();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombresPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoDeActivacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreNurvoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnvio = new System.Windows.Forms.Button();
            this.txtCorreoEnvio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoDeActivacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnGenerarCodigoActivacion = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.codigosDeActivacionFachadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonasParaAprobarlesCuenta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigosDeActivacionFachadaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 265);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgPersonasParaAprobarlesCuenta);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(749, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Codigos de Activación";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgPersonasParaAprobarlesCuenta
            // 
            this.dgPersonasParaAprobarlesCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonasParaAprobarlesCuenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoDocumento,
            this.Documento,
            this.NombresPersona,
            this.CodigoDeActivacion,
            this.Grupo,
            this.Generar});
            this.dgPersonasParaAprobarlesCuenta.Location = new System.Drawing.Point(255, 12);
            this.dgPersonasParaAprobarlesCuenta.Name = "dgPersonasParaAprobarlesCuenta";
            this.dgPersonasParaAprobarlesCuenta.Size = new System.Drawing.Size(466, 190);
            this.dgPersonasParaAprobarlesCuenta.TabIndex = 2;
            this.dgPersonasParaAprobarlesCuenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPersonasParaAprobarlesCuenta_CellContentClick);
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.HeaderText = "Tipo de Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // NombresPersona
            // 
            this.NombresPersona.DataPropertyName = "NombresPersona";
            this.NombresPersona.HeaderText = "Nombres";
            this.NombresPersona.Name = "NombresPersona";
            // 
            // CodigoDeActivacion
            // 
            this.CodigoDeActivacion.DataPropertyName = "CodigoDeActivacion";
            this.CodigoDeActivacion.HeaderText = "Codigo de activación";
            this.CodigoDeActivacion.Name = "CodigoDeActivacion";
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Grupo";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            // 
            // Generar
            // 
            this.Generar.HeaderText = "Generar";
            this.Generar.Name = "Generar";
            this.Generar.Text = "Generar";
            this.Generar.ToolTipText = "Generar";
            this.Generar.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombreNurvoCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEnvio);
            this.groupBox1.Controls.Add(this.txtCorreoEnvio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigoDeActivacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.btnGenerarCodigoActivacion);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 196);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar Codigo de Activación";
            // 
            // txtNombreNurvoCliente
            // 
            this.txtNombreNurvoCliente.Enabled = false;
            this.txtNombreNurvoCliente.Location = new System.Drawing.Point(10, 136);
            this.txtNombreNurvoCliente.Name = "txtNombreNurvoCliente";
            this.txtNombreNurvoCliente.Size = new System.Drawing.Size(214, 20);
            this.txtNombreNurvoCliente.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre (Persona) nuevo cliente";
            // 
            // btnEnvio
            // 
            this.btnEnvio.Enabled = false;
            this.btnEnvio.Location = new System.Drawing.Point(10, 161);
            this.btnEnvio.Name = "btnEnvio";
            this.btnEnvio.Size = new System.Drawing.Size(214, 23);
            this.btnEnvio.TabIndex = 5;
            this.btnEnvio.Text = "Enviar correo con código de activación";
            this.btnEnvio.UseVisualStyleBackColor = true;
            this.btnEnvio.Click += new System.EventHandler(this.btnEnvio_Click);
            // 
            // txtCorreoEnvio
            // 
            this.txtCorreoEnvio.Enabled = false;
            this.txtCorreoEnvio.Location = new System.Drawing.Point(10, 96);
            this.txtCorreoEnvio.Name = "txtCorreoEnvio";
            this.txtCorreoEnvio.Size = new System.Drawing.Size(214, 20);
            this.txtCorreoEnvio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Correo electronico nuevo cliente";
            // 
            // txtCodigoDeActivacion
            // 
            this.txtCodigoDeActivacion.Location = new System.Drawing.Point(10, 47);
            this.txtCodigoDeActivacion.Name = "txtCodigoDeActivacion";
            this.txtCodigoDeActivacion.Size = new System.Drawing.Size(133, 20);
            this.txtCodigoDeActivacion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Num max de usos";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(104, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGenerarCodigoActivacion
            // 
            this.btnGenerarCodigoActivacion.Location = new System.Drawing.Point(149, 45);
            this.btnGenerarCodigoActivacion.Name = "btnGenerarCodigoActivacion";
            this.btnGenerarCodigoActivacion.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarCodigoActivacion.TabIndex = 2;
            this.btnGenerarCodigoActivacion.Text = "Generar";
            this.btnGenerarCodigoActivacion.UseVisualStyleBackColor = true;
            this.btnGenerarCodigoActivacion.Click += new System.EventHandler(this.btnGenerarCodigoActivacion_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(749, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuración Roles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Configurar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(749, 239);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Información Clientes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(749, 239);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Info Aviso Legal Registro";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // codigosDeActivacionFachadaBindingSource
            // 
            this.codigosDeActivacionFachadaBindingSource.DataSource = typeof(SIGED_3.CRM.Model.Servicios.Fachadas.CodigosDeActivacionFachada);
            // 
            // frmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 265);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPpal";
            this.Text = "SIGED Manager";
            this.Load += new System.EventHandler(this.frmPpal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonasParaAprobarlesCuenta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codigosDeActivacionFachadaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.BindingSource codigosDeActivacionFachadaBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgPersonasParaAprobarlesCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombresPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoDeActivacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewButtonColumn Generar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreNurvoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnvio;
        private System.Windows.Forms.TextBox txtCorreoEnvio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoDeActivacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnGenerarCodigoActivacion;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

