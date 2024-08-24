using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Model
{
    public class Address
    {
        [Key]
        public int IdAddress { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
