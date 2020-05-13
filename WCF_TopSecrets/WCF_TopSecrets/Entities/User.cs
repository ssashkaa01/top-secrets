using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_TopSecrets.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(50), MinLength(2)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Login { get; set; }

        [MaxLength(255), MinLength(5)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

       // [Required]
        public string Token { get; set; }

        [Required]
        public string KeyHash { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Secret> Secrets { get; set; }
    }
}
