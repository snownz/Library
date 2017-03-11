using Library.Domain.Data;
using Library.Domain.Interface;

namespace Library.Domain.Service
{
    public class AuthorService : CRUD<Author>, IAuthor
    {
        public AuthorService(IRepository<Author> _repository) : base(_repository)
        {
        }
    }
}
