using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class PerfilPessoalMap : EntityTypeConfiguration<PerfilPessoal>
    {
        public PerfilPessoalMap()
        {
            ToTable("PerfilPessoal");

            HasKey(p => p.Id);

            Property(x => x.Skype)
                .HasMaxLength(40);

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

            HasRequired(x => x.Usuario).WithRequiredDependent(x => x.PerfilPessoal);

            HasOptional(x => x.Igreja).WithMany(x => x.Membros).HasForeignKey(x => x.IgrejaId).WillCascadeOnDelete(false);

            HasRequired(x => x.Endereco).WithMany(x => x.PerfisPessoais).HasForeignKey(x => x.EnderecoId).WillCascadeOnDelete(false);

        }
    }
}

