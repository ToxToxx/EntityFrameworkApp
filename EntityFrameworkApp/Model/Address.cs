using System.ComponentModel.DataAnnotations;

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
