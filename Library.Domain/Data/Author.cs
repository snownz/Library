using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Data
{
    public class Author : ITable
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
    }
}