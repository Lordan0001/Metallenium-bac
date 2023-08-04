using System.ComponentModel.DataAnnotations;

namespace Metall_Fest.models
{
    public class Band
    {
        [Key]
        public int bandId { get; set; }
        [Required]
        public string? bandName { get; set; }
        [Required]
        public string? bandDescription { get; set; }
        [Required]
        public string? bandType { get; set; }
        public string? imageUrl { get; set; }

    }
}
