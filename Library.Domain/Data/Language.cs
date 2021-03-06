﻿using Library.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Data
{
    public class Language : ITable, ISearch
    {
        public Language()
        {
            Id = -1;
            Active = true;
        }

        [Key]
        public virtual int Id { get; set; }

        public string Descricao { get; set; }

        public virtual bool Active { get; set; }

        public ICollection<Book> Books { get; set; }

        [NotMapped]
        public string GetText
        {
            get
            {
                return Descricao;
            }
        }
    }
}