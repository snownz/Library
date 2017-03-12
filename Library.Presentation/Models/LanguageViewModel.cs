using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class LanguageViewModel
    {
        public LanguageViewModel()
        {
            Id = -1;
            New = true;
        }
        public int Id { get; set; }
        [DisplayName("Genre")]
        [Required(ErrorMessage = "É nescessario digitar a descrição")]
        public string Description { get; set; }
        public bool New { get; set; }
    }
}