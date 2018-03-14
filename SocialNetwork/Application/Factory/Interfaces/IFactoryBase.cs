using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factory.Interfaces
{
    interface IFactoryBase<T> where T : class
    {
        T Build();
        
    }
}
