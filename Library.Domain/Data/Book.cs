﻿using Library.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Data
{
    public class Book : ITable, ISearch
    {
        public Book()
        {
            Id = -1;
            Active = true;
        }

        [Key]
        public virtual int Id { get; set; }
        public virtual int Id_Idioma { get; set; }
        public virtual int Id_Editora { get; set; }
        public virtual int Id_Autor { get; set; }

        public virtual bool Active { get; set; }

        [StringLength(80)]
        public virtual string Name { get; set; }
        [StringLength(4000)] 
        public virtual string Description { get; set; }
        [StringLength(4000)]
        public virtual byte[] Image { get; set; }

        public virtual int Number { get; set; }
        public virtual int Year { get; set; }
        public virtual int PagesNumber { get; set; }
        public virtual bool SpecialEdition { get; set; }

        public Language Language { get; set; }
        public PublishingCompany Company { get; set; }
        public Author Author { get; set; }

        public ICollection<BookRating> Rating { get; set; }

        [NotMapped]
        public string GetText
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
