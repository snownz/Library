using Library.Domain.Data;
using Library.Domain.Interface;
using System.Threading.Tasks;

namespace Library.Domain.Service
{
    public class BookService : CRUD<Book>, ILibrary
    {
        private readonly IRepository<BookRating> _ratingRepository;

        public BookService(IRepository<Book> _repository, IRepository<BookRating> _ratingRepository) : base(_repository)
        {
            this._ratingRepository = _ratingRepository;
        }

        public async Task RateBook(int idBook, double rate)
        {
            var r = new BookRating
            {
                Id_Book = idBook,
                Rate = rate
            };
            await _ratingRepository.InsertAsync(r);
        }
    }
}
