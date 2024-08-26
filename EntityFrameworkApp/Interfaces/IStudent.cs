using EntityFrameworkApp.Model;
using System.Collections.Generic;


namespace EntityFrameworkApp.Repositories
{
    public interface IStudent
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);

    }
}
