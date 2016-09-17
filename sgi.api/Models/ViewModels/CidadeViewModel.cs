using System;

namespace sgi.api.Models.ViewModels
{
    public class CidadeViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public Int64 EstadoId { get; set; }
        public virtual EstadoViewModel Estado { get; set; }
    }
}