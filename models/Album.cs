using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metall_Fest.models
{
    public class Album
    {
        [Key]
        public int albumId { get; set; }
        [Required]
        public string? albumName { get; set; }
        [Required]
        public int bandId { get; set; }
        [ForeignKey("bandId")]
        public virtual Band band { get; set; }
        [Required]
        public DateTime releaseDate { get; set; }
    }
}
