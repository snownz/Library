using Library.Domain.Data;
using Library.Domain.Interface;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Library.Domain.Service
{
    public class BookService : CRUD<Book>, ILibrary
    {
        public BookService(IRepository<Book> _repository) : base(_repository)
        {

        }
    }
}
