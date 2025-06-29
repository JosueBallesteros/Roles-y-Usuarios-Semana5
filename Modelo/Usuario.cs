using System;

namespace Roles_y_Usuarios_Semana5.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int? RolesId { get; set; }      // Puede ser null
        public string RoleDetalle { get; set; } // De la vista v_usuarios_completa
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}