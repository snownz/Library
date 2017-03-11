using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Data
{
    public class BookRating : ITable
    {
        public BookRating()
        {
            Id = -1;
            Active = true;
        }

        [Key]
        public virtual int Id { get; set; }
        public virtual int Id_Book { get; set; }

        public virtual double Rate { get; set; }

        public virtual bool Active { get; set; }

        public Book Book { get; set; }
    }
}
