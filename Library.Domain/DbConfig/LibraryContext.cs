namespace Library.Domain.DbConfig
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            ConfigureBooks(modelBuilder);
            ConfigureLanguages(modelBuilder);
            ConfigureCompany(modelBuilder);
            ConfigureAuthor(modelBuilder);
        }

        private void ConfigureAuthor(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
        }
        private void ConfigureCompany(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublishingCompany>().ToTable("PublishingCompany");
        }
        private void ConfigureLanguages(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("Language");
        }
        private void ConfigureBooks(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Language)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.Id_Idioma);
            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Company)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.Id_Editora);
            modelBuilder.Entity<Book>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.Id_Autor);
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<PublishingCompany> PublishingCompany { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Author> Author { get; set; }
    }
}