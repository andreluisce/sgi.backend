using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public PaisMap()
        {
            ToTable("Pais");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(60)
               .IsRequired();

            Property(x => x.Sigla)
               .HasMaxLength(2)
               .IsRequired();
        }
    }
}