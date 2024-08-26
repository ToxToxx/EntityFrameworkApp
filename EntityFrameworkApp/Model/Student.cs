using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkApp.Model
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength (50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address AddressObject { get; set; }
    }
}   
