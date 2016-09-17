using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class IgrejaMap : EntityTypeConfiguration<Igreja>
    {
        public IgrejaMap()
        {
            ToTable("Igreja");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(60)
               .IsRequired();


            HasRequired(x => x.PerfilIgreja).WithRequiredPrincipal(x => x.Igreja); 
            
            //Relacionamento 1 to N
            //Para ter uma ação é necessário ter um módulo; e esse módulo tem muitas ações, e cada uma dela tem um FK chamado ModuloID
            HasRequired(x => x.Distrito).WithMany(x => x.Igrejas).HasForeignKey(x => x.DistritoId).WillCascadeOnDelete(false);

            HasRequired(x => x.Denominacao).WithMany(x => x.Igrejas).HasForeignKey(x => x.DenominacaoId).WillCascadeOnDelete(false); 

        }
    }
}