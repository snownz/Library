using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Data
{
    public class Book : ITable
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
        public virtual string Descricao { get; set; }

        public virtual int NumeroEdicao { get; set; }
        public virtual int AnoEdicao { get; set; }
        public virtual int NumeroPaginas { get; set; }
        public virtual bool EdicaoEspecial { get; set; }

        public Language Idioma { get; set; }
        public PublishingCompany Editora { get; set; }
        public Author Autor { get; set; }

        public ICollection<BookRating> Rating { get; set; }
    }
}
