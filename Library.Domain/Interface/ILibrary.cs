using Library.Domain.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interface
{
    /// <summary>
    ///     Interface de serviços
    /// </summary>
    public interface ILibrary : IDbCRUD<Book>
    {
        Task RateBook(int idBook, double rate);
        ICollection<Book> GetSimilarity(Book model);
    }
}
