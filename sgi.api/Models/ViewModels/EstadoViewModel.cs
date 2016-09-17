using sgi.domain.Models;
using System;

namespace sgi.api.Models.ViewModels
{
    public class EstadoViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public Int64 PaisId { get; set; }
        public PaisViewModel Pais { get; set; }        
    }
}