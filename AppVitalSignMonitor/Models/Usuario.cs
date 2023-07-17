namespace AppVitalSignMonitor.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string NombreApellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Rol { get; set; } // Podria en caso de ser necesario ser una lista, en casos donde un usuario tiene varios roles.
    }
}