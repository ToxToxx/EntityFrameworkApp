using EntityFrameworkApp.Data;
using EntityFrameworkApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Implementations
{
    public class StudentImplement : IStudent
    {
        private readonly DataContext _context;

    }
}
