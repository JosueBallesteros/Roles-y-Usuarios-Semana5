namespace Roles_y_Usuarios_Semana5.Vista
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRol;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // 
            // Labels
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 20);
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new System.Drawing.Point(30, 50);
            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Location = new System.Drawing.Point(30, 80);
            this.lblRol.Text = "Rol:";
            this.lblRol.Location = new System.Drawing.Point(30, 110);

            this.lblNombre.AutoSize = true;
            this.lblCorreo.AutoSize = true;
            this.lblPassword.AutoSize = true;
            this.lblRol.AutoSize = true;

            // 
            // TextBoxes
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 20);
            this.txtCorreo.Location = new System.Drawing.Point(120, 50);
            this.txtPassword.Location = new System.Drawing.Point(120, 80);
            this.txtPassword.UseSystemPasswordChar = true;

            this.cbRoles.Location = new System.Drawing.Point(120, 110);
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.chkActivo.Text = "Activo";
            this.chkActivo.Checked = true;
            this.chkActivo.Location = new System.Drawing.Point(120, 140);

            // 
            // Buttons
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(120, 180);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(220, 180);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(320, 180);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // 
            // DataGridView
            // 
            this.dgvUsuarios.Location = new System.Drawing.Point(30, 230);
            this.dgvUsuarios.Size = new System.Drawing.Size(640, 200);
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.AutoGenerateColumns = true;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);

            // 
            // FrmUsuarios
            // 
            this.ClientSize = new System.Drawing.Size(720, 470);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cbRoles);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvUsuarios);
            this.Text = "Gestión de Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
