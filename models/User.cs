using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metall_Fest.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? userName { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }
  
        public string? role { get; set; }
        [Required]
        public string? password { get; set; } //пилим костыли

   
        public byte[]? passwordHash { get; set; }

   
        public byte[]? passwordSalt { get; set; }
        [Column(TypeName = "money")]
        public decimal? money { get; set; }

    }
}
