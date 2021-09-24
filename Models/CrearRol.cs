using System.ComponentModel.DataAnnotations;

namespace HuertoDelValle.Models
{
    public class CrearRol
    {
        [Required]
        public string RoleName { get; set; }
        public int id { get; set; }
    }
}