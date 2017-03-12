using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models.Pagination
{
    public class CompanyPagination
    {
        public PaginationData<PublishingCompany, CompanyViewModel> Company;
        public CompanyViewModel Instance => new CompanyViewModel();

        /// <summary>
        ///     Construtor      
        /// </summary>
        /// <param name="_carregarDados">Função para carregar os dados</param>
        public CompanyPagination(Func<IQueryable<PublishingCompany>> _carregarDados)
        {
            Company = new PaginationData<PublishingCompany, CompanyViewModel>(_carregarDados);
        }
    }
}