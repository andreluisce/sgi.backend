using sgi.common.Resources;
using sgi.common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Acao
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string Route { get; set; }
        public Int64 ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
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
