using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Distrito
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public Int64 EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Igreja> Igrejas { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
