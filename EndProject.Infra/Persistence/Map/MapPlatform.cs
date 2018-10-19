using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EndProject.Domain.Entities;

namespace EndProject.Infra.Persistence.Map
{
    public class MapPlatform : EntityTypeConfiguration<Platform>
    {
        public MapPlatform()
        {
            ToTable("Platform");
            Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
