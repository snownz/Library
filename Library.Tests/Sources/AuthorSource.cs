using Library.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests.Sources
{
    public class AuthorSource
    {
        /// <summary>
        ///     AuthorViewModel model, string test, string result
        /// </summary>
        public static object[] AuthorNewSource = new[]
        {
            new object[] { new AuthorViewModel() { Name = "Autor1"}, "Teste Inserir Novo Registro", "Autor1"},
        };
    }
}
