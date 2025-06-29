using System;
using System.Windows.Forms;
using Roles_y_Usuarios_Semana5.Vista;

namespace Roles_y_Usuarios_Semana5
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmInicio()); // Ahora abre el menú principal
        }
    }
}
