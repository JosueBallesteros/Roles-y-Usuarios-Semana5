using MySql.Data.MySqlClient;
using Roles_y_Usuarios_Semana5.Modelo;
using RolesUsuariosApp.Datos;
using RolesUsuariosApp.Modelo;
using System;
using System.Collections.Generic;

namespace Roles_y_Usuarios_Semana5.Datos
{
    public class UsuarioDAO
    {
        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT * FROM v_usuarios_completa ORDER BY UsuarioId", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.UsuarioId = Convert.ToInt32(reader["UsuarioId"]);
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Correo = reader["correo"].ToString();
                    usuario.Password = ""; // No mostramos la contraseña

                    object valorRol = reader["RolesId"];
                    usuario.RolesId = valorRol == DBNull.Value ? (int?)null : Convert.ToInt32(valorRol);

                    usuario.RoleDetalle = reader["RoleDetalle"].ToString();
                    usuario.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    usuario.FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]);
                    usuario.Activo = Convert.ToBoolean(reader["Activo"]);

                    lista.Add(usuario);
                }
            }

            return lista;
        }

        public static bool Insertar(Usuario u)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand(@"INSERT INTO usuarios (Nombre, correo, password, RolesId, Activo)
                                             VALUES (@nombre, @correo, @password, @rolId, @activo)", conn);

                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@rolId", u.RolesId);
                cmd.Parameters.AddWithValue("@activo", u.Activo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool Actualizar(Usuario u)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand(@"UPDATE usuarios 
                                             SET Nombre = @nombre, correo = @correo, password = @password, 
                                                 RolesId = @rolId, Activo = @activo 
                                             WHERE UsuarioId = @id", conn);

                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@correo", u.Correo);
                cmd.Parameters.AddWithValue("@password", u.Password);
                cmd.Parameters.AddWithValue("@rolId", u.RolesId);
                cmd.Parameters.AddWithValue("@activo", u.Activo);
                cmd.Parameters.AddWithValue("@id", u.UsuarioId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool Eliminar(int id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM usuarios WHERE UsuarioId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static List<Rol> ObtenerRoles()
        {
            List<Rol> roles = new List<Rol>();

            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT RolesId, Detalle FROM roles WHERE Activo = 1", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.RolesId = reader.GetInt32("RolesId");
                    rol.Detalle = reader.GetString("Detalle");
                    roles.Add(rol);
                }
            }

            return roles;
        }
    }
}
