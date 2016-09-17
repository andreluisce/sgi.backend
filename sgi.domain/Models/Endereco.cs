using sgi.common.Resources;
using sgi.common.Validation;
using sgi.domain.Models.Enum;
using System;
using System.Collections.Generic;

namespace sgi.domain.Models
{
    public class Endereco
    {
        public Int64 Id { get; set; }
        public string Numero { get; set; }
        public string EnderecoNome { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public Int64 CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<PerfilPessoal> PerfisPessoais { get; set; }
        public virtual ICollection<PerfilIgreja> PerfisIgrejas { get; set; }
               

        public void Validar()
        {
           // AssertionConcern.AssertArgumentRange(this.Numero, 1, Errors.InvalidAddressNumber);
            AssertionConcern.AssertArgumentRange(this.CidadeId, 1, Errors.InvalidCity);
            AssertionConcern.AssertArgumentRange((int)this.TipoEndereco, 1, Errors.InvalidAddressType);
            AssertionConcern.AssertArgumentLength(this.EnderecoNome, 3, 50, Errors.InvalidAddressType);
            AssertionConcern.AssertArgumentLength(this.Bairro, 2, 50, Errors.InvalidDistrict);
        }
    }
}
