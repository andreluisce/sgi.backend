using MySql.Data.Entity;
using sgi.domain.Models;
using sgi.infra.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace sgi.infra.Data
{


    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppDataContext : DbContext
    {

        public AppDataContext()
            : base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            /*Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDataContext, sgi.infra.Migrations.Configuration>("AppConnectionString"));
             */
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Regra> Regras { get; set; }
        public DbSet<PerfilPessoal> Perfis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Acao> Acoes { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<Denominacao> Denominacoes { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Distrito> Distritos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new AcaoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new PerfilPessoalMap());
            modelBuilder.Configurations.Add(new RegraMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PaisMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new IgrejaMap());
            modelBuilder.Configurations.Add(new DenominacaoMap());
            modelBuilder.Configurations.Add(new DistritoMap());
            modelBuilder.Configurations.Add(new RegiaoMap());

        }
    }
}
