using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Library.Domain.Data;
using Library.Domain.Interface;
using Library.Domain.DbConfig;
using Library.Domain.Service;

namespace Library.Presentation.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // Repositorios
            container.RegisterType<IRepository<Book>, Repository<Book>>();
            container.RegisterType<IRepository<BookRating>, Repository<BookRating>>();
            container.RegisterType<IRepository<Language>, Repository<Language>>();
            container.RegisterType<IRepository<PublishingCompany>, Repository<PublishingCompany>>();
            container.RegisterType<IRepository<Author>, Repository<Author>>();

            // Serviços
            container.RegisterType<ILibrary, BookService>();
            container.RegisterType<ICompany, CompanyService>();
            container.RegisterType<ILanguage, LanguageService>();
            container.RegisterType<IAuthor, AuthorService>();
        }
    }
}
