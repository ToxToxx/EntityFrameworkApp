using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Model
{
    public class Student
    {
        public int IdStudent { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength (50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public int Address { get; set; }
    }
}   
