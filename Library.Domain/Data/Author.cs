using Library.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Data
{
    public class Author : ITable, ISearch
    {
        public Author()
        {
            Id = -1;
            Active = true;
        }

        [Key]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public double Rating { get; set; }

        public virtual bool Active { get; set; }

        public ICollection<Book> Books { get; set; }

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