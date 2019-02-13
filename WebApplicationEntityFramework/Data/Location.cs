using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationEntityFramework.Data
{
    public class Location
    {
        [Key]
        [ForeignKey("User")]
        public string UserLocationId { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostCode { get; set; }

        public virtual User User { get; set; }
    }

}
