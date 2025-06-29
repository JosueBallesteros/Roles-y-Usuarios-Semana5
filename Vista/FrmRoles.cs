using Roles_y_Usuarios_Semana5.Datos;
using Roles_y_Usuarios_Semana5.Modelo;
using RolesUsuariosApp.Datos;
using RolesUsuariosApp.Modelo;
using System;
using System.Windows.Forms;

namespace Roles_y_Usuarios_Semana5.Vista
{
    public partial class FrmRoles : Form
    {
        private int? rolIdSeleccionado = null;

        public FrmRoles()
        {
            InitializeComponent();
            CargarRoles();
        }

        private void CargarRoles()
        {
            dgvRoles.DataSource = null;
            dgvRoles.DataSource = RolDAO.ObtenerTodos();
            dgvRoles.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string detalle = txtDetalle.Text.Trim();
            bool activo = chkActivo.Checked;

            if (string.IsNullOrWhiteSpace(detalle))
            {
                MessageBox.Show("Debe ingresar el detalle del rol.");
                return;
            }

            Rol rol = new Rol
            {
                Detalle = detalle,
                Activo = activo
            };

            bool resultado;

            if (rolIdSeleccionado == null)
            {
                resultado = RolDAO.Insertar(rol);
            }
            else
            {
                rol.RolesId = rolIdSeleccionado.Value;
                resultado = RolDAO.Actualizar(rol);
            }

            if (resultado)
            {
                MessageBox.Show("Rol guardado correctamente.");
                LimpiarFormulario();
                CargarRoles();
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el rol.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rolIdSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar este rol?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                if (RolDAO.Eliminar(rolIdSeleccionado.Value))
                {
                    MessageBox.Show("Rol eliminado.");
                    LimpiarFormulario();
                    CargarRoles();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el rol. Verifica si está en uso.");
                }
            }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvRoles.Rows[e.RowIndex];
                rolIdSeleccionado = Convert.ToInt32(fila.Cells["RolesId"].Value);
                txtDetalle.Text = fila.Cells["Detalle"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtDetalle.Clear();
            chkActivo.Checked = true;
            rolIdSeleccionado = null;
            dgvRoles.ClearSelection();
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {

        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
