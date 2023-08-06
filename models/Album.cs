using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

       // [Required]
        [ForeignKey("bandId")]
        public int bandId { get; set; }

        [Required]
        public DateTime releaseDate { get; set; }

    }
}
