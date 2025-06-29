using MySql.Data.MySqlClient;
using RolesUsuariosApp.Modelo;
using System;
using System.Collections.Generic;

namespace RolesUsuariosApp.Datos
{
    public class RolDAO
    {
        // Obtener todos los roles
        public static List<Rol> ObtenerTodos()
        {
            List<Rol> lista = new List<Rol>();

            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("SELECT RolesId, Detalle, FechaCreacion, Activo FROM roles ORDER BY RolesId", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Rol
                    {
                        RolesId = reader.GetInt32("RolesId"),
                        Detalle = reader.GetString("Detalle"),
                        FechaCreacion = reader.GetDateTime("FechaCreacion"),
                        Activo = reader.GetBoolean("Activo")
                    });
                }
            }

            return lista;
        }

        // Insertar nuevo rol
        public static bool Insertar(Rol rol)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("INSERT INTO roles (Detalle, Activo) VALUES (@detalle, @activo)", conn);
                cmd.Parameters.AddWithValue("@detalle", rol.Detalle);
                cmd.Parameters.AddWithValue("@activo", rol.Activo);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Actualizar un rol existente
        public static bool Actualizar(Rol rol)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("UPDATE roles SET Detalle = @detalle, Activo = @activo WHERE RolesId = @id", conn);
                cmd.Parameters.AddWithValue("@detalle", rol.Detalle);
                cmd.Parameters.AddWithValue("@activo", rol.Activo);
                cmd.Parameters.AddWithValue("@id", rol.RolesId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar un rol por ID (si no está en uso)
        public static bool Eliminar(int id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM roles WHERE RolesId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
