using Library.Domain.Data;
using Library.Domain.Interface;

namespace Library.Domain.Service
{
    public class LanguageService : CRUD<Language>, ILanguage
    {
        public LanguageService(IRepository<Language> _repository) : base(_repository)
        {
        }
    }
}
