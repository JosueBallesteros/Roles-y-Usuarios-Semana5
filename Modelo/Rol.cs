using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolesUsuariosApp.Modelo
{
    public class Rol
    {
        public int RolesId { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}