using System.ComponentModel.DataAnnotations;

namespace planetsCSapi.Models
{
    public class Planet
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Habitable { get; set; }
        public int Distance { get; set; }
    }
}