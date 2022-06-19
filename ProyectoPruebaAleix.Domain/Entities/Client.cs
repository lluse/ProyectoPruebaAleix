using System.ComponentModel.DataAnnotations;

namespace ProyectoPruebaAleix.Domain
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(200)]
        public string Apellidos { get; set; }
        [StringLength(15)]
        public string Nif { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
    }
}
