using EntityFrameworkApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Repositories
{
    internal interface IStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
    }
}
