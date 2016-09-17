using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Estado
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public Int64 PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        //public Int64? RegiaoId { get; set; }
        public virtual ICollection<Regiao> Regioes { get; set; } 
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}

