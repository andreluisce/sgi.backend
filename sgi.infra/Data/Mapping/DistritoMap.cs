using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    public class DistritoMap : EntityTypeConfiguration<Distrito>
    {
        public DistritoMap()
        {
            ToTable("Distrito");            
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(80)
               .IsRequired();

            //Relacionamento 1 to N            
           HasRequired(x => x.Estado).WithMany(x => x.Distritos).HasForeignKey(x => x.EstadoId).WillCascadeOnDelete(false);

        }
    }
}