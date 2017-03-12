using System;
using NUnit.Framework;
using Library.Domain.Interface;
using Library.Presentation.Controllers;
using Library.Presentation.Models;
using System.Web.Mvc;
using Library.Tests.Sources;
using Library.Domain.Data;
using Library.Domain.Service;
using Library.Domain.DbConfig;
using Library.Presentation.App_Start;
using System.Collections.Generic;
using Library.Presentation.Models.Pagination;

namespace Library.Tests.Controllers
{
    [TestFixture]
    public class BookControllerTest
    {
        private static IRepository<Book> _repo;
        private static IRepository<Author> _repo1;
        private static IRepository<PublishingCompany> _repo2;
        private static IRepository<Language> _repo3;

        private static ILibrary _service;
        private static IAuthor _service1;
        private static ICompany _service2;
        private static ILanguage _service3;

        [OneTimeSetUp]
        public void Init()
        {
            AutoMapperConfig.RegisterMapping();
        }

        private void _init()
        {
            _repo = new MockRepository<Book>();
            _repo1 = new MockRepository<Author>();
            _repo2 = new MockRepository<PublishingCompany>();
            _repo3 = new MockRepository<Language>();

            _service = new BookService(_repo);
            _service1 = new AuthorService(_repo1);
            _service2 = new CompanyService(_repo2);
            _service3 = new LanguageService(_repo3);
        }

        [Test, Category("Unit"), TestCaseSource(typeof(BookSource), "BookNewSource")]
        public void TestNew(BookViewModel model, string test, string result)
        {
            _init();
            BooksController controler = new BooksController(_service, _service1, _service2, _service3);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as BookViewModel).Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(BookSource), "BookDeleteSource")]
        public void TestDelete(BookViewModel model, int id, string test)
        {
            _init();
            BooksController controler = new BooksController(_service, _service1, _service2, _service3);
            controler.New(model).GetAwaiter().GetResult();
            controler.Delete(id).GetAwaiter().GetResult();
            try
            {
                var r = controler.Vizualise(1) as PartialViewResult;
                Assert.Fail($"Erro no Teste: {test}");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test, Category("Unit"), TestCaseSource(typeof(BookSource), "BookUpdateSource")]
        public void TestUpdate(BookViewModel model, string name, string test, string result)
        {
            _init();
            BooksController controler = new BooksController(_service, _service1, _service2, _service3);
            controler.New(model).GetAwaiter().GetResult();            
            var r = controler.Vizualise(1) as PartialViewResult;
            var _model = (r.Model as BookViewModel);
            _model.Name = name;
            controler.Update(_model).GetAwaiter().GetResult();
            r = controler.Vizualise(1) as PartialViewResult;
            _model = (r.Model as BookViewModel);
            Assert.IsTrue(_model.Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(BookSource), "BookGetAllSource")]
        public void TestListAll(ICollection<BookViewModel> model, string search, int page, string test, int result)
        {
            _init();
            BooksController controler = new BooksController(_service, _service1, _service2, _service3);
            foreach (var item in model)
            {
                controler.New(item).GetAwaiter().GetResult();
            }
            var r = controler.ListAll(search, page) as PartialViewResult; 
            var _model = (r.Model as BookPagination);
            Assert.IsTrue((r.Model as BookPagination).Book.Dados.Count == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(BookSource), "BookViewSource")]
        public void TestView(BookViewModel model, string test)
        {
            _init();
            BooksController controler = new BooksController(_service, _service1, _service2, _service3);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as BookViewModel) != null, $"Erro no Teste: {test}");
        }
    }
}
