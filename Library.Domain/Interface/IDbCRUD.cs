using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interface
{
    public interface IDbCRUD<T> where T : class, ITable
    {
        IQueryable<T> ListAll();
        T View(int id);
        Task New(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}
