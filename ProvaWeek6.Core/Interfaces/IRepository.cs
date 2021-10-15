using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaWeek6.Core.Interfaces
{
   public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T,bool> filter =null);
        T GetById(int id);
        bool Add(T newItem);
        bool Edit(T editedItem);
        bool DeleteById(int id);
    }
}
