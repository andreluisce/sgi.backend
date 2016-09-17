using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class AcaoMap : EntityTypeConfiguration<Acao>
    {
        public AcaoMap()
        {
            ToTable("Acao");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(100)
               .IsRequired();

            Property(x => x.Route)
               .HasMaxLength(100);

            //Relacionamento 1 to N
            //Para ter uma ação é necessário ter um módulo; e esse módulo tem muitas ações, e cada uma dela tem um FK chamado ModuloID
            HasRequired(x => x.Modulo).WithMany(x => x.Acoes).HasForeignKey(x => x.ModuloId).WillCascadeOnDelete(false); 

        }
    }
}