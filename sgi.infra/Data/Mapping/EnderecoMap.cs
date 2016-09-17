using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CEP)
            .HasMaxLength(8);

            Property(x => x.Numero)
            .HasMaxLength(15);

            Property(x => x.Numero)
               .IsRequired();

            Property(x => x.EnderecoNome)
               .IsRequired();
            
            //Relacionamento 1 to N            
            HasRequired(x => x.Cidade).WithMany(x => x.Enderecos).HasForeignKey(x => x.CidadeId).WillCascadeOnDelete(false); 
      
        }
    }
}