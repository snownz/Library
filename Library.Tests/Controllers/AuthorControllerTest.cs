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
    public class AuthorControllerTest
    {
        private static IRepository<Author> _repo = new MockRepository<Author>();
        private static IAuthor _service = new AuthorService(_repo);

        [OneTimeSetUp]
        public void Init()
        {
            AutoMapperConfig.RegisterMapping();
        }

        private void _init()
        {
            _repo = new MockRepository<Author>();
            _service = new AuthorService(_repo);
        }

        [Test, Category("Unit"), TestCaseSource(typeof(AuthorSource), "AuthorNewSource")]
        public void TestNew(AuthorViewModel model, string test, string result)
        {
            _init();
            AuthorController controler = new AuthorController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as AuthorViewModel).Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(AuthorSource), "AuthorDeleteSource")]
        public void TestDelete(AuthorViewModel model, int id, string test)
        {
            _init();
            AuthorController controler = new AuthorController(_service);
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

        [Test, Category("Unit"), TestCaseSource(typeof(AuthorSource), "AuthorUpdateSource")]
        public void TestUpdate(AuthorViewModel model, string name, string test, string result)
        {
            _init();
            AuthorController controler = new AuthorController(_service);
            controler.New(model).GetAwaiter().GetResult();            
            var r = controler.Vizualise(1) as PartialViewResult;
            var _model = (r.Model as AuthorViewModel);
            _model.Name = name;
            controler.Update(_model).GetAwaiter().GetResult();
            r = controler.Vizualise(1) as PartialViewResult;
            _model = (r.Model as AuthorViewModel);
            Assert.IsTrue(_model.Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(AuthorSource), "AuthorGetAllSource")]
        public void TestListAll(ICollection<AuthorViewModel> model, string search, int page, string test, int result)
        {
            _init();
            AuthorController controler = new AuthorController(_service);
            foreach (var item in model)
            {
                controler.New(item).GetAwaiter().GetResult();
            }
            var r = controler.ListAll(search, page) as PartialViewResult; 
            var _model = (r.Model as AuthorPagination);
            Assert.IsTrue((r.Model as AuthorPagination).Author.Dados.Count == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(AuthorSource), "AuthorViewSource")]
        public void TestView(AuthorViewModel model, string test)
        {
            _init();
            AuthorController controler = new AuthorController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as AuthorViewModel) != null, $"Erro no Teste: {test}");
        }
    }
}
