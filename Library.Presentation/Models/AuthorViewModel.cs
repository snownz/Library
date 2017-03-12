using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Presentation.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Id = -1;
            New = true; 
        }
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "É nescessario digitar o nome")]
        public string Name { get; set; }
        public bool New { get; set; }
    }
}