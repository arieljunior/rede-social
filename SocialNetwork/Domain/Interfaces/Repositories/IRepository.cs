using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Save(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool UpDate(T obj);
        bool Remove(int id);
    }
}
