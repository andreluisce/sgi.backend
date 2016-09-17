using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class DenominacaoMap : EntityTypeConfiguration<Denominacao>
    {
        public DenominacaoMap()
        {
            ToTable("Denominacao");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(60)
               .IsRequired();                        
            
        }
    }
}