using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Pais
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }      
        public virtual ICollection<Estado> Estados { get; set; } 
    }
}
