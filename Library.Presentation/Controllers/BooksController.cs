using AutoMapper;
using Library.Domain.Data;
using Library.Domain.Interface;
using Library.Presentation.Models;
using Library.Presentation.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.Presentation.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILibrary _service;
        private readonly IAuthor _serviceA;
        private readonly ICompany _serviceC;
        private readonly ILanguage _serviceL;

        private BookPagination book;

        public BooksController(ILibrary _service, IAuthor _serviceA, ICompany _serviceC, ILanguage _serviceL)
        {
            this._service = _service;
            this._serviceA = _serviceA;
            this._serviceC = _serviceC;
            this._serviceL = _serviceL;

            book = new BookPagination
            (
                () => { return _service.ListAll().OrderBy(x => x.Name); }
            );
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialSpecialBooks(string search = null, int page = 1, bool action = false)
        {
            book = new BookPagination
            (
                () => { return _service.ListAll().Where(x=>x.SpecialEdition).OrderBy(x => x.Name); }
            );
            book.Book.QuantidadeMaxima = 4;
            book.Book.PaginaAtual = page;
            book.Book.Busca = search;
            ViewBag.Action = action;
            return PartialView(book);
        }

        public ActionResult PartialBooks(string search = null, int page = 1, bool action = false)
        {
            book.Book.PaginaAtual = page;
            book.Book.Busca = search;
            ViewBag.Action = action;
            return PartialView(book);
        }

        /// <summary>
        ///     Insere um novo objeto no banco, verificando a validade da model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]        
        public async Task New(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.New(Mapper.Map<Book>(model));
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
        public async Task Update(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(Mapper.Map<Book>(model));
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
            book.Book.PaginaAtual = page;
            book.Book.Busca = search;
            ViewBag.Action = action;
            return PartialView(book);
        }
        /// <summary>
        ///     Retorna um objeto para vizualização (alterar e inserir)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Vizualise(int? id)
        {
            ViewBag.Author = Mapper.Map<IEnumerable<SelectListItem>>(_serviceA.ListAll());
            ViewBag.Company = Mapper.Map<IEnumerable<SelectListItem>>(_serviceC.ListAll());
            ViewBag.Language = Mapper.Map<IEnumerable<SelectListItem>>(_serviceL.ListAll());

            if (id == null)
            {
                return PartialView(new BookViewModel());
            }
            var model = _service.View(id.Value);
            var view = Mapper.Map<BookViewModel>(model);
            view.New = false;
            return PartialView(view);
        }
    }
}