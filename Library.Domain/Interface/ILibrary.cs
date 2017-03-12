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
    }
}
