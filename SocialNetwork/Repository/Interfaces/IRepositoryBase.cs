using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        bool Save(T obj);
        List<T> GetAll();
        T GetById(int id);
        bool Update(T obj);
        bool Remove(int id);
    }
}
