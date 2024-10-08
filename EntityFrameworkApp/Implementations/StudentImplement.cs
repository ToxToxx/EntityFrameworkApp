﻿using EntityFrameworkApp.Data;
using EntityFrameworkApp.Model;
using EntityFrameworkApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkApp.Implementations
{
    public class StudentImplement : IStudent
    {
        private readonly DataContext _context;

        public StudentImplement(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
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

        public void CreateStudentStorage(Student student, Address address)
        {
            _context.CreateStudent(student, address);
            _context.SaveChanges();
        }

        public IEnumerable<Student> SearchStudents(string searchTerm)
        {
            return _context.Students
                .Include(s => s.AddressObject)
                .Where(s => s.LastName.Contains(searchTerm) ||
                            s.FirstName.Contains(searchTerm) ||
                            s.Patronymic.Contains(searchTerm) ||
                            (s.AddressObject != null && (
                            s.AddressObject.Name.Contains(searchTerm) ||
                            s.AddressObject.City.Contains(searchTerm) ||
                            s.AddressObject.State.Contains(searchTerm) ||
                            s.AddressObject.ZipCode.Contains(searchTerm)
                            )))
                .ToList();
        }
    }
}
