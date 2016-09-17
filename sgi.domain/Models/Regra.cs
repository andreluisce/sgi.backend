using sgi.common.Resources;
using sgi.common.Validation;
using System;
using System.Collections.Generic;

namespace sgi.domain.Models
{
    public class Regra
    {
                
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual List<Modulo> Modulos { get; set; }

        public void Validar()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 40, Errors.InvalidRoleName);
          
        }

        public void MudarNome(string nome)
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 40, Errors.InvalidRoleName);
            this.Nome = nome;

        }
    }
}
