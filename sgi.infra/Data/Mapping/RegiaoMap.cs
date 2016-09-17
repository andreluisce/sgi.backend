using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    public class RegiaoMap : EntityTypeConfiguration<Regiao>
    {
        public RegiaoMap()
        {
            ToTable("Regiao");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(60)
               .IsRequired();

            HasOptional(x => x.Denominacao).WithMany(x => x.Regioes).HasForeignKey(x => x.DenominacaoId).WillCascadeOnDelete(false);

            HasMany(x => x.Estados).WithMany(x => x.Regioes)
            .Map(t =>
                {
                    t.MapLeftKey("RegiaoId");
                    t.MapRightKey("EstadoId");
                    t.ToTable("RegioesEstados");
                });
        }
    }
}