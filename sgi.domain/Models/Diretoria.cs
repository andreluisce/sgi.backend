using sgi.domain.Contracts;
using sgi.domain.Models.Enum;
using System;

namespace sgi.domain.Models
{
    public class Diretoria : IDiretoria
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public TipoDiretoria TipoDiretoria { get; set; }
    }
}
