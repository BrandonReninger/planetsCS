using System.ComponentModel.DataAnnotations;

namespace planetsCSapi.Models
{
    public class Planet
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Category { get; set; }
        public bool Habitable { get; set; }
        public int Distance { get; set; }
    }
}