using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure (EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Author");
            modelBuilder.HasKey(a => a.Author_Id);
            modelBuilder.Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Property(a => a.Location).IsRequired(false);
            modelBuilder.Ignore(a => a.FullName);
        }
    }
}
