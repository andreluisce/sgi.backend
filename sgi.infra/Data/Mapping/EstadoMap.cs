using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(60)
               .IsRequired();

            Property(x => x.UF)
               .HasMaxLength(2)
               .IsRequired();

            //Ignore(e => e.RegiaoId);

            //Relacionamento 1 to N            
            HasRequired(x => x.Pais).WithMany(x => x.Estados).HasForeignKey(x => x.PaisId).WillCascadeOnDelete(false);

            //HasOptional(x => x.Regiao).WithMany(x => x.Estados).HasForeignKey(x => x.RegiaoId).WillCascadeOnDelete(false); 
        }
    }
}