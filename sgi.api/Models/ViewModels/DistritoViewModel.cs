using System;

namespace sgi.api.Models.ViewModels
{
    public class DistritoViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
        public EstadoViewModel Estado { get; set; }
    
    }
}