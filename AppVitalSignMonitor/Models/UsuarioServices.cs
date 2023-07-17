namespace AppVitalSignMonitor.Models
{
    public class UsuarioServices
    {
        private static List<Usuario> Usuarios = new List<Usuario>()
            {
                new Usuario {NombreUsuario = "JuanLagreca7",
                Email = "Juanlagreca8@gmail.com",
                Contrasena = "17111991",
                NombreApellido = "Juan Lagreca Zabala",
                Telefono = "099335316",
                Direccion = "Av. Paraguay 1050",
                Rol = "Administrador" },
                new Usuario {NombreUsuario = "SenisaDiego15",
                Email = "DiegoSenisa15@gmail.com",
                Contrasena = "123456",
                NombreApellido = "Diego Senisa",
                Telefono = "099123456",
                Direccion = "Zorrilla 322 Apto. 101",
                Rol = "Paciente" }
            };
        public Usuario BuscarUsuario(string NombreUsaurio, string Contrasena)
        {
            return Usuarios.FirstOrDefault(u => u.NombreUsuario == NombreUsaurio && u.Contrasena == Contrasena); // Utilizamos el "FirstOrDefault" porque esperamos nos devuleva un unico valor.
        }
    }
}
