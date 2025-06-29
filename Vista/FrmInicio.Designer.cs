namespace Roles_y_Usuarios_Semana5.Vista
{
    partial class FrmInicio
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Menú Principal";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(90, 20);
            this.lblTitulo.Size = new System.Drawing.Size(200, 30);

            // 
            // btnRoles
            // 
            this.btnRoles.Text = "Gestión de Roles";
            this.btnRoles.Location = new System.Drawing.Point(100, 70);
            this.btnRoles.Size = new System.Drawing.Size(150, 40);
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);

            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Text = "Gestión de Usuarios";
            this.btnUsuarios.Location = new System.Drawing.Point(100, 130);
            this.btnUsuarios.Size = new System.Drawing.Size(150, 40);
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            // 
            // FrmInicio
            // 
            this.ClientSize = new System.Drawing.Size(360, 220);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
        }
    }
}
