using System;
using System.Windows.Forms;

namespace Roles_y_Usuarios_Semana5.Vista
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            FrmRoles frm = new FrmRoles();
            frm.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }
    }
}
