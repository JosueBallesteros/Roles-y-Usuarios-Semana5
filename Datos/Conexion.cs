using MySql.Data.MySqlClient;
using System;

namespace RolesUsuariosApp.Datos
{
    public class Conexion
    {
        private static string cadenaConexion = "server=localhost;database=roles_usuarios_semana5;user=root;password=;";

        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }
    }
}
