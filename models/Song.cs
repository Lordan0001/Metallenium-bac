using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metall_Fest.models
{
    public class Song
    {
        [Key]
        public int songId { get; set; }

        [Required]
        public string? songTitle { get; set; }

        [Required]
        [ForeignKey("albumId")]
        public int albumId { get; set; }


    }
}
