using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TopSecrets.Entities
{
    public class Secret
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255), MinLength(10)]
        public string Url { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
    }
}
