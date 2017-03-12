using AutoMapper;
using Library.Domain.Data;
using Library.Domain.Interface;
using Library.Presentation.Models;
using Library.Presentation.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _service;
        private readonly CompanyPagination company;

        public CompanyController(ICompany _service)
        {
            this._service = _service;
            company = new CompanyPagination
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
        public async Task New(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.New(Mapper.Map<PublishingCompany>(model));
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
        public async Task Update(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(Mapper.Map<PublishingCompany>(model));
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
            company.Company.PaginaAtual = page;
            company.Company.Busca = search;
            ViewBag.Action = action;
            return PartialView(company);
        }
        /// <summary>
        ///     Retorna um objeto para vizualização (alterar e inserir)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Vizualise(int? id)
        {
            if (id == null)
            {
                return PartialView(new CompanyViewModel());
            }
            var model = _service.View(id.Value);
            var view = Mapper.Map<CompanyViewModel>(model);
            view.New = false;
            return PartialView(view);
        }
    }
}