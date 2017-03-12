using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models.Pagination
{
    public class AuthorPagination
    {
        public PaginationData<Author, AuthorViewModel> Author;
        public AuthorViewModel Instance => new AuthorViewModel();

        /// <summary>
        ///     Construtor      
        /// </summary>
        /// <param name="_carregarDados">Função para carregar os dados</param>
        public AuthorPagination(Func<IQueryable<Author>> _carregarDados)
        {
            Author = new PaginationData<Author, AuthorViewModel>(_carregarDados);
        }
    }
}