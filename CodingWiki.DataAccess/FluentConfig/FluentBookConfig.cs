using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure (EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Book");
            modelBuilder.Property(u => u.ISBN).HasMaxLength(50);
            modelBuilder.Property(u => u.ISBN).IsRequired();
            modelBuilder.Property(u => u.Title).IsRequired(false);
            modelBuilder.HasKey(u => u.BookId);
            modelBuilder.Ignore(u => u.PriceRange);

            // one to many relationship with fluent api
            modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books).HasForeignKey(u => u.Publisher_Id);
        }
    }
}
