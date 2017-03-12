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
    public class LanguageControllerTest
    {
        private static IRepository<Language> _repo = new MockRepository<Language>();
        private static ILanguage _service = new LanguageService(_repo);

        [OneTimeSetUp]
        public void Init()
        {
            AutoMapperConfig.RegisterMapping();
        }

        private void _init()
        {
            _repo = new MockRepository<Language>();
            _service = new LanguageService(_repo);
        }

        [Test, Category("Unit"), TestCaseSource(typeof(LanguageSource), "LanguageNewSource")]
        public void TestNew(LanguageViewModel model, string test, string result)
        {
            _init();
            LanguageController controler = new LanguageController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as LanguageViewModel).Description == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(LanguageSource), "LanguageDeleteSource")]
        public void TestDelete(LanguageViewModel model, int id, string test)
        {
            _init();
            LanguageController controler = new LanguageController(_service);
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

        [Test, Category("Unit"), TestCaseSource(typeof(LanguageSource), "LanguageUpdateSource")]
        public void TestUpdate(LanguageViewModel model, string name, string test, string result)
        {
            _init();
            LanguageController controler = new LanguageController(_service);
            controler.New(model).GetAwaiter().GetResult();            
            var r = controler.Vizualise(1) as PartialViewResult;
            var _model = (r.Model as LanguageViewModel);
            _model.Description = name;
            controler.Update(_model).GetAwaiter().GetResult();
            r = controler.Vizualise(1) as PartialViewResult;
            _model = (r.Model as LanguageViewModel);
            Assert.IsTrue(_model.Description == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(LanguageSource), "LanguageGetAllSource")]
        public void TestListAll(ICollection<LanguageViewModel> model, string search, int page, string test, int result)
        {
            _init();
            LanguageController controler = new LanguageController(_service);
            foreach (var item in model)
            {
                controler.New(item).GetAwaiter().GetResult();
            }
            var r = controler.ListAll(search, page) as PartialViewResult; 
            var _model = (r.Model as LanguagePagination);
            Assert.IsTrue((r.Model as LanguagePagination).Language.Dados.Count == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(LanguageSource), "LanguageViewSource")]
        public void TestView(LanguageViewModel model, string test)
        {
            _init();
            LanguageController controler = new LanguageController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as LanguageViewModel) != null, $"Erro no Teste: {test}");
        }
    }
}
