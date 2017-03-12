using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            ID = -1;
            New = true;
            ID_Author = 1;
            ID_Company = 1;
            ID_Language = 1;
        }
        public int ID { get; set; }
        [DisplayName("Autor")]
        [Required(ErrorMessage = "É nescessario escolher o autor")]
        public int ID_Author { get; set; }
        [DisplayName("Editora")]
        [Required(ErrorMessage = "É nescessario escolher o editora")]
        public int ID_Company { get; set; }
        [DisplayName("Linguagem")]
        [Required(ErrorMessage = "É nescessario escolher a linguagem")]
        public int ID_Language { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "É nescessario digitar a nome")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "É nescessario digitar a descrição")]
        public string Description { get; set; }
        [DisplayName("Especial")]
        public bool Special { get; set; }
        [DisplayName("Imagem")]
        public string Image { get; set; }
        [DisplayName("Numero da Edição")]
        [Required(ErrorMessage = "É nescessario digitar a nome")]
        public int Number { get; set; }
        [DisplayName("Ano da Edição")]
        [Required(ErrorMessage = "É nescessario digitar a nome")]
        public int Year { get; set; }
        [DisplayName("Numero de Paginas")]
        [Required(ErrorMessage = "É nescessario digitar a nome")]
        public int PagesNumber { get; set; }

        [DisplayName("Editora")]
        public CompanyViewModel Company { get; set; }
        [DisplayName("Autor")]
        public AuthorViewModel Author { get; set; }
        [DisplayName("Linguagem")]
        public LanguageViewModel Language { get; set; }
        public bool New { get; set; }

        [DisplayName("Resumo")]
        public string Resume { get { return Description.Substring(0, 100); } }
    }
}