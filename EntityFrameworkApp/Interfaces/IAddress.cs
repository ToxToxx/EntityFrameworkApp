using EntityFrameworkApp.Model;
using System.Collections.Generic;


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
