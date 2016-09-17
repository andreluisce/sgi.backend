using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");            
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(80)
               .IsRequired();

            //Relacionamento 1 to N            
           HasRequired(x => x.Estado).WithMany(x => x.Cidades).HasForeignKey(x => x.EstadoId).WillCascadeOnDelete(false);

           HasOptional(x => x.Distrito).WithMany(x => x.Cidades).HasForeignKey(x => x.DistritoId).WillCascadeOnDelete(false); 
            
        }
    }
}