using System;

namespace Modelos.ModelosDominio
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string idUnico { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string direccion2 { get; set; }
        public int edad { get; set; }
        public DateTime fechaAlta { get; set; }
    }
}