using EntityFrameworkApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkApp.Interfaces
{
    public interface IAddress
    {
        IEnumerable<Address> GetAll();
        Address GetById(int id);
        void Add(Address address);
        void Update(Address address);
        void Delete(int id);
    }
}
