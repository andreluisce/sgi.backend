using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgi.domain.Models
{
    public class Igreja
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long DistritoId { get; set; }
        public long DenominacaoId { get; set; }
        public virtual ICollection<PerfilPessoal> Membros { get; set; }
        public virtual PerfilIgreja PerfilIgreja { get; set; } //one to one
        public virtual Distrito Distrito { get; set; }
        public virtual Denominacao Denominacao { get; set; }
    }
}
