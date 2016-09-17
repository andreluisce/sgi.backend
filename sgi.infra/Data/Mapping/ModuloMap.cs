using sgi.domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sgi.infra.Data.Mapping
{
    class ModuloMap : EntityTypeConfiguration<Modulo>
    {
        public ModuloMap()
        {
            ToTable("Modulo");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
               .HasMaxLength(40)
               .IsRequired();

            Property(x => x.CssClass)
               .HasMaxLength(25);               

             HasMany(x => x.Regras).WithMany(x => x.Modulos)
                .Map(t =>
                {
                    t.MapLeftKey("ModuloId");
                    t.MapRightKey("RegraId");
                    t.ToTable("ModulosRegras");
                });

             HasOptional(x => x.Supermodulo).
                 WithMany(x => x.Submodulos).
                 HasForeignKey(x => x.SupermoduloId).
                 WillCascadeOnDelete(false);            
        }
    }
}