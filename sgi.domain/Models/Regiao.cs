using System;
using System.Collections.Generic;

namespace sgi.domain.Models
{
    public class Regiao
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public Int64? DenominacaoId { get; set; }
        public virtual Denominacao Denominacao { get; set; }        
        public virtual ICollection<Estado> Estados { get; set; }
    }
}
