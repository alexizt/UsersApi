using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class User
    {
        [Key]
        public string IdValue { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Uuid { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public virtual Location Location { get; set; }

    }
}
