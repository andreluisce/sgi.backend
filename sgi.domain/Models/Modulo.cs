using sgi.common.Resources;
using sgi.common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Modulo
    {
        public Modulo()
        {
            this.Regras = new List<Regra>();
            this.Acoes = new List<Acao>();
        }
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string CssClass { get; set; }
        public Int64? SupermoduloId { get; set; }
        public virtual ICollection<Modulo> Submodulos { get; set; }
        public virtual Modulo Supermodulo { get; set; }
        public virtual ICollection<Acao> Acoes { get; set; }
        public virtual ICollection<Regra> Regras { get; set; }

        public void Validar()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 40, Errors.InvalidModuleName);

        }

        public void MudarNome(string nome)
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 40, Errors.InvalidRoleName);
            this.Nome = nome;
        }

    }
}
