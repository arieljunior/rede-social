using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        bool Create(T obj);
        IEnumerable<T> GetAll();
        T GetById(string id);
        bool UpDate(T obj);
        bool Delete(string id);
    }
}
