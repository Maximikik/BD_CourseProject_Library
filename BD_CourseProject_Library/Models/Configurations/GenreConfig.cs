using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD_CourseProject_Library.Models.Configurations
{
    public class GenreConfig
    : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(entity => entity.Name).IsUnique();
        }
    }
}
