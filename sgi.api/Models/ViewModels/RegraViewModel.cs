using System;
using System.Collections.Generic;

namespace sgi.api.Models.ViewModels
{
    public class RegraViewModel
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }                
        public virtual ICollection<ModuloViewModel> Modulos { get; set; }
    }
}