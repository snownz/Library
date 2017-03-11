using Library.Domain.Data;
using Library.Domain.Interface;

namespace Library.Domain.Service
{
    public class CompanyService : CRUD<PublishingCompany>, ICompany
    {
        public CompanyService(IRepository<PublishingCompany> _repository) : base(_repository)
        {
        }
    }
}
