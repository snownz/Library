namespace Library.Domain.DbConfig
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {

        }      

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}