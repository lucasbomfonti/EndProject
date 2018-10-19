using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EndProject.Domain.Entities;

namespace EndProject.Infra.Persistence.Map
{
    public class MapPlayer : EntityTypeConfiguration<Player>
    {
        public MapPlayer()
        {
            ToTable("Player");

            Property(p => p.Email.Address).HasMaxLength(200).IsRequired()
                .HasColumnAnnotation("Index", new IndexAttribute("UK_PLAYER_EMAIL"){ IsUnique = true}).HasColumnName("Email");
            Property(p => p.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstNome");
            Property(p => p.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("lastNome");
            Property(p => p.Password).IsRequired();

        }
    }
}
