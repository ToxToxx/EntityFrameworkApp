using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.ViewModel
{
    public class StudentViewModel
    {
        public int IdStudent { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string FullAddress { get; set; }
    }
}
