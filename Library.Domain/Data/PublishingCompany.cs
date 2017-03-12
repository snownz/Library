
using Library.Tools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Data
{
    public class PublishingCompany : ITable, ISearch
    {
        public PublishingCompany()
        {
            Id = -1;
            Active = true;
        }

        [Key]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual string CNPJ { get; set; }

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