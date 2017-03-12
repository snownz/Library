using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models.Pagination
{
    public class BookPagination
    {
        public PaginationData<Book, BookViewModel> Book;
        public BookViewModel Instance => new BookViewModel();

        /// <summary>
        ///     Construtor      
        /// </summary>
        /// <param name="_carregarDados">Função para carregar os dados</param>
        public BookPagination(Func<IQueryable<Book>> _carregarDados)
        {
            Book = new PaginationData<Book, BookViewModel>(_carregarDados);
        }
    }
}