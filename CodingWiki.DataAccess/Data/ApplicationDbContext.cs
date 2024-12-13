using CodingWiki.DataAccess.FluentConfig;
using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        // rename to Fluent_BookDetails
        public DbSet<Fluent_BookDetail> BookDetail_Fluent { get; set; }
        public DbSet<Fluent_Book> Book_Fluent { get; set; }
        public DbSet<Fluent_Author> Author_Fluent { get; set; }
        public DbSet<Fluent_Publisher> Publisher_Fluent { get; set; }
        public DbSet<Fluent_BookAuthorMap> BookAuthorMaps_Fluent { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // config files
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            // many to many
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());

            // change column property of decimal
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);

            // Configure manual many to many map
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            // seed data
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune of time", ISBN = "123B12", Price = 11.99m, Publisher_Id = 1 }
            );

            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id = 2 },
                new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m, Publisher_Id = 2 },
                new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id = 3 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago"},
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York"},
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii"}
            );
        }
    }
}
