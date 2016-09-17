using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class RegraMap : EntityTypeConfiguration<Regra>
    {
        public RegraMap()
        {
            ToTable("Regra");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(40).HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_ROLE_NAME", 1) { IsUnique = true }))
                .IsRequired();
                      
        }
    }
}
