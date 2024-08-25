using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using EntityFrameworkApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            // Eagerly load the AddressObject
            return _context.Students.Include(s => s.AddressObject).ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Include(s => s.AddressObject).FirstOrDefault(s => s.IdStudent == id);
        }

        public void Add(Student student)
        {
            var address = _context.Addresses.Find(student.AddressId);
            if (address == null)
            {
                throw new InvalidOperationException("The specified AddressId does not exist.");
            }
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
