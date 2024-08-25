using EntityFrameworkApp.Data;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Implementations
{
    public class AddressImplement : IAddress
    {
        private readonly DataContext _context;

        public AddressImplement(DataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Find(id);
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.Find(id);
            if(address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }
    }
}
