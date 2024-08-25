using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using EntityFrameworkApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Implementations
{
    public class StudentRepository : IStudent
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Add(Student student)
        {
            // Ensure the Address exists before adding the student
            var address = _context.Addresses.Find(student.AddressId);
            if (address == null)
            {
                // Address not found, handle this scenario.
                throw new InvalidOperationException("The specified AddressId does not exist.");
            }
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if(student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
