namespace sgi.infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sgiapp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acao",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Route = c.String(maxLength: 100, storeType: "nvarchar"),
                        ModuloId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modulo", t => t.ModuloId)
                .Index(t => t.ModuloId);
            
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40, storeType: "nvarchar"),
                        CssClass = c.String(maxLength: 25, storeType: "nvarchar"),
                        SupermoduloId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modulo", t => t.SupermoduloId)
                .Index(t => t.SupermoduloId);
            
            CreateTable(
                "dbo.Regra",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true, name: "IX_ROLE_NAME");
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 160, storeType: "nvarchar"),
                        Senha = c.String(maxLength: 32, fixedLength: true, storeType: "nchar"),
                        CriadoEm = c.DateTime(nullable: false, precision: 0),
                        Ativo = c.Boolean(nullable: false),
                        RegraId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regra", t => t.RegraId, cascadeDelete: true)
                .Index(t => t.Email, unique: true, name: "IX_EMAIL")
                .Index(t => t.RegraId);
            
            CreateTable(
                "dbo.PerfilPessoal",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Sexo = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        Skype = c.String(maxLength: 40, storeType: "nvarchar"),
                        Facebook = c.String(maxLength: 40, storeType: "nvarchar"),
                        Fone1 = c.String(maxLength: 20, storeType: "nvarchar"),
                        Fone2 = c.String(maxLength: 20, storeType: "nvarchar"),
                        Celular1 = c.String(maxLength: 20, storeType: "nvarchar"),
                        Celular2 = c.String(maxLength: 20, storeType: "nvarchar"),
                        Avatar = c.String(unicode: false),
                        IgrejaId = c.Long(),
                        EnderecoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .ForeignKey("dbo.Igreja", t => t.IgrejaId)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IgrejaId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Numero = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        EnderecoNome = c.String(nullable: false, unicode: false),
                        Bairro = c.String(unicode: false),
                        CEP = c.String(maxLength: 8, storeType: "nvarchar"),
                        TipoEndereco = c.Int(nullable: false),
                        CidadeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        EstadoId = c.Long(nullable: false),
                        DistritoId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Distrito", t => t.DistritoId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        EstadoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        UF = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                        PaisId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Sigla = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regiao",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        DenominacaoId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Denominacao", t => t.DenominacaoId)
                .Index(t => t.DenominacaoId);
            
            CreateTable(
                "dbo.Denominacao",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Igreja",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        DistritoId = c.Long(nullable: false),
                        DenominacaoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Denominacao", t => t.DenominacaoId)
                .ForeignKey("dbo.Distrito", t => t.DistritoId)
                .Index(t => t.DistritoId)
                .Index(t => t.DenominacaoId);
            
            CreateTable(
                "dbo.PerfilIgreja",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        DataAbertura = c.DateTime(nullable: false, precision: 0),
                        Email1 = c.String(unicode: false),
                        Email2 = c.String(unicode: false),
                        Facebook = c.String(unicode: false),
                        Fone1 = c.String(unicode: false),
                        Fone2 = c.String(unicode: false),
                        Celular1 = c.String(unicode: false),
                        Celular2 = c.String(unicode: false),
                        EnderecoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Igreja", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.RegioesEstados",
                c => new
                    {
                        RegiaoId = c.Long(nullable: false),
                        EstadoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegiaoId, t.EstadoId })
                .ForeignKey("dbo.Regiao", t => t.RegiaoId, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.RegiaoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.ModulosRegras",
                c => new
                    {
                        ModuloId = c.Long(nullable: false),
                        RegraId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModuloId, t.RegraId })
                .ForeignKey("dbo.Modulo", t => t.ModuloId, cascadeDelete: true)
                .ForeignKey("dbo.Regra", t => t.RegraId, cascadeDelete: true)
                .Index(t => t.ModuloId)
                .Index(t => t.RegraId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acao", "ModuloId", "dbo.Modulo");
            DropForeignKey("dbo.Modulo", "SupermoduloId", "dbo.Modulo");
            DropForeignKey("dbo.ModulosRegras", "RegraId", "dbo.Regra");
            DropForeignKey("dbo.ModulosRegras", "ModuloId", "dbo.Modulo");
            DropForeignKey("dbo.Usuario", "RegraId", "dbo.Regra");
            DropForeignKey("dbo.PerfilPessoal", "Id", "dbo.Usuario");
            DropForeignKey("dbo.PerfilPessoal", "IgrejaId", "dbo.Igreja");
            DropForeignKey("dbo.PerfilPessoal", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Cidade", "DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Distrito", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.RegioesEstados", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.RegioesEstados", "RegiaoId", "dbo.Regiao");
            DropForeignKey("dbo.Regiao", "DenominacaoId", "dbo.Denominacao");
            DropForeignKey("dbo.PerfilIgreja", "Id", "dbo.Igreja");
            DropForeignKey("dbo.PerfilIgreja", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Igreja", "DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Igreja", "DenominacaoId", "dbo.Denominacao");
            DropForeignKey("dbo.Estado", "PaisId", "dbo.Pais");
            DropIndex("dbo.ModulosRegras", new[] { "RegraId" });
            DropIndex("dbo.ModulosRegras", new[] { "ModuloId" });
            DropIndex("dbo.RegioesEstados", new[] { "EstadoId" });
            DropIndex("dbo.RegioesEstados", new[] { "RegiaoId" });
            DropIndex("dbo.PerfilIgreja", new[] { "EnderecoId" });
            DropIndex("dbo.PerfilIgreja", new[] { "Id" });
            DropIndex("dbo.Igreja", new[] { "DenominacaoId" });
            DropIndex("dbo.Igreja", new[] { "DistritoId" });
            DropIndex("dbo.Regiao", new[] { "DenominacaoId" });
            DropIndex("dbo.Estado", new[] { "PaisId" });
            DropIndex("dbo.Distrito", new[] { "EstadoId" });
            DropIndex("dbo.Cidade", new[] { "DistritoId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.PerfilPessoal", new[] { "EnderecoId" });
            DropIndex("dbo.PerfilPessoal", new[] { "IgrejaId" });
            DropIndex("dbo.PerfilPessoal", new[] { "Id" });
            DropIndex("dbo.Usuario", new[] { "RegraId" });
            DropIndex("dbo.Usuario", "IX_EMAIL");
            DropIndex("dbo.Regra", "IX_ROLE_NAME");
            DropIndex("dbo.Modulo", new[] { "SupermoduloId" });
            DropIndex("dbo.Acao", new[] { "ModuloId" });
            DropTable("dbo.ModulosRegras");
            DropTable("dbo.RegioesEstados");
            DropTable("dbo.PerfilIgreja");
            DropTable("dbo.Igreja");
            DropTable("dbo.Denominacao");
            DropTable("dbo.Regiao");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Distrito");
            DropTable("dbo.Cidade");
            DropTable("dbo.Endereco");
            DropTable("dbo.PerfilPessoal");
            DropTable("dbo.Usuario");
            DropTable("dbo.Regra");
            DropTable("dbo.Modulo");
            DropTable("dbo.Acao");
        }
    }
}
