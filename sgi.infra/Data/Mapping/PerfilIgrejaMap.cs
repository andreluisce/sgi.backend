using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class PerfilIgrejaMap : EntityTypeConfiguration<PerfilIgreja>
    {
        public PerfilIgrejaMap()
        {
            ToTable("PerfilIgreja");

            HasKey(p => p.Id);

            Property(x => x.Facebook)
                .HasMaxLength(40);

            Property(x => x.Fone1)
                .HasMaxLength(20);

            Property(x => x.Fone2)
                .HasMaxLength(20);
            
            Property(x => x.Celular1)
                .HasMaxLength(20);

            Property(x => x.Celular2)
                .HasMaxLength(20);

            Property(x => x.Email1)
                .HasMaxLength(100);

            Property(x => x.Email2)
                .HasMaxLength(100);

            HasRequired(x => x.Endereco).WithMany(x => x.PerfisIgrejas).HasForeignKey(x => x.EnderecoId).WillCascadeOnDelete(false);

        }
    }
}

