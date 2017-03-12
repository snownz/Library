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
    public class CompanyControllerTest
    {
        private static IRepository<PublishingCompany> _repo = new MockRepository<PublishingCompany>();
        private static ICompany _service = new CompanyService(_repo);

        [OneTimeSetUp]
        public void Init()
        {
            AutoMapperConfig.RegisterMapping();
        }

        private void _init()
        {
            _repo = new MockRepository<PublishingCompany>();
            _service = new CompanyService(_repo);
        }

        [Test, Category("Unit"), TestCaseSource(typeof(CompanySource), "CompanyNewSource")]
        public void TestNew(CompanyViewModel model, string test, string result)
        {
            _init();
            CompanyController controler = new CompanyController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as CompanyViewModel).Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(CompanySource), "CompanyDeleteSource")]
        public void TestDelete(CompanyViewModel model, int id, string test)
        {
            _init();
            CompanyController controler = new CompanyController(_service);
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

        [Test, Category("Unit"), TestCaseSource(typeof(CompanySource), "CompanyUpdateSource")]
        public void TestUpdate(CompanyViewModel model, string name, string test, string result)
        {
            _init();
            CompanyController controler = new CompanyController(_service);
            controler.New(model).GetAwaiter().GetResult();            
            var r = controler.Vizualise(1) as PartialViewResult;
            var _model = (r.Model as CompanyViewModel);
            _model.Name = name;
            controler.Update(_model).GetAwaiter().GetResult();
            r = controler.Vizualise(1) as PartialViewResult;
            _model = (r.Model as CompanyViewModel);
            Assert.IsTrue(_model.Name == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(CompanySource), "CompanyGetAllSource")]
        public void TestListAll(ICollection<CompanyViewModel> model, string search, int page, string test, int result)
        {
            _init();
            CompanyController controler = new CompanyController(_service);
            foreach (var item in model)
            {
                controler.New(item).GetAwaiter().GetResult();
            }
            var r = controler.ListAll(search, page) as PartialViewResult; 
            var _model = (r.Model as CompanyPagination);
            Assert.IsTrue((r.Model as CompanyPagination).Company.Dados.Count == result, $"Erro no Teste: {test}");
        }

        [Test, Category("Unit"), TestCaseSource(typeof(CompanySource), "CompanyViewSource")]
        public void TestView(CompanyViewModel model, string test)
        {
            _init();
            CompanyController controler = new CompanyController(_service);
            controler.New(model).GetAwaiter().GetResult();
            var r = controler.Vizualise(1) as PartialViewResult;
            Assert.IsTrue((r.Model as CompanyViewModel) != null, $"Erro no Teste: {test}");
        }
    }
}
