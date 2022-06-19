using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Domain
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nif { get; set; }
        public string Email { get; set; }
    }
}
