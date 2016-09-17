using System.Collections.Generic;

namespace sgi.domain.Models
{
   public class Denominacao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Regiao> Regioes { get; set; }
        public virtual ICollection<Igreja> Igrejas { get; set; }
    }
}
