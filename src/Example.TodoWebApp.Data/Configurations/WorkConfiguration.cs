using Example.TodoWebApp.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.TodoWebApp.Data.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(true);

            builder.Property(x => x.Title).HasMaxLength(20);
            builder.Property(x => x.Title).IsRequired(true);
        }
    }
}
