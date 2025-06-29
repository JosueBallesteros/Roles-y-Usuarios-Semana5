using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Roles_y_Usuarios_Semana5.Modelo;
using Roles_y_Usuarios_Semana5.Datos;

namespace Roles_y_Usuarios_Semana5.Vista
{
    public partial class FrmUsuarios : Form
    {
        private int? usuarioIdSeleccionado = null;

        public FrmUsuarios()
        {
            InitializeComponent();
            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            var roles = UsuarioDAO.ObtenerRoles();
            cbRoles.DataSource = roles;
            cbRoles.DisplayMember = "Detalle";
            cbRoles.ValueMember = "RolesId";
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = UsuarioDAO.ObtenerTodos();
            dgvUsuarios.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool activo = chkActivo.Checked;
            int? rolId = cbRoles.SelectedValue as int?;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            Usuario u = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Password = password,
                Activo = activo,
                RolesId = rolId
            };

            bool resultado;

            if (usuarioIdSeleccionado == null)
            {
                resultado = UsuarioDAO.Insertar(u);
            }
            else
            {
                u.UsuarioId = usuarioIdSeleccionado.Value;
                resultado = UsuarioDAO.Actualizar(u);
            }

            if (resultado)
            {
                MessageBox.Show("Usuario guardado correctamente.");
                LimpiarFormulario();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el usuario.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioIdSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                if (UsuarioDAO.Eliminar(usuarioIdSeleccionado.Value))
                {
                    MessageBox.Show("Usuario eliminado.");
                    LimpiarFormulario();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.");
                }
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];
                usuarioIdSeleccionado = Convert.ToInt32(fila.Cells["UsuarioId"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtPassword.Text = ""; // Nunca mostramos contraseñas
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);

                // Seleccionar el rol correspondiente
                if (fila.Cells["RolesId"].Value != DBNull.Value)
                {
                    cbRoles.SelectedValue = Convert.ToInt32(fila.Cells["RolesId"].Value);
                }
                else
                {
                    cbRoles.SelectedIndex = -1;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            chkActivo.Checked = true;
            cbRoles.SelectedIndex = -1;
            usuarioIdSeleccionado = null;
            dgvUsuarios.ClearSelection();
        }
    }
}
