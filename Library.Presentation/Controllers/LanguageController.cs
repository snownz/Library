using AutoMapper;
using Library.Domain.Data;
using Library.Domain.Interface;
using Library.Presentation.Models;
using Library.Presentation.Models.Pagination;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Library.Presentation.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguage _service;
        private readonly LanguagePagination language;

        public LanguageController(ILanguage _service)
        {
            this._service = _service;
            language = new LanguagePagination
            (
                () => { return _service.ListAll().OrderBy(x => x.Id); }
            );
        }
        /// <summary>
        ///     Insere um novo objeto no banco, verificando a validade da model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]        
        public async Task New(LanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.New(Mapper.Map<Language>(model));
            }
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        ///     Inativa um objeto no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
        /// <summary>
        ///     Altera um objeto no banco
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]        
        public async Task Update(LanguageViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _service.Update(Mapper.Map<Language>(model));
            }
             else
            {
                throw new Exception();
            }
        }
        /// <summary>
        ///     Lista todos os objetos, filtrados por pagina e texto de busca
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListAll(string search = null, int page = 1, bool action = false)
        {
            language.Language.PaginaAtual = page;
            language.Language.Busca = search;
            ViewBag.Action = action;
            return PartialView(language);
        }
        /// <summary>
        ///     Retorna um objeto para vizualização (alterar e inserir)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Vizualise(int? id)
        {
            if(id == null)
            {
                return PartialView(new LanguageViewModel());
            }
            var model = _service.View(id.Value);
            var view = Mapper.Map<LanguageViewModel>(model);
            view.New = false;
            return PartialView(view);
        }
    }
}