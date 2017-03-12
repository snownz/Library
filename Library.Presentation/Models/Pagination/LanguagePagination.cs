using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models.Pagination
{
    public class LanguagePagination
    {
        public PaginationData<Language, LanguageViewModel> Language;
        public LanguageViewModel Instance => new LanguageViewModel();
        /// <summary>
        ///     Construtor      
        /// </summary>
        /// <param name="_carregarDados">Função para carregar os dados</param>
        public LanguagePagination(Func<IQueryable<Language>> _carregarDados)
        {
            Language = new PaginationData<Language, LanguageViewModel>(_carregarDados);
        }
    }
}