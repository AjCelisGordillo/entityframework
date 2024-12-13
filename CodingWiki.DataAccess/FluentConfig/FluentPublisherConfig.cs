using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure (EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Publisher");
            modelBuilder.HasKey(p => p.Publisher_Id);
            modelBuilder.Property(p => p.Location).IsRequired(false);
        }
    }
}
