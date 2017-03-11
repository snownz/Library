using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interface
{
    /// <summary>
    ///     Interface de serviços
    /// </summary>
    public interface ILibrary : IDbCRUD<Book>
    {
        Task RateBook(int idBook, double rate);
    }
}
